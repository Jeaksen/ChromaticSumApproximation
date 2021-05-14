using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChromaticSumApproximation.Model
{
    public class Graph
    {
        public List<Vertex> Vertices { get; set; } = new();

        public List<Vertex> NonColoredVertices => Vertices.Where(v => !v.IsColored).ToList();

        public int? ChromaticIndex { get; set; }

        public int? NumberOfEdges { get; set; }

        public int Size => Vertices.Count;

        public bool HasDefinedBounds => ChromaticIndex.HasValue && NumberOfEdges.HasValue;

        public int ChromaticSumLowerBound
        {
            get
            {
                if (!HasDefinedBounds)
                    throw new ArgumentNullException("The graph does not have defined chromatic sum bounds!");
                var boundEdges = Math.Ceiling(Math.Sqrt(8 * NumberOfEdges.Value));
                var boundIndex = Size + ChromaticIndex.Value * (ChromaticIndex.Value - 1) / 2.0;
                return (int)Math.Max(boundEdges, boundIndex);
            }
        }

        public int ChromaticSumUpperBound
        {
            get
            {
                if (!HasDefinedBounds)
                    throw new ArgumentNullException("The graph does not have defined chromatic sum bounds!");
                var boundEdgeVertex = Size + NumberOfEdges.Value;
                var boundEdges = Math.Floor(3 * (NumberOfEdges.Value + 1) / 2.0);
                var boundIndex = Math.Floor(Size * (ChromaticIndex.Value + 1) / 2.0);
                return (int)Math.Min(Math.Max(boundEdgeVertex, boundEdges), boundIndex);
            }
        }

        public void ResetColors()
        {
            foreach (var vertex in Vertices)
                vertex.ResetColor();
        }

        public void PrintVerticesAndEdges()
        {
            foreach (var vertex in Vertices)
                Console.WriteLine($"{vertex.Index + 1}: {string.Join(' ', vertex.Neighbors.Select(n => (n.Index + 1).ToString()))}");
        }

        public void PrintVerticesWithColors()
        {
            foreach (var vertex in Vertices)
                Console.WriteLine($"{vertex.Index + 1}: {vertex.Color}");
        }

        public void PrintGraphProperties()
        {
            Console.WriteLine($"Number of vertices: {Size}");
            if (HasDefinedBounds)
            {
                Console.WriteLine($"Number of edges: {NumberOfEdges}");
                Console.WriteLine($"Chromatic index: {ChromaticIndex}");

            }
        }
    }
}
