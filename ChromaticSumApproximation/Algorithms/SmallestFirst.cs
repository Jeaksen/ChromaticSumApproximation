using ChromaticSumApproximation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaticSumApproximation.Algorithms
{
    public class SmallestFirst : ChromaticSumApproximator
    {
        public override int ApproximateChromaticSum(Graph graph)
        {
            var firstVertex = GetSmallestDegreeVertex(graph.Vertices);
            firstVertex.Color = GetFreeColorGreedily(firstVertex);
            int coloredVertices = 1;
            int chromaticSum = 1;

            while (coloredVertices < graph.Vertices.Count)
            {
                var nextVertex = FindNextVertex(graph);
                nextVertex.Color = GetFreeColorGreedily(nextVertex);
                chromaticSum += nextVertex.Color.Value;
                coloredVertices++;
            }

            return chromaticSum;
        }

        private Vertex FindNextVertex(Graph graph)
        {
            var minSaturationVertices = GetMinSaturationVertices(graph);
            if (minSaturationVertices.Count == 1)
                return minSaturationVertices.First();
            else
                return GetSmallestDegreeVertex(minSaturationVertices);
        }

        private List<Vertex> GetMinSaturationVertices(Graph graph)
        {
            var notColored = graph.Vertices.Where(v => !v.IsColored).ToList();
            int minSatDegree = notColored.Min(v => v.SaturationDegree);
            return notColored.Where(v => v.SaturationDegree == minSatDegree).ToList();
        }
    }
}
