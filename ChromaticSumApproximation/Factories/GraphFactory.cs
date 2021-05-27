using ChromaticSumApproximation.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChromaticSumApproximation.Factories
{
    public class GraphFactory
    {
        public Graph GraphFromAdjacencyList(string filename)
        {
            var lines = File.ReadAllLines(filename).Where(l => !string.IsNullOrEmpty(l.Trim())).ToArray();
            if (lines[0].Split(';').Length > 1)
                return GetGraphWithBoundsFromList(lines);
            else
                return GetGraphFromList(lines);
        }

        public List<Graph> GraphsFromAdjacencyLists(string filename)
        {
            var text = File.ReadAllText(filename);
            var lists = text.Split("\n\n");
            var graphs = new List<Graph>();

            foreach (var list in lists)
            {
                var split = list.Split(';');
                if (list.Split(';').Length > 1)
                    graphs.Add(GetGraphWithBoundsFromList(split[2], split[0], split[1]));
                else
                    graphs.Add(GetGraphFromList(list.Split('\n')));
            }

            return graphs;
        }

        private Graph GetGraphFromList(string[] lines)
        {
            if (lines.Length == 0)
                throw new ArgumentException("Adjacency List was empty");

            var graph = new Graph();
            for (int i = 0; i < lines.Length; ++i)
                graph.Vertices.Add(new Vertex(i));

            foreach (var line in lines)
            {
                var split = line.Split(": ");
                if (split.Length != 2)
                    throw new ArgumentException($"Adjacency List invalid format - {line}");

                var idx = int.Parse(split[0]) - 1;
                var neighborIdxs = split[1].Split(' ').Select(l => int.Parse(l) - 1);

                graph.Vertices[idx].Neighbors.AddRange(neighborIdxs.Select(i => graph.Vertices[i]));
            }

            return graph;
        }

        private Graph GetGraphWithBoundsFromList(string list, string number, string edges)
        {
            var graph = GetGraphFromList(list.Split('\n'));
            graph.ChromaticNumber = int.Parse(number);
            graph.NumberOfEdges = int.Parse(edges);

            return graph;
        }

        private Graph GetGraphWithBoundsFromList(string[] lines)
        {
            var split = lines[0].Split(';');
            lines[0] = split[2];
            var graph = GetGraphFromList(lines);
            graph.ChromaticNumber = int.Parse(split[0]);
            graph.NumberOfEdges = int.Parse(split[1]);

            return graph;
        }


    }
}
