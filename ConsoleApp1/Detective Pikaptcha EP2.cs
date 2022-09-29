using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;


class Player
{
    static void Main(cell s, cell t)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int width = int.Parse(inputs[0]); //Ширина лабиринта
        int height = int.Parse(inputs[1]); //Длина лабиринта

        int[,] steps = { { +1, 0 }, { -1, 0 }, { 0, +1 }, { 0, -1 } };
        
        int[,] labirint = new int[width,height]; //Матрица лабиринта
        int[,] distance = new int[width, height]; //Матрица дистанций от клетки s до остальных клеток
        char freeCell = '0';
        
        string[] lines = new string[height]; //Строчки, в которых вводится лабиринт
        //Замена строк на массив неявного графа
        for (int i = 0; i < height; i++) 
        {
            lines[i] = Console.ReadLine();
            for (int j = 0; j<width; j++)
            {
                if (lines[i][j] == freeCell)
                    labirint[i, j] = 0;
                else
                    labirint[i, j] = 1;
            }
        }

        Queue<cell> q = new Queue<cell>();
        q.Enqueue(s); // Ввод начальной клетки в очередь

        distance[s.x, s.y] = 0;

        while (q.Count!=0)
        {
            //int[] [x, y] = { 1, 0 };
        }
        

        string side = Console.ReadLine();
    }

}
public struct cell
{
    public int x, y;
}