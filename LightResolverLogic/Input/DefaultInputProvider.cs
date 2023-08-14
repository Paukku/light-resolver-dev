using LightResolver.Logic.Models;

namespace LightResolver.Logic.Input
{

    public class DefaultInputProvider : IInputProvider
    {
        public Composition Resolve()
        {
            var composition = new Composition();

            {
                var section = new Section();
                section.Shelves.Add(new Shelf { HasLight = true });
                section.Shelves.Add(new Shelf { HasLight = true });
                section.Shelves.Add(new Shelf { HasLight = true });
                section.Shelves.Add(new Shelf { HasLight = true });
                section.Shelves.Add(new Shelf { HasLight = true });
                composition.Sections.Add(section);
            }

            {
                var section = new Section();
                section.Shelves.Add(new Shelf { HasLight = true });
                section.Shelves.Add(new Shelf { HasLight = true });
                section.Shelves.Add(new Shelf { HasLight = true });
                section.Shelves.Add(new Shelf { HasLight = true });
                section.Shelves.Add(new Shelf { HasLight = true });
                composition.Sections.Add(section);
            }

            {
                var section = new Section();
                section.Shelves.Add(new Shelf { HasLight = true });
                section.Shelves.Add(new Shelf { HasLight = true });
                section.Shelves.Add(new Shelf { HasLight = true });
                section.Shelves.Add(new Shelf { HasLight = true });
                section.Shelves.Add(new Shelf { HasLight = true });
                composition.Sections.Add(section);
            }

            {
                var section = new Section();
                section.Shelves.Add(new Shelf { HasLight = true });
                section.Shelves.Add(new Shelf { HasLight = true });
                section.Shelves.Add(new Shelf { HasLight = true });
                section.Shelves.Add(new Shelf { HasLight = true });
                section.Shelves.Add(new Shelf { HasLight = true });
                composition.Sections.Add(section);
            }

            {
                var section = new Section();
                section.Shelves.Add(new Shelf { HasLight = true });
                section.Shelves.Add(new Shelf { HasLight = true });
                section.Shelves.Add(new Shelf { HasLight = true });
                section.Shelves.Add(new Shelf { HasLight = true });
                section.Shelves.Add(new Shelf { HasLight = true });
                composition.Sections.Add(section);
            }

            return composition;
        }
        public Composition Resolve<T>(T parameters)
        {
            throw new NotImplementedException();
        }
    }
}
