using System;
using System.Collections.Generic;
using System.IO;

namespace SolvingMaze
{
    class Program
    {

        static int endX = 0;
        static int endY = 0;

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

            endX = end_X;
            endY = end_Y;

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
            if ((maze[end_Y, end_X] && maze[start_Y, start_X]) == false) //3 across 4 down, which 4 rows down 3 columwn right
            {
                solveMazeRecursively(maze, start_Y, start_X, -1);
            }

        } //end of  read maze file

        static bool solveMazeRecursively(bool[,] maze, int x, int y, int d)
        {
            bool ok = false;
            for (int i = 0; i < 4 && !ok; i++)
                if (i != d)
                    switch (i)
                    {
                        // 0 = up, 1 = right, 2 = down, 3 = left
                        case 0:
                            if (maze[y - 1, x] == false)
                                ok = solveMazeRecursively(maze, x, y - 1, 2);
                            break;
                        case 1:
                            if (maze[y, x + 1] == false)
                                ok = solveMazeRecursively(maze, x + 1, y, 3);
                            break;
                        case 2:
                            if (maze[y + 1, x] == false)
                                ok = solveMazeRecursively(maze, x, y + 1, 0);
                            break;
                        case 3:
                            if (maze[y, x - 1] == false)
                                ok = solveMazeRecursively(maze, x - 1, y, 1);
                            break;
                    }
            
            // check for end condition
            if (x == endX && y == endY)
                ok = true;
            // once we have found a solution, draw it as we unwind the recursion
            if (ok)
            {
                maze[y, x] = 'X';
                switch (d)
                {
                    case 0:
                        maze[y - 1, x] = 'X';
                        break;
                    case 1:
                        maze[y, x + 1] = 'X';
                        break;
                    case 2:
                        maze[y + 1, x] = 'X';
                        break;
                    case 3:
                        maze[y, x - 1] = 'X';
                        break;
                }
            }
            return ok;
        }

        static void Main(string[] args)
        {
            ReadMazeFile();
        }
    } //END OF PROGRAM CLASS


}
