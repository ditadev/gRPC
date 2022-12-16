
using Microsoft.AspNetCore.Mvc;
using Protos;

namespace Grpc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProtosController : ControllerBase
    {
        private readonly Quadratic.QuadraticClient _client;

        public ProtosController(Quadratic.QuadraticClient client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<RootResponse> FindRoot(double a, double b, double c)
        {
            var result = await _client.FindRootAsync(new RootRequest
            {
                A = a,
                B = b,
                C = c
            });
            return result;
        }
    }
}

