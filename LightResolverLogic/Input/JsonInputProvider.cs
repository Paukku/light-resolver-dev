using LightResolver.Logic.Models;

namespace LightResolver.Logic.Input
{
    public class JsonInputProvider : IInputProvider
    {
        public Composition Resolve()
        {
            throw new NotImplementedException();
        }

        public Composition Resolve<T>(T parameters)
        {
            if (parameters is not string pathToFileOrJsonString)
                throw new InvalidOperationException("Could not resolve input for composition.");

            throw new NotImplementedException();
        }
    }
}
