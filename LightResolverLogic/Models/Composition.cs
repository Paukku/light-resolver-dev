namespace LightResolver.Logic.Models
{
    public class Composition
    {
        public OuterWall LeftOuterWall { get; set; } = new OuterWall();

        public OuterWall RightOuterWall { get; set; } = new OuterWall();

        public IList<Section> Sections { get; set; } = new List<Section>();

        public Shelf ShelfAt(int section, int height) => Sections[section].Shelves[height];
    }
}
