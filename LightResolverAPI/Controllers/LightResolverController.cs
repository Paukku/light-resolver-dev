using LightResolver.Logic;
using LightResolver.Logic.Input;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LightResolver.API.Controllers
{
    [ApiController]
    public class LightResolverController : ControllerBase
    {
        private readonly ILightResolverModule _lightResolverModule;
        private readonly IInputProvider _inputProvider;

        public LightResolverController(ILightResolverModule lightResolver, IInputProvider inputProvider)
        {
            _lightResolverModule = lightResolver;
            _inputProvider = inputProvider;
        }

        [Route("LightResolver/GetResult")]
        [HttpGet]
        [Produces("application/json")]
        public string Get()
        {
            var composition = _inputProvider.Resolve();

            OptimizationResult result = _lightResolverModule.OptimizeComposition(composition);

            return JsonConvert.SerializeObject(result);
        }
    }
}
