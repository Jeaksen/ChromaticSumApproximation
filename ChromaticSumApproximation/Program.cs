using ChromaticSumApproximation.Algorithms;
using ChromaticSumApproximation.Factories;
using ChromaticSumApproximation.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChromaticSumApproximation
{
    class Program
    {
        private static DirectoryInfo singleGraphs;
        private static DirectoryInfo listsGraphs;

        private static string GetSingleGraphPath(string name)
        {
            var file = singleGraphs.GetFiles(name).FirstOrDefault();
            if (file == default || !file.Exists)
                throw new ArgumentException($"Failed to find {name} in Graphs/Single directory");
            return file.FullName;
        }

        private static string GetGraphListsPath(string name)
        {
            var file = listsGraphs.GetFiles(name).FirstOrDefault();
            if (file == default || !file.Exists)
                throw new ArgumentException($"Failed to find {name} in Graphs/Lists directory");
            return file.FullName;
        }

        static void Main(string[] args)
        {
            string cwd = Directory.GetCurrentDirectory();
            DirectoryInfo graphDir = Directory.GetParent(Directory.GetParent(Directory.GetParent(cwd).FullName).FullName).GetDirectories("Graphs").FirstOrDefault();
            singleGraphs = graphDir.GetDirectories("Single").FirstOrDefault();
            listsGraphs = graphDir.GetDirectories("Lists").FirstOrDefault();
            if (singleGraphs == default || listsGraphs == default)
                throw new Exception("Failed to load the Single and Lists graphs directories!");

            var graphFactory = new GraphFactory();
            var graphs = new List<Graph>();

            // one graph with 208 vertices
            //graphs.Add(graphFactory.GraphFromAdjacencyList(GetSingleGraphPath("graph_41669.lst")));
            // simple test graph
            graphs.Add(graphFactory.GraphFromAdjacencyList(GetSingleGraphPath("graph_844.lst")));
            // 170 big graphs, over 240 vertices
            //graphs.AddRange(graphFactory.GraphsFromAdjacencyLists(GetGraphListsPath("list_170_graphs.lst")));
            // 22 graphs with  different sizes and bounds calculation
            //graphs.AddRange(graphFactory.GraphsFromAdjacencyLists(GetGraphListsPath("chidx_22_graphs.lst")));

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
                graph.PrintVerticesWithColors();
            }
        }
    }
}
