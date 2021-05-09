using ChromaticSumApproximation.Algorithms;
using ChromaticSumApproximation.Factories;
using System;
using System.Linq;

namespace ChromaticSumApproximation
{
    class Program
    {
        static void Main(string[] args)
        {
            var graphFactory = new GraphFactory();
            var graph = graphFactory.GraphFromAdjacencyList("../../../Graphs/graph_844.lst");

            foreach (var vertex in graph.Vertices)
                Console.WriteLine($"{vertex.Index + 1}: {string.Join(' ', vertex.Neighbors.Select(n => (n.Index + 1).ToString()))}");

            var algo = new SmallestFirst();
            var sum = algo.ApproximateChromaticSum(graph);

            Console.WriteLine($"Chromatic sum: {sum}");
            foreach (var vertex in graph.Vertices)
                Console.WriteLine($"{vertex.Index + 1} : {vertex.Color.Value}");
        }
    }
}
