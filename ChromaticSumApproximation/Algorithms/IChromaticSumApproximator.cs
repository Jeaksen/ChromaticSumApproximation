﻿using ChromaticSumApproximation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaticSumApproximation.Algorithms
{
    interface IChromaticSumApproximator
    {
        public int ApproximateChromaticSum(Graph graph);
    }
}
