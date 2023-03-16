using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    internal class DataFileReader
    {
        public int[,] ReadArrayFromFile(string filePath)
        {
            // Read the file contents into a string array
            string[] lines = File.ReadAllLines(filePath);

            // Determine the size of the 2D array
            int Row_Count = lines.Length;
            int Col_Count = lines[0].Split(' ').Length;

            // Create the 2D array
            int[,] array = new int[Row_Count, Col_Count];

            // Fill the array with the file contents
            for (int i = 0; i < Row_Count; i++)
            {
                string[] Values = lines[i].Split(' ');
                for (int j = 0; j < colCount; j++)
                {
                    int Value;
                    if (int.TryParse(Values[j], out Value))
                    {
                        array[i, j] = Value;
                    }
                    else
                    {
                        array[i, j] = 0; // or throw an exception
                    }
                }
            }

            return array;
        }
    }
}
