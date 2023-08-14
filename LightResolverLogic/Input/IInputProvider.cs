using LightResolver.Logic.Models;

namespace LightResolver.Logic.Input
{
    /// <summary>
    /// There's two endpoints: with and without parameters, use whatever you need.
    ///
    /// </summary>
    public interface IInputProvider
    {
        Composition Resolve();

        /// <summary>
        /// You should create a custom type for any new input provider arguments. Not mandatory though.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Composition Resolve<T>(T parameters);
    }
}
