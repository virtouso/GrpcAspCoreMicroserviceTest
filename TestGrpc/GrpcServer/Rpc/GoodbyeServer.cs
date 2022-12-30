using Grpc.Core;

namespace GrpcServer.Rpc;

using GrpcDemo;

public class GoodbyeServer: Goodbyer.GoodbyerBase
{
    public override  Task<GoodbyeReply> SayGoodbye(GoodbyeRequest request, ServerCallContext context)
    {
        return Task.FromResult(new GoodbyeReply { Message = "Goodbye Changiz " + request.Name });
    }
}