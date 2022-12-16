using Grpc.API.Controllers;
using Grpc.Core;
using Grpc.Core.Interceptors;
using GrpcService1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using NuGet.Protocol;
using Protos;
using Xunit;
using Xunit.Abstractions;

namespace UnitTest;

public class GrpcServiceTest
{
    private readonly ITestOutputHelper _output;

    public GrpcServiceTest(ITestOutputHelper output)
    {
        _output = output;
    }
    

    [Fact]
    public async Task CanFindRoot()
    {
        double a = 2;
        double b = 10;
        double c = 8;
        
        RootRequest request = new RootRequest
        {
            A = a,
            B = b,
            C = c
        };
        var service = new GreeterService();

        // Act
        var response = await service.FindRoot(
            request, It.IsAny<ServerCallContext>());

        _output.WriteLine(JsonConvert.SerializeObject(response,Formatting.Indented));

        // Assert
        Assert.Equal(typeof(RootResponse), response.GetType());

    }

    [Fact]
    public async Task Can_Find_Root_Controller()
    {
       
            double a = 2;
            double b = 10;
            double c = 8;
            
            RootRequest request = new RootRequest
            {
                A = a,
                B = b,
                C = c
            };
        
        var mockClient = new Mock<Quadratic.QuadraticClient>();
        mockClient.Setup(x =>
            x.FindRootAsync(It.IsAny<RootRequest>(),It.IsAny<CallOptions>())).Returns(It.IsAny<AsyncUnaryCall<RootResponse>>);

        var controller = new ProtosController(mockClient.Object);
        var response =  controller.FindRoot(a,b,c);
        
        Assert.NotNull(response);
    }
}