using System.Collections.Generic;
using System.Linq;

namespace ChromaticSumApproximation.Model
{
    public class Graph
    {
        public List<Vertex> Vertices { get; set; } = new();

        public List<Vertex> NonColoredVertices => Vertices.Where(v => !v.IsColored).ToList();

        public void ResetColors()
        {
            foreach (var vertex in Vertices)
                vertex.ResetColor();
        }
    }
}
