namespace LightResolver.Logic.Models
{
    public class Shelf
    {
        /// <summary>
        /// Whether shelf has light or not
        /// </summary>
        public bool HasLight { get; set; }

        /// <summary>
        /// Shelf type code
        /// </summary>
        public ShelfType Type { get; set; }

        /// <summary>
        /// Shelves should only have width values of 60, 90 or 120.
        /// </summary>
        public int Width { get; set; }

        public double Wattage => (Type, Width) switch
        {
            (ShelfType.E, 60) => 0.0,
            (ShelfType.G1, 60) => 6.5,
            (ShelfType.G2, 60) => 6.5,
            (ShelfType.F1, 60) => 0.0,
            (ShelfType.F2, 60) => 0.0,
            (ShelfType.H, 60) => 6.5,
            (ShelfType.EI, 60) => 0.0,

            (ShelfType.E, 90) => 0.0,
            (ShelfType.G1, 90) => 10.0,
            (ShelfType.G2, 90) => 10.0,
            (ShelfType.F1, 90) => 0.0,
            (ShelfType.F2, 90) => 0.0,
            (ShelfType.H, 90) => 10.0,
            (ShelfType.EI, 90) => 0.0,

            (ShelfType.E, 120) => 0.0,
            (ShelfType.G1, 120) => 13.5,
            (ShelfType.G2, 120) => 13.5,
            (ShelfType.F1, 120) => 0.0,
            (ShelfType.F2, 120) => 0.0,
            (ShelfType.H, 120) => 13.5,
            (ShelfType.EI, 120) => 0.0,
            _ => default
        };

        public decimal Price => (Type, Width) switch
        {
            (ShelfType.E, 60) => 124.0m,
            (ShelfType.G1, 60) => 256.0m,
            (ShelfType.G2, 60) => 256.0m,
            (ShelfType.F1, 60) => 167.0m,
            (ShelfType.F2, 60) => 167.0m,
            (ShelfType.H, 60) => 220.0m,
            (ShelfType.EI, 60) => 144.0m,

            (ShelfType.E, 90) => 147.0m,
            (ShelfType.G1, 90) => 312.0m,
            (ShelfType.G2, 90) => 312.0m,
            (ShelfType.F1, 90) => 196.0m,
            (ShelfType.F2, 90) => 196.0m,
            (ShelfType.H, 90) => 274.0m,
            (ShelfType.EI, 90) => 167.0m,

            (ShelfType.E, 120) => 179.0m,
            (ShelfType.G1, 120) => 370.0m,
            (ShelfType.G2, 120) => 370.0m,
            (ShelfType.F1, 120) => 227.0m,
            (ShelfType.F2, 120) => 227.0m,
            (ShelfType.H, 120) => 334.0m,
            (ShelfType.EI, 120) => 199.0m,
            _ => default
        };


        /// <summary>
        /// Which outer wall side are electric wires connected to
        /// </summary>
        public OuterWallSide ConnectedSide { get; set; }
    }
}
