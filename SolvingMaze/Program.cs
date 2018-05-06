﻿using System;
using System.IO;

namespace SolvingMaze
{
    class Program
    {
        static void ReadMazeFile()
        {
            string path = @"c:\small.txt";
            string[] fileLine = File.ReadAllText(path).Trim().Split('\n');

            string [] mapwidthHeight = fileLine[0].Trim().Split(' ');
            int width = Convert.ToInt32(mapwidthHeight[0]);
            int height = Convert.ToInt32(mapwidthHeight[1]);

            string [] startXY = fileLine[1].Trim().Split(' '); ;
            int start_X = Convert.ToInt32(startXY[0])+3;
            int start_Y = Convert.ToInt32(startXY[1]);
            Console.WriteLine(start_X);
            Console.WriteLine(start_Y);
            string endXY = fileLine[2];
            int end_X = Convert.ToInt32(endXY[0]);
            int end_Y = Convert.ToInt32(endXY[1]);

            //deal with coordinates,
            // - make top left corner 0,0 based


            // row 3 will be the beginning  - walls
            //row 4 will be 1st row of paths
            for (int i = 3; i < fileLine.Length; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < fileLine[i].Length; j++)
                {
                    if (fileLine[i][j] == '0')
                    {
                        Console.Write(' ');
                    }
                    else if (fileLine[i][j] == '1')
                    {
                        Console.Write("#");
                    }

                    else if (i == start_X && j == start_Y)
                    {
                        Console.Write("S");
                    }
                } //END OF FOR
            }
        }

        static void Main(string[] args)
        {
            ReadMazeFile();
        }
    }
}
