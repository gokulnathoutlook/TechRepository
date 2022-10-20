using Microsoft.AspNetCore.Mvc;

namespace Tech.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TechController : ControllerBase
    {
        private readonly ILogger<TechController> _logger;

        public TechController(ILogger<TechController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetGN")]
        public TechResponse Get(int inputData)
        {
            if (inputData % 3 == 0 && inputData % 5 == 0)
                return new TechResponse { TechDataOutput = "GN" };

            if (inputData % 3 == 0)
                return new TechResponse { TechDataOutput = "G" };

            if (inputData % 5 == 0)
                return new TechResponse { TechDataOutput = "N" };

            return new TechResponse { TechDataOutput = inputData.ToString() };
        }
    }
}