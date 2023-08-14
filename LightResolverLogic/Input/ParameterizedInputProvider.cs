using LightResolver.Logic.Models;

namespace LightResolver.Logic.Input
{
    /// <summary>
    /// This provider can be used to construct quickly different compositions.
    /// Parameters are kept minimalistic for ease of use. Use Type ParameterizedInput as parameter which wraps all arguments.
    /// </summary>
    public class ParameterizedInputProvider : IInputProvider
    {
        public Composition Resolve()
        {
            throw new NotImplementedException();
        }

        public Composition Resolve<T>(T parameters)
        {
            if (parameters is not ParameterizedInput input)
                throw new InvalidOperationException("Could not resolve parameterized input for composition.");

            var composition = new Composition();

            for (int i = 0; i < input.Sections.Length; i++)
            {
                var section = new Section { Width = input.Sections[i] };

                for (int j = 0; j < input.Shelves; j++)
                {
                    section.Shelves.Add(new Shelf { Width = input.Sections[i] });
                }
                composition.Sections.Add(section);
            }

            foreach (var light in input.Lights)
            {
                composition.Sections[light.Section].Shelves[light.Height].HasLight = true;
            }

            composition.LeftOuterWall = new OuterWall { AdjacentSection = composition.Sections[0] };
            composition.RightOuterWall = new OuterWall { AdjacentSection = composition.Sections[composition.Sections.Count - 1] };

            return composition;
        }
    }

    public class ParameterizedInput
    {
        /// <summary>
        /// Describes number of sections and their widths, this is also interpreted as order from left to right.
        /// </summary>
        public int[] Sections { get; }
        /// <summary>
        /// Number of shelves per section, all sections have same number of shelves.
        /// 2 is minimum (top and bottom).
        /// </summary>
        public int Shelves { get; }

        /// <summary>
        /// Describes which shelves have lights.
        /// </summary>
        public (int Section, int Height)[] Lights { get; }

        public ParameterizedInput(int[] sections, int shelves, (int section, int height)[] lights)
        {
            Sections = sections;
            Shelves = shelves;
            Lights = lights;
        }
    }
}
