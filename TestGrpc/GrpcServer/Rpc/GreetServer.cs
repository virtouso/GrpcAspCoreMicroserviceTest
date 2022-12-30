using Grpc.Core;
using GrpcDemo;

namespace GrpcServer.Rpc;

public class GreetServer: Greeter.GreeterBase
{
    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = "Hello Changiz " + request.Name
        });
    }
}