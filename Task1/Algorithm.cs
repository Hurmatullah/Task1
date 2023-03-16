using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPI;

namespace Task1
{
    internal class Algorithm
    {
        // Number of vertices in the graph.
        static int Vertices = 5000;

        // Find the vertex with the minimum key from set of vertices.

        static int MinKey(int[] Key, bool[] MstSet)
        {
            // Initialize min value
            int Min = int.MaxValue, Min_index = -1;

            for (int v = 0; v < V; v++)
                if (MstSet[v] == false && Key[v] < Min)
                {
                    Min = Key[v];
                    Min_Index = v;
                }

            return min_index;
        }

        // A utility function to print the constructed MST stored in parent[]
        static void PrintMST(int[] Parent, int[,] Graph)
        {
            // Creating a file path
            string FilePath = Path.Combine(System.Environment.CurrentDirectory, "Result.txt");

            Console.WriteLine("Edge \tWeight");
            using (StreamWriter Writer = new StreamWriter(FilePath))
            {
                Writer.WriteLine("Edge - Vertices \t \tWeight");
                for (int i = 1; i < V; i++) {

                    // Printing it in console
                    Console.WriteLine(Parent[i] + " - " + i + "\t"
                                      + Graph[i, Parent[i]]);

                    // Write the values to the file
                    Writer.WriteLine(Parent[i] + " - " + i + "\t \t \t"
                                        + Graph[i, Parent[i]]);
                }
            }
        }

         // Function to construct and print MST for a graph
        public void PrimMST(int[,] Graph)
        {
            // Initiating MPI (Message Passing Interface)
            MPI.Environment.Run(Comm =>
            {
                // Initiating number of process and rank number
                int Size = Comm.Size;
                int Rank = Comm.Rank;
                int ChunckSize = Vertices / Size;
                int TagNumber = 110;
                int[] VerticesArray = Enumerable.Range(0,V).ToArray();
                int[] RecvBuffer = new int[ChunckSize];

                Comm.Allreduce(Vertices,MPI.Operation<int>.Add);
                // Array to store constructed MST
                int[] Parent = new int[Vertices];
                int[] Key = new int[Vertices];
                bool[] MstSet = new bool[Vertices];

                for (int i = 0; i < Vertices; i++)
                {
                    Key[i] = int.MaxValue;
                    MstSet[i] = false;
                }

                Key[0] = 0;
                Parent[0] = -1;

                // The MST will have V vertices
                for (int Count = 0; Count < Vertices - 1; Count++)
                {
                    // Pick thd minimum key vertex from the set of vertices not yet included in MST
                    int Unvisited = MinKey(Key, MstSet);

                    MstSet[Unvisited] = true;

                    for (int v = 0; v < Vertices; v++)

                        if (Graph[u, v] != 0 && MstSet[v] == false
                            && Graph[u, v] < Key[v])
                        {
                            Parent[v] = u;
                            Key[v] = Graph[u, v];
                        }
                }

                PrintMST(Parent, Graph);
            });
            
        }
    }
}