
using Grpc.Core;
using Protos;

namespace GrpcService1.Services;

public class GreeterService : Quadratic.QuadraticBase
{
    public override Task<RootResponse> FindRoot(RootRequest request, ServerCallContext context)
    {
        double X = Math.Pow(request.B,2) - 4 * request.A * request.C;
        var response = new RootResponse
        {
            Y = (-request.B + Math.Sqrt(X)) / (2 * request.A),
            Z = (-request.B - Math.Sqrt(X)) / (2 * request.A)
        };
        return Task.FromResult(response);
    }
}
