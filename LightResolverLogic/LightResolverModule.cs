using LightResolver.Logic.Input;
using LightResolver.Logic.Models;

namespace LightResolver.Logic
{
    public class LightResolverModule : ILightResolverModule
    {
        public IInputProvider InputProvider { get; }

        public LightResolverModule(IInputProvider inputProvider)
        {
            InputProvider = inputProvider;
        }

        /// <summary>
        /// Calculates optimal lighting components arrangement in given composition. Always tries to resolve cheapest arrangement of components.
        /// Building rules for components are described in wiki.
        /// https://github.com/vividdev/light-resolver-dev/wiki/Assignment#electrified-components
        /// </summary>
        /// <param name="composition"></param>
        /// <returns></returns>
        public OptimizationResult OptimizeComposition(Composition composition)
        {
            //TODO: Create logic that calculates the optimal lighting composition with the cheapest price

            //TODO: Update the composition model objects with OuterWallTypes and ShelfTypes

            return new(composition);
        }
    }
}