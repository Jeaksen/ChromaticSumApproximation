using ChromaticSumApproximation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaticSumApproximation.Algorithms
{
    class SmallestFirst : ChromaticSumApproximator
    {
        public override int ApproximateChromaticSum(Graph graph)
        {
            var firstVertex = graph.Vertices.Min(v => v.Degree);

            throw new NotImplementedException();
        }
    }
}
