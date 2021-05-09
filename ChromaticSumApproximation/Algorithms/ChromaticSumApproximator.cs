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

        public int GetFreeColorGreedily(Vertex vertex)
        {
            if (vertex.IsColored)
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

        public Vertex GetMinimalDegreeVertex(List<Vertex> vertices)
        {
            return vertices.Aggregate((Vertex curMin, Vertex v) => (v.Degree < curMin.Degree ? v : curMin));
        }

        public Vertex GetMaximalDegreeVertex(List<Vertex> vertices)
        {
            return vertices.Aggregate((Vertex curMax, Vertex v) => (v.Degree > curMax.Degree ? v : curMax));
        }

        public abstract int ApproximateChromaticSum(Graph graph);
    }
}
