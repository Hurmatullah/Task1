using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class GraphGenerator
    {
        // For generating 5000 vertices and 1000000 edges you can create new project and run these below codes.

        //static void Main(string[] args)
        //{
        //    int numVertices = 5;
        //    int numEdges = 10;
        //    int[,] graph = GenerateGraph(numVertices, numEdges);

        //    // save the graph as a 2D array in a text file
        //    string filename = "graph.txt";
        //    using (StreamWriter sw = new StreamWriter(filename))
        //    {
        //        for (int i = 0; i < numVertices; i++)
        //        {
        //            for (int j = 0; j < numVertices; j++)
        //            {
        //                sw.Write(graph[i, j] + " ");
        //            }
        //            sw.WriteLine();
        //        }
        //    }

        //    // display the graph
        //    Console.WriteLine("Graph:");
        //    for (int i = 0; i < numVertices; i++)
        //    {
        //        for (int j = 0; j < numVertices; j++)
        //        {
        //            Console.Write(graph[i, j] + " ");
        //        }
        //        Console.WriteLine();
        //    }
        //}

        static int[,] GenerateGraph(int NumVertices, int NumEdges)
        {
            int[,] graph = new int[NumVertices, NumVertices];

            // add random edges with random weights
            Random rand = new Random();
            for (int i = 0; i < NumEdges; i++)
            {
                int u = rand.Next(NumVertices);
                int v = rand.Next(NumVertices);
                int weight = rand.Next(1, 11);
                graph[u, v] = weight;
                graph[v, u] = weight;
            }

            return graph;
        }
    }
}
