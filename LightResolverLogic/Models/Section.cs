namespace LightResolver.Logic.Models
{
    /// <summary>
    /// 'A section' is a set of shelves and other accessories between two walls (outer and/or inner).
    /// </summary>
    public class Section
    {
        /// <summary>
        /// Sections should only have widths 30, 60, 90, 120
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Shelves are arranged in a section from bottom to top. First entry in the list is the bottom shelf.
        /// </summary>
        public IList<Shelf> Shelves { get; set; } = new List<Shelf>();
    }
}
