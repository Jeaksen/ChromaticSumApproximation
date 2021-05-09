using ChromaticSumApproximation.Algorithms;
using ChromaticSumApproximation.Factories;
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
            //var graph = graphFactory.GraphFromAdjacencyList("../../../Graphs/graph_41669.lst");
            var graphs = graphFactory.GraphsFromAdjacencyLists("../../../Graphs/list_170_graphs.lst");

            //foreach (var vertex in graph.Vertices)
            //Console.WriteLine($"{vertex.Index + 1}: {string.Join(' ', vertex.Neighbors.Select(n => (n.Index + 1).ToString()))}");
            var smallestFirst = new SmallestFirst();
            var dSatur = new ModifiedDSatur();
            var sums = new List<Tuple<int, int>>();

            foreach (var graph in graphs)
            {
                var sumSF = smallestFirst.ApproximateChromaticSum(graph);
                graph.ResetColors();
                var sumDS = dSatur.ApproximateChromaticSum(graph);

                sums.Add(new Tuple<int, int>(sumSF, sumDS));

                //Console.WriteLine($"SmallestFirst chromatic sum : {sumSF}");
                //Console.WriteLine($"ModifiedDSatur chromatic sum : {sumDS}");
                //Console.WriteLine();
            }
            Console.WriteLine(sums.Where(t => t.Item1 < t.Item2).Count());
            Console.WriteLine(sums.Where(t => t.Item1 <= t.Item2).Count());
            
            //for (int i = 0; i < 20; i++)
            //{
            //    graph.ResetColors();

            //    var algo = new SmallestFirst();
            //    var sum = algo.ApproximateChromaticSum(graph);

            //    Console.WriteLine($"Chromatic sum: {sum}");

            //    graph.ResetColors();

            //    var algo2 = new ModifiedDSatur();
            //    var sum2 = algo2.ApproximateChromaticSum(graph);

            //    Console.WriteLine($"Chromatic sum: {sum2}");
            //}
        }
    }
}
