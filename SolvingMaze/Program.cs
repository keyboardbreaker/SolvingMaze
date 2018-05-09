using System;
using System.IO;

namespace SolvingMaze
{
    class Program
    {
        static int GlobalWidth = 0;
        static int GlobalHeight = 0;
        static int startX = 0;
        static int startY = 0;
        static int endX = 0;
        static int endY = 0;

        static string[] ReadMazeFile()
        {
            //Console.WriteLine(Directory.GetCurrentDirectory());
            string path = @"..\..\Maps\example.txt";
            string path1 = @"..\..\Maps\small.txt";
            string path2 = @"..\..\Maps\input.txt";
            string path3 = @"..\..\Maps\medium_input.txt";
            string path4 = @"..\..\Maps\sparse_medium.txt";
            string path5 = @"..\..\Maps\large_input.txt";

            //change the path here to try the other files
            try
            {
                string[] fileLine = File.ReadAllText(path).Trim().Split('\n');
                return fileLine;
            } catch (IOException e)
            {
                Console.WriteLine(e);
                throw;
            }

        } //end of  read maze file

        void Header(string[] fileLine)
        {
            string[] mapwidthHeight = fileLine[0].Trim().Split(' ');
            int width = Convert.ToInt32(mapwidthHeight[0]);
            int height = Convert.ToInt32(mapwidthHeight[1]);
            GlobalWidth = width;
            GlobalHeight = height;

            string[] startXY = fileLine[1].Trim().Split(' ');
            int start_X = Convert.ToInt32(startXY[0]);
            int start_Y = Convert.ToInt32(startXY[1]);
            startX = start_X;
            startY = start_Y;

            string[] endXY = fileLine[2].Trim().Split(' '); ;
            int end_X = Convert.ToInt32(endXY[0]);
            int end_Y = Convert.ToInt32(endXY[1]);
            endX = end_X;
            endY = end_Y;
        }

        void DrawMaze(string[] fileLine)
        {
            char[,] maze = new char[GlobalHeight, GlobalWidth];// rows by columns

            //SEPERATE THE MAZE FROM HEADER
            for (int i = 3; i < fileLine.Length; i++)
            {
                for (int j = 0; j < GlobalWidth; j++) //columns
                {
                    string[] mazeLine = fileLine[i].Trim().Split(' ');
                    maze[i - 3, j] = Convert.ToChar(mazeLine[j]);
                } //END OF FOR
            } //END OF OUTER FOR

            //SOLVE MAZE
            SolveMazeRecursively(maze, startY, startX, -1);

            //DRAW MAZE
            for(int i=0; i<GlobalHeight; i++)
            {
                for(int j=0; j< GlobalWidth; j++)
                {
                    if (startX == i && startY == j)
                        Console.Write('S');
                    else if (endY == i && endX == j)
                        Console.Write('E');
                    else if (maze[i, j] == '1')
                        Console.Write('#');
                    else if (maze[i, j] == '0')
                        Console.Write(' ');
                    else
                        Console.Write(maze[i, j]);
                } //END OF FOR
                Console.WriteLine();
            } //END OF INNER FOR
        } //END OF DRAW MAZE

        static bool SolveMazeRecursively(char[,] maze, int x, int y, int d)
        {
            bool ok = false;
            for (int i = 0; i < 4 && !ok; i++)
                if (i != d) //if i doesnt equal going backwards on a path it's already stepped
                    switch (i)
                    {
                        // 0 = up, 1 = right, 2 = down, 3 = left
                        case 0:
                            if (maze[y - 1, x] == '0')
                                ok = SolveMazeRecursively(maze, x, y - 1, 2);
                            break;
                        case 1:
                            if (maze[y, x + 1] == '0')
                                ok = SolveMazeRecursively(maze, x + 1, y, 3);
                            break;
                        case 2:
                            if (maze[y + 1, x] == '0')
                                ok = SolveMazeRecursively(maze, x, y + 1, 0);
                            break;
                        case 3:
                            if (maze[y, x - 1] == '0')
                                ok = SolveMazeRecursively(maze, x - 1, y, 1);
                            break;
                    }
            
            // check for end condition
            if (x == endX && y == endY)
                ok = true;
            // once we have found a solution, draw it as we unwind the recursion
            //this goes from end to start
            if (ok)
            {
                maze[y, x] = 'X';
                switch (d)
                {
                    case 0:
                        maze[y - 1, x] = 'X';
                        //Console.WriteLine("up");
                        break;
                    case 1:
                        maze[y, x + 1] = 'X';
                       // Console.WriteLine("right");
                        break;
                    case 2:
                        maze[y + 1, x] = 'X';
                        //Console.WriteLine("down"); //
                        break;
                    case 3:
                        maze[y, x - 1] = 'X';
                        //Console.WriteLine("left");
                        break;
                }
            }
            return ok;
        }

        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.Header(ReadMazeFile());
            prog.DrawMaze(ReadMazeFile());

        }
    } //END OF PROGRAM CLASS


}
