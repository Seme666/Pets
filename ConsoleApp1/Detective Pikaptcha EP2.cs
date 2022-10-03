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
        int labirintWidth = labirint.GetLength(0);
        int labirintHeight = labirint.GetLength(1);
        
        //Матрица дистанций от клетки s до остальных клеток
        int distanceWidth = labirint.GetLength(0)+2;
        int distanceHeight = labirint.GetLength(1)+2;

        int[,] distance = new int[distanceWidth, distanceHeight];
        for (int i = 0; i < labirintWidth; i++)
        {
            for (int j = 0; j < labirintHeight; j++)
            {
                if (labirint[i, j] == 0)
                    distance[i + 1, j + 1] = -2; //Непосещённая клетка
                else
                    distance[i + 1, j + 1] = -1; //Стена
            }
        }
        //Заполняем всё стенками вокруг лабиринта
        for (int i = 0; i < distanceHeight; i++)
        {
            distance[i, 0] = 1;
            distance[0, i] = 1;
            distance[distanceHeight - 1, i] = 1;
            distance[i, distanceHeight - 1] = 1;
        }

        PrintArray(distance);

        int[][] steps = new int[4][]
        {
            new int[] {+1,0},
            new int[] {-1,0},
            new int[] {0,+1},
            new int[] {0,-1},
        };

        Queue<cell> q = new Queue<cell>();

        q.Enqueue(s); // Ввод начальной клетки в очередь
        distance[s.x+1, s.y+1] = 0;

        while (q.Count != 0)
        {
            cell c = q.Dequeue();
            int x = c.x+1;
            int y = c.y+1;
            foreach (int[] step in steps)
            {
                int dx = step[0];
                int dy = step[1];
                int _x = x + dx;
                int _y = y + dy;
                if (distance[_x,_y]==-2)
                {
                    distance[_x, _y] = distance[x, y] + 1;
                    cell nc = new cell()
                    {
                        x = _x-1,
                        y = _y-1,
                    };
                    q.Enqueue(nc) ;
                }
            }
        }
        Console.WriteLine("-----------------");
        PrintArray(distance);
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
    static void PrintArray(int[,] array)
    {
        int counter = 0;
        foreach (int i in array)
        {
            counter++;
            if ((counter - 1) % array.GetLength(0) == 0)
                Console.WriteLine();
            Console.Write($"\t{i}");
        }
        Console.WriteLine();
    }
}

public struct cell
{
    public int x, y;
}