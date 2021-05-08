using ChromaticSumApproximation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaticSumApproximation.Algorithms
{
    public abstract class ChromaticSumApproximator
    {
        protected int StartColor => 1;

        protected int GetFreeColorGreedily(Graph graph, Vertex vertex)
        {
            if (vertex.Color.HasValue)
                throw new ArgumentException("The vertex already has a color");

            var neighborColors = vertex.NeighborColors;
            int freeColor = StartColor;
            if (neighborColors.Count > 0)
            {
                neighborColors.Sort();
                foreach (var color in neighborColors)
                {
                    if (color != freeColor)
                        return freeColor;
                    freeColor++;
                }
            }
            return freeColor;
        }

        public abstract int ApproximateChromaticSum(Graph graph);
    }
}
