using System.Collections.Generic;
using System.Linq;

namespace ChromaticSumApproximation.Model
{
    public class Vertex
    {
        public int Index { get; set; }

        public int? Color { get; set; }

        public List<Vertex> Neighbors { get; set; } = new();

        public List<int> NeighborColors
        {
            get
            {
                var colors = new HashSet<int>();
                foreach (var neighbor in Neighbors)
                    if (neighbor.Color.HasValue)
                        colors.Add(neighbor.Color.Value);
                return colors.ToList();
            }
        }

        public int SaturationDegree => NeighborColors.Count;

        public int Degree => Neighbors.Count;

        public int NonColoredDegree => Neighbors.Count(n => !n.Color.HasValue);

        public Vertex(int idx) => Index = idx;

        public void ResetColor() => Color = null;
    }
}
