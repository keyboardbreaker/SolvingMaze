using System;
using System.Collections.Generic;
using System.IO;

namespace SolvingMaze
{
    class Program
    {
        static void ReadMazeFile()
        {
            string path = @"c:\small.txt";
            string[] fileLine = File.ReadAllText(path).Trim().Split('\n');

            string[] mapwidthHeight = fileLine[0].Trim().Split(' ');
            int width = Convert.ToInt32(mapwidthHeight[0]);
            int height = Convert.ToInt32(mapwidthHeight[1]);

            string[] startXY = fileLine[1].Trim().Split(' ');
            int start_X = Convert.ToInt32(startXY[0]);
            int start_Y = Convert.ToInt32(startXY[1]);

            string[] endXY = fileLine[2].Trim().Split(' '); ;
            int end_X = Convert.ToInt32(endXY[0]);
            int end_Y = Convert.ToInt32(endXY[1]);

            bool[,] maze = new bool[height, width];// rows by columns

            for (int i = 3; i < fileLine.Length; i++) //rows 9 
            {
                for (int j = 0; j < width; j++) //columns
                {
                    string[] mazeLine = fileLine[i].Trim().Split(' ');
                    maze[i - 3, j] = Convert.ToBoolean(Convert.ToInt32(mazeLine[j]));
                    Console.Write(maze[i - 3, j]);
                } //END OF FOR
                Console.WriteLine();
            } //END OF OUTER FOR

            //SOLVE MAZE
            //start_X, start_Y
            if(maze[end_Y,end_X]   == false) //3 across 4 down, which 4 rows down 3 columwn right
            {
                Console.ReadLine();
            }


        }

        static void Main(string[] args)
        {
            ReadMazeFile();
        }
    } //END OF PROGRAM CLASS


}
