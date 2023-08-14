using LightResolver.Logic.Models;

namespace LightResolver.Logic
{
    public interface ILightResolverModule
    {
        OptimizationResult OptimizeComposition(Composition composition);
    }
}