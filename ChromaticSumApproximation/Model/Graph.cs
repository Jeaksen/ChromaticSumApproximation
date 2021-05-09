using System.Collections.Generic;
using System.Linq;

namespace ChromaticSumApproximation.Model
{
    public class Graph
    {
        public List<Vertex> Vertices { get; set; } = new();

        public void ResetColors()
        {
            foreach (var vertex in Vertices)
                vertex.ResetColor();
        }
    }
}
