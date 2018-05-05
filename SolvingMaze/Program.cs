using System;
using System.IO;

namespace SolvingMaze
{
    class Program
    {
        static void ReadMazeFile()
        {
            string path = @"c:\small.txt";
            string[] fileLine = File.ReadAllText(path).Trim().Split('\n');

            string mapWidthHeight = fileLine[0];
            string startXY = fileLine[1];
            string endXY = fileLine[2];

            for (int i = 3; i < fileLine.Length; i++)
            {
                //Console.WriteLine(fileLine[i]); //shows one line
                for(int j = 0; j <  fileLine[i].Length; j++)
                {
                    Console.WriteLine(fileLine[i][j]); //shows each character of each line
                }
            }

        }

        static void Main(string[] args)
        {
            ReadMazeFile();
        }
    }
}
