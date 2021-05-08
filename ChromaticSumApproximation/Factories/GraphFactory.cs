using ChromaticSumApproximation.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaticSumApproximation.Factories
{
    public class GraphFactory
    {
        public Graph GraphFromAdjacencyList(string filename)
        {
            var lines = File.ReadAllLines(filename).Where(l => !string.IsNullOrEmpty(l.Trim())).ToArray();
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
    }
}
