using LightResolver.Logic;
using LightResolver.Logic.Input;
using LightResolver.Logic.Models;

namespace LightResolver.Tests
{
    public sealed class PassTheseTests
    {
        private ILightResolverModule LightResolver { get; set; }

        /// <summary>
        /// Default input provider for test cases. You can also create new compositions without it or have a completely custom provider for your own test cases.
        /// </summary>
        private IInputProvider ParameterizedInputProvider { get; set; }

        [SetUp]
        public void Setup()
        {
            LightResolver = new LightResolverModule(new DefaultInputProvider());
            ParameterizedInputProvider = new ParameterizedInputProvider();
        }

        [Test]
        public void SimpleComposition1()
        {
            ParameterizedInput input = new(new[] { 60 }, 2, new[] { (0, 1) });

            OptimizationResult result = LightResolver.OptimizeComposition(ParameterizedInputProvider.Resolve(input));
            
            Assert.Multiple(() =>
            {
                Assert.That(result.Composition.LeftOuterWall.Type == WallType.A1);
                Assert.That(result.Composition.ShelfAt(0, 1).Type == ShelfType.G1);

                Assert.That(result.LeftSideConsumption > 0.1d);
                Assert.That(result.RightSideConsumption < 0.1d);
            });
        }

        [Test]
        public void SimpleComposition2()
        {
            ParameterizedInput input = new(new[] { 60, 60, 60, 60, 60 }, 2, new[] { (2, 1) });

            OptimizationResult result = LightResolver.OptimizeComposition(ParameterizedInputProvider.Resolve(input));
            
            Assert.Multiple(() =>
            {
                Assert.That(result.Composition.LeftOuterWall.Type == WallType.A1);
                Assert.That(result.Composition.ShelfAt(0, 1).Type == ShelfType.F1);
                Assert.That(result.Composition.ShelfAt(1, 1).Type == ShelfType.EI);
                Assert.That(result.Composition.ShelfAt(2, 1).Type == ShelfType.H);

                Assert.That(result.LeftSideConsumption > 0.1d);
                Assert.That(result.RightSideConsumption < 0.1d);
            });
        }

        [Test]
        public void SimpleComposition3()
        {
            ParameterizedInput input = new(new[] { 60, 60, 60 }, 2, new[] { (0, 1), (1, 1), (2, 1) });

            OptimizationResult result = LightResolver.OptimizeComposition(ParameterizedInputProvider.Resolve(input));
            
            Assert.Multiple(() =>
            {
                Assert.That(result.Composition.LeftOuterWall.Type == WallType.A1);
                Assert.That(result.Composition.ShelfAt(0, 1).Type == ShelfType.G1);
                Assert.That(result.Composition.ShelfAt(1, 1).Type == ShelfType.H);
                Assert.That(result.Composition.ShelfAt(2, 1).Type == ShelfType.H);
                Assert.That(result.Composition.LeftOuterWall.Type == WallType.NotElectrified);

                Assert.That(result.LeftSideConsumption > 0.1d);
                Assert.That(result.RightSideConsumption < 0.1d);
            });
        }

        //TODO: Write more complex test cases for wider coverage
    }
}