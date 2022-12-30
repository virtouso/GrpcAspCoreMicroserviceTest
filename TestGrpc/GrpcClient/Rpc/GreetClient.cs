﻿using Grpc.Net.Client;
using GrpcDemo;

namespace GrpcClient.Rpc;

public interface IGreetClient
{
    Task<HelloReply> SendTest();
}

public class GreetClient : IGreetClient
{
    private readonly ILogger<GreetClient> _logger;
    private readonly string _url;

    public GreetClient(ILogger<GreetClient> logger, IConfiguration configuration)
    {
        _logger = logger;
        _url = configuration["Kestrel:Endpoints:gRPC:Url"];
    }

    public async Task<HelloReply> SendTest()
    {
        var url = "http://localhost:5107";
        var httpHandler = new HttpClientHandler();
        httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
        var channel = GrpcChannel.ForAddress(url, new GrpcChannelOptions { HttpHandler = httpHandler });
        var client = new Greeter.GreeterClient(channel);

        var reply = await client.SayHelloAsync(new HelloRequest { Name = "Worker" });
        _logger.LogInformation($"Greeting: {reply.Message} -- {DateTime.Now}");
        return reply;

    }
}