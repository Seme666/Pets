using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Player
{
    void Main()
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int width = int.Parse(inputs[0]);
        int height = int.Parse(inputs[1]);

        int edgesCount = 0;
        char freeCell = '0';
        string[] lines = new string[height];


        for (int i = 0; i < height; i++)
        {
            lines[i] = Console.ReadLine();
            char[] line = lines[i].ToCharArray();
            foreach (char c in line)
            {
                if (c == freeCell)
                {
                    freeCell = (char)edgesCount;
                    edgesCount++;
                }
            }
        }
        string side = Console.ReadLine();

        for (int i = 0; i < height; i++)
        {

        }
    }
}
class Graph
{
    
}
class Lines
{ 
    
}
class Edge
{
    string Number;
    int VisitedCount;

    private Edge(string number)
    {
        this.Number = number;
    }

    public string Number1 { get => Number; set => Number = value; }
    public int VisitedCount1 { get => VisitedCount; set => VisitedCount = value; }
}