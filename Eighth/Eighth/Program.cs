using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eighth
{
    class Program
    {
        static bool[,] MyGraph;
        static bool[,] GraphGenerator(int size)
        {
            Random rnd = new Random();
            bool[,] Graph = new bool[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == j) { Graph[i, j] = false; }
                    if (i < j)
                    {
                        int t = rnd.Next(2);
                        if (t == 0) { Graph[i, j] = false; }
                        else { Graph[i, j] = true; }
                    }
                    if (i > j) { Graph[i, j] = Graph[j,i]; }
                }
            }
            return Graph;
        }
        static void ShowGraph (bool [,] grh)
        {
            string str = "  ";
            for (int d = 1; d <= grh.GetLength(1); d++)
            {

                str += d;
                str += " ";
            }
            Console.WriteLine(str);

            for (int i = 0; i < grh.GetLength(0); i++)
            {
                for (int j = 0; j < grh.GetLength(1); j++)
                {
                    if (grh[i, j] == true) Console.Write(1 + " ");
                    else Console.Write(0 + " ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            MyGraph = GraphGenerator(4);
            ShowGraph(MyGraph);
            Console.ReadLine();
        }
    }
}
