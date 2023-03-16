using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // find the file path
            string FilePath = "graph2.txt";

            // Read the file contents into a 2D array
            DataFileReader Reader = new DataFileReader();

            int[,] Values = Reader.ReadArrayFromFile(FilePath);

            Console.ReadLine();
            int[,] Graph = Values;

            // Print the solution
            Algorithm Algo = new Algorithm();
            Algo.PrimMST(Graph);

        }
    }
}
