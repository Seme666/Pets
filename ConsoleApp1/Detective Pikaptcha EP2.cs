using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;


class Player
{
    static void Main()
    {
        int[,] labirint = ReadLabirint();

        cell s = new cell()
        {
            x = 1,
            y = 1,
        };
        cell t = new cell()
        {
            x = 3,
            y = 4,
        };

        int[,] distance = BFS(labirint,s,t);
        
        string side = Console.ReadLine();
    }
    static public int[,] BFS (int[,] labirint, cell s, cell t)
    {
        //Матрица дистанций от клетки s до остальных клеток
        int[,] distance = new int[labirint.GetLength(0) + 2, labirint.GetLength(1) + 2];
        for (int i = 0; i < labirint.GetLength(0); i++)
        {
            for (int j = 0; j < labirint.GetLength(1); j++)
            {
                if (labirint[i, j] == 0)
                    distance[i + 1, j + 1] = -1;
                else
                    distance[i + 1, j + 1] = 1;
            }
        }
        for (int i = 0; i < distance.GetLength(1); i++)
        {
            distance[i, 0] = 1;
            distance[0, i] = 1;
            distance[distance.GetLength(1)-1, i] = 1;
            distance[i,distance.GetLength(1)-1] = 1;
        }
        int counter = 0;
        foreach (int i in distance)
        {
            counter++;
            if ((counter - 1) % 5 == 0)
                Console.WriteLine();
            Console.Write(i);
        }

        int[][] steps = new int[4][]
        {
            new int[] {+1,0},
            new int[] {-1,0},
            new int[] {0,+1},
            new int[] {0,-1},
        };

        Queue<cell> q = new Queue<cell>();

        q.Enqueue(s); // Ввод начальной клетки в очередь

        distance[s.x, s.y] = 0;

        while (q.Count != 0)
        {
            cell c = q.Dequeue();
            int x = c.x;
            int y = c.y;
            foreach (int[] step in steps)
            {
                int dx = step[0];
                int dy = step[1];
                int _x = x + dx;
                int _y = y + dy;
                if (_x > distance.GetLength(0) || _y > distance.GetLength(1))
                if (distance[_x,_y]==-1)
                {
                    distance[_x, _y] = distance[x, y] + 1;
                    cell nc = new cell()
                    {
                        x = _x,
                        y = _y,
                    };
                    q.Enqueue(nc) ;
                }
            }
        }

        return (distance);
    }
    static public int[,] ReadLabirint()
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int width = int.Parse(inputs[0]); //Ширина лабиринта
        int height = int.Parse(inputs[1]); //Длина лабиринта
        int[,] labirint = new int[width, height]; //Матрица лабиринта
        string[] lines = new string[height]; //Строчки, в которых вводится лабиринт
        char freeCell = '0';
        //Замена строк на массив неявного графа
        for (int i = 0; i < height; i++)
        {
            lines[i] = Console.ReadLine();
            for (int j = 0; j < width; j++)
            {
                if (lines[i][j] == freeCell)
                    labirint[i, j] = 0;
                else
                    labirint[i, j] = 1;
            }
        }
        return (labirint);
    }
}
public struct cell
{
    public int x, y;
}