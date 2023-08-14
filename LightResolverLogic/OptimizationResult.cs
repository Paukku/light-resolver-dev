using LightResolver.Logic.Models;

namespace LightResolver.Logic
{
    public record OptimizationResult
    {
        public Composition Composition { get; }

        public OptimizationResult(Composition composition) => Composition = composition;

        public decimal Price =>
            Composition.Sections?.SelectMany(x => x.Shelves).Sum(x => x.Price) +
            Composition.LeftOuterWall?.Price +
            Composition.RightOuterWall?.Price
            ?? 0m;

        public double LeftSideConsumption => Composition.LeftOuterWall?.WattageConsumption ?? 0.0;

        public double RightSideConsumption => Composition.RightOuterWall?.WattageConsumption ?? 0.0;

        public double TotalConsumptionBySides => LeftSideConsumption + RightSideConsumption;

        /// <summary>
        /// you can use this to compare that wattage consumption by sides matches to wattage consumption by shelves
        /// </summary>
        public double TotalConsumptionByShelves =>
            Composition.Sections.SelectMany(x => x.Shelves).Sum(x => x.Wattage);
    }
}
