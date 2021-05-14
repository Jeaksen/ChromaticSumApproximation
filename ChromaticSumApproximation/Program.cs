using ChromaticSumApproximation.Algorithms;
using ChromaticSumApproximation.Factories;
using ChromaticSumApproximation.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChromaticSumApproximation
{
    class Program
    {
        static void Main(string[] args)
        {
            var graphFactory = new GraphFactory();
            var graphs = new List<Graph>();

            // one graph with 208 vertices
            //graphs.Add(graphFactory.GraphFromAdjacencyList("../../../Graphs/graph_41669.lst"));
            // 170 big graphs, over 240 vertices
            //graphs.AddRange(graphFactory.GraphsFromAdjacencyLists("../../../Graphs/list_170_graphs.lst"));
            // 22 graphs with  different sizes and bounds calculation
            graphs.AddRange(graphFactory.GraphsFromAdjacencyLists("../../../Graphs/chidx_22_graphs.lst"));

            var smallestFirst = new SmallestFirst();
            var dSatur = new ModifiedDSatur();
            var sums = new List<Tuple<int, int>>();

            foreach (var graph in graphs)
            {
                //graph.PrintVerticesAndEdges();
                graph.PrintGraphProperties();
                var sumSF = smallestFirst.ApproximateChromaticSum(graph);
                graph.ResetColors();
                var sumDS = dSatur.ApproximateChromaticSum(graph);

                sums.Add(new Tuple<int, int>(sumSF, sumDS));
                if (graph.HasDefinedBounds)
                    Console.WriteLine($"Chromoctic sum bounds: [{graph.ChromaticSumLowerBound},{graph.ChromaticSumUpperBound}]");
                Console.WriteLine($"SmallestFirst chromatic sum : {sumSF}");
                Console.WriteLine($"ModifiedDSatur chromatic sum : {sumDS}");
                Console.WriteLine();
                //graph.PrintVerticesWithColors();
            }
        }
    }
}
