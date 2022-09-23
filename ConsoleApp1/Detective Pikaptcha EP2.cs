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
        string[] inputs = Console.ReadLine().Split(' ');
        int width = int.Parse(inputs[0]); //Ширина лабиринта
        int height = int.Parse(inputs[1]); //Длина лабиринта
        bool[,] used = new bool[width,height]; //Массив посещённых вершин
        string[] lines = new string[height];
        int[,] labirint = new int[width,height];
        int[] dst;
        char freeCell = '0';
        for (int i = 0; i < height; i++)
        {
            lines[i] = Console.ReadLine();
            for (int j = 0; j<width; j++)
            {
                if (lines[i][j] == freeCell)
                {
                    labirint[i,j] = 0;
                }
                else
                {
                    labirint[i,j] = 1;
                }
            }
        }
        

        string side = Console.ReadLine();
    }
    struct cell
    {
        int x, y;
    }
}