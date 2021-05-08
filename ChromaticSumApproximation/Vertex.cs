using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaticSumApproximation
{
    class Vertex
    {
        public uint? Color { get; set; }

        public LinkedList<Vertex> Neighbors { get; set; } = new();

        public List<uint> NeighborColors
        {
            get
            {
                var colors = new HashSet<uint>();
                foreach (var neighbor in Neighbors)
                    if (neighbor.Color.HasValue)
                        colors.Add(neighbor.Color.Value);
                return colors.ToList();
            }
        }

        public uint SaturationDegree => (uint)NeighborColors.Count;

        public uint Degree => (uint)Neighbors.Count;

        public uint NonColoredDegree => (uint)Neighbors.Count(n => !n.Color.HasValue);

    }
}
