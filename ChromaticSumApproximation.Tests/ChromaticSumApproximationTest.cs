using System;
using Xunit;
using ChromaticSumApproximation.Algorithms;
using ChromaticSumApproximation.Model;

namespace ChromaticSumApproximation.Tests
{
    public class ChromaticSumApproximationTest
    {
        [Fact(DisplayName = "GetFreeColorGreedily finds color properly free color between neighbors")]
        public void Test1()
        {
            var graph = new Graph();
            var algo = new SmallestFirst();
            graph.Vertices.Add(new Vertex(0));
            graph.Vertices.Add(new Vertex(1));
            graph.Vertices.Add(new Vertex(2));
            graph.Vertices[0].Color = 1;
            graph.Vertices[1].Color = 3;
            graph.Vertices[2].Neighbors.Add(graph.Vertices[0]);
            graph.Vertices[2].Neighbors.Add(graph.Vertices[1]);

            Assert.Equal(2, algo.GetFreeColorGreedily(graph.Vertices[2]));
        }

        [Fact(DisplayName = "GetFreeColorGreedily finds color properly no free between neighbors")]
        public void Test2()
        {
            var graph = new Graph();
            var algo = new SmallestFirst();
            graph.Vertices.Add(new Vertex(0));
            graph.Vertices.Add(new Vertex(1));
            graph.Vertices.Add(new Vertex(2));
            graph.Vertices[0].Color = 1;
            graph.Vertices[1].Color = 2;
            graph.Vertices[2].Neighbors.Add(graph.Vertices[0]);
            graph.Vertices[2].Neighbors.Add(graph.Vertices[1]);

            Assert.Equal(3, algo.GetFreeColorGreedily(graph.Vertices[2]));
        }

        [Fact(DisplayName = "GetFreeColorGreedily finds color properly no colored neighbors")]
        public void Test3()
        {
            var graph = new Graph();
            var algo = new SmallestFirst();
            graph.Vertices.Add(new Vertex(0));
            graph.Vertices.Add(new Vertex(1));
            graph.Vertices.Add(new Vertex(2));
            graph.Vertices[2].Neighbors.Add(graph.Vertices[0]);
            graph.Vertices[2].Neighbors.Add(graph.Vertices[1]);

            Assert.Equal(1, algo.GetFreeColorGreedily(graph.Vertices[2]));
        }

        [Fact(DisplayName = "GetSmallestDegreeVertex finds vertex with minimal degree")]
        public void Test4()
        {
            var graph = new Graph();
            var algo = new SmallestFirst();

            graph.Vertices.Add(new Vertex(0));
            graph.Vertices.Add(new Vertex(1));
            graph.Vertices.Add(new Vertex(2));

            Assert.Equal(graph.Vertices[0].Index, algo.GetSmallestDegreeVertex(graph.Vertices).Index);

            graph.Vertices[0].Neighbors.Add(graph.Vertices[1]);
            graph.Vertices[1].Neighbors.Add(graph.Vertices[2]);

            Assert.Equal(graph.Vertices[2].Index, algo.GetSmallestDegreeVertex(graph.Vertices).Index);

            graph.Vertices[2].Neighbors.Add(graph.Vertices[0]);

            Assert.Equal(graph.Vertices[0].Index, algo.GetSmallestDegreeVertex(graph.Vertices).Index);
        }


    }
}
