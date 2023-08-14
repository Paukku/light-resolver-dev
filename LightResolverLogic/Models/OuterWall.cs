namespace LightResolver.Logic.Models
{
    public class OuterWall
    {
        /// <summary>
        /// TODO: set this value based on optimization results
        /// </summary>
        public WallType Type { get; set; } = WallType.NotSet;

        /// <summary>
        /// TODO: set this value based on optimization results
        /// </summary>
        public double WattageConsumption { get; set; }

        /// <summary>
        /// Height counted as number of shelves vertically. 9 shelves should be considered max height.
        /// </summary>
        public int Height => AdjacentSection?.Shelves.Count ?? 0;

        /// <summary>
        /// First section this outer wall is connected to. 'A Section' is a set of shelves and accessories between two walls.
        /// </summary>
        public Section AdjacentSection { get; set; }

        public decimal Price => (Type, Height) switch
        {
            (WallType.NotElectrified, 2) => 121.0m,
            (WallType.NotElectrified, 3) => 176.0m,
            (WallType.NotElectrified, 4) => 225.0m,
            (WallType.NotElectrified, 5) => 276.0m,
            (WallType.NotElectrified, 6) => 328.0m,
            (WallType.NotElectrified, 7) => 380.0m,
            (WallType.NotElectrified, 8) => 440.0m,
            (WallType.NotElectrified, 9) => 466.0m,

            (WallType.A1, 2) => 633.0m,
            (WallType.A1, 3) => 672.0m,
            (WallType.A1, 4) => 703.0m,
            (WallType.A1, 5) => 785.0m,
            (WallType.A1, 6) => 813.0m,
            (WallType.A1, 7) => 937.0m,
            (WallType.A1, 8) => 984.0m,
            (WallType.A1, 9) => 990.0m,

            (WallType.A2, 2) => 633.0m,
            (WallType.A2, 3) => 672.0m,
            (WallType.A2, 4) => 703.0m,
            (WallType.A2, 5) => 785.0m,
            (WallType.A2, 6) => 813.0m,
            (WallType.A2, 7) => 937.0m,
            (WallType.A2, 8) => 984.0m,
            (WallType.A2, 9) => 990.0m,

            _ => default
        };
    }
}
