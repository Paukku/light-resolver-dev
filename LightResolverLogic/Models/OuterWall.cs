using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LightResolver.Logic.Models
{
    public class OuterWall
    {
        /// <summary>
        /// TODO: set this value based on optimization results
        /// </summary>
        public WallType Type { get; set; } = WallType.NotSet;
        
        public string Resolve(string inputJson) {
            dynamic inputData = JsonConvert.DeserializeObject(inputJson);
            JObject outputData = JObject.Parse(inputJson);

            JArray? shelves = outputData["shelves"] as JArray;
            JArray? sections = outputData["sections"] as JArray;

            // Tarkista ensin kumpi puoli on elektroninen puoli
            GetOuterWallType(sections, shelves);

            foreach (JObject shelf in shelves)
            {
                // Add "type" and "side" fields based on your logic
                shelf["type"] = GetShelfType(shelf);
                shelf["side"] = GetShelfSide(shelf);
            }

            return JsonConvert.SerializeObject(outputData);
        }
        private string GetOuterWallType(JArray sections, JArray shelves) 
        {
            List<dynamic> leftSideLight = new List<dynamic>();
            List<dynamic> rightSideLight = new List<dynamic>();
            int lightTrue = 0;
            int sumLeftLights = 0;
            int sumRightLights = 0;
            List<dynamic> firstLightLeft = new List<dynamic> { new { row = 12, col = 12 } };
            List<dynamic> firstLightRight = new List<dynamic> { new { row = 0, col = 12 } };


            if (sections[0].Width == 30)
            {
                return "";
            }
            else
            {
                // Check if there are any lights on the left side
                for (int row = 0; row < sections.Count / 2; row++)
                {
                    for (int col = 0; col < sections[row].shelves.Count; col++)
                    {
                        if (sections[row].shelves[col].HasLight)
                        {
                            lightTrue++;
                            sumLeftLights++;

                            if (firstLightLeft[0].row > row)
                            {
                                firstLightLeft[0].row = row;

                                if (firstLightLeft[0].col > col)
                                {
                                    firstLightLeft[0].col = col;
                                }
                            }
                        }
                    }
                    leftSideLight.Add(new { row, lightTrue });
                    lightTrue = 0;
                }
            }

            // Check if there are any lights on the right side
            for (int row = sections.Count - 1; row >= sections.Count / 2; row--)
            {
                for (int col = 0; col < sections[row].shelves.Count; col++)
                {
                    if (sections[row].shelves[col].HasLight)
                    {
                        lightTrue++;
                        sumRightLights++;
                        if (firstLightRight[0].row < row)
                        {
                            firstLightRight[0].row = row;

                            if (firstLightRight[0].col > col)
                            {
                                firstLightRight[0].col = col;
                            }
                        }
                    }
                }
                rightSideLight.Add(new { row, lightTrue });
                lightTrue = 0;
            }

            if (sumLeftLights > 0 || sumRightLights > 0)
            {
                if (sumLeftLights > sumRightLights)
                {
                    return "A1";
                }
                else if (sumLeftLights < sumRightLights)
                {
                    return "A2";
                }
                else
                {
                    for (int i = 0; i < rightSideLight.Count; i++)
                    {
                        if (rightSideLight[i].lightTrue < leftSideLight[i].lightTrue)
                        {
                            return  "A1";
                        }
                        else if (rightSideLight[i].lightTrue > leftSideLight[i].lightTrue)
                        {
                            return "A2";

                        }
                        else
                        {
                            // Check which side has a lower column
                            if (firstLightLeft[0].col < firstLightRight[0].col)
                            {
                                return "A2";

                            }
                            else if (firstLightLeft[0].col > firstLightRight[0].col)
                            {
                                return "A1";
                            }
                            else
                            {
                                // Check rows, which side is farther from the center
                                if ((sections.Count / 2) - firstLightLeft[0].row > firstLightRight[0].row - (sections.Count / 2))
                                {
                                    return "A2";
                                }
                                else
                                {
                                    return "A1";
                                }
                            }
                        }
                    }
                }
            }
            return "";
        }
         private string GetShelfType(JObject shelf)
        {
            bool hasLight = shelf.Value<bool>("hasLight");
            string type = "E";
            if(!hasLight) {
                type = "F";
            }

            return type;
        }

        // Implement your logic to determine shelf side
        private string GetShelfSide(JObject shelf)
        {
            // Your logic here
            // For illustration purposes, let's assume "left" for even shelves and "right" for odd shelves
            int shelfIndex = shelf.Parent.IndexOf(shelf);
            return shelfIndex % 2 == 0 ? "left" : "right";
        }
        


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
