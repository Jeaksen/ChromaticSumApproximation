using ChromaticSumApproximation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaticSumApproximation.Algorithms
{
    public class ModifiedDSatur : ChromaticSumApproximator
    {
        public override int ApproximateChromaticSum(Graph graph)
        {
            var firstVertex = GetMaximalDegreeVertex(graph.Vertices);
            firstVertex.Color = GetFreeColorGreedily(firstVertex);
            int coloredVertices = 1;
            int chromaticSum = 1;

            while (coloredVertices < graph.Vertices.Count)
            {
                var nextVertex = FindNextVertex(graph);
                nextVertex.Color = GetFreeColorGreedily(nextVertex);
                chromaticSum += nextVertex.Color.Value;
                ++coloredVertices;
            }

            return chromaticSum;
        }

        private Vertex FindNextVertex(Graph graph)
        {
            var notColored = graph.NonColoredVertices;
            Vertex smallestRatioVertex = notColored.First();
            double smallestRatio = double.MaxValue;
            for (int i = 0; i < notColored.Count; ++i)
            {
                var greedyColor = GetFreeColorGreedily(notColored[i]);
                var unchangedCount = notColored[i].NonColoredNeighbors.Count(v => v.NeighborColors.Contains(greedyColor));
                var changedCount = notColored[i].NonColoredNeighbors.Count - unchangedCount;
                double ratio;
                if (unchangedCount == 0 && changedCount == 0)
                    ratio = 0;
                else
                    ratio = unchangedCount != 0 ? changedCount / (double)unchangedCount : smallestRatio;
                if (ratio < smallestRatio)
                {
                    smallestRatio = ratio;
                    smallestRatioVertex = notColored[i];
                }
            }
            return smallestRatioVertex;
        }
    }
}
