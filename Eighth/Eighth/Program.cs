using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eighth
{
    /* 
       Программа находит все мосты в графе, заданном матрицей смежности.
       Графы создаются генератором тестов.
    */
    class Program
    {
        const int n = 5;//Число вершин в графе
        static bool[,] MyGraph;//Граф в виде матрицы смежности

        static int timer, count = 0;//count - количество мостов в графе, timer - перменная, для обхода графа в глубину
        static int[] tin = new int[n];
        static int[] fup = new int[n];
        static bool[] used = new bool[n];

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
                    if (i > j) { Graph[i, j] = Graph[j, i]; }
                }
            }
            return Graph;
        }//Генератор матриц смежности (он же генератор тестов)
        static void ShowGraph(bool[,] grh)
        {
            string str = "  ";
            for (int d = 1; d <= grh.GetLength(1); d++)
            {

                str += d;
                str += " ";
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(str);
            Console.ResetColor();

            for (int i = 0; i < grh.GetLength(0); i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(i + 1 + " ");
                Console.ResetColor();
                for (int j = 0; j < grh.GetLength(1); j++)
                {
                    if (grh[i, j] == true) Console.Write(1 + " ");
                    else Console.Write(0 + " ");
                }
                Console.WriteLine();
            }
        }//Показать граф в виде матрицы смежности
        static void DFS(int v, int p = -1)
        {
            used[v] = true;
            tin[v] = fup[v] = timer++;
            for (int i = 0; i < n; ++i)
            {
                if (MyGraph[v, i] == true)
                {
                    int to = i;
                    if (to == p) continue;
                    if (used[to]) fup[v] = Math.Min(fup[v], tin[to]);
                    else
                    {
                        DFS(to, v);
                        fup[v] = Math.Min(fup[v], fup[to]);

                        if (fup[to] > tin[v]) { v++; to++; Console.WriteLine("Мост: (" + v + " , " + to + ")"); v--; to--; count++; }
                    }
                }
            }
        }//Обход графа в глубину и поиск мостов
        static void FindBridges() //Поиск мостов
        {
            timer = 0;
            for (int i = 0; i < n; ++i)
            {
                used[i] = false;
            }
            for (int i = 0; i < n; ++i)
            {
                if (!used[i]) DFS(i);
            }
            if (count == 0) Console.WriteLine("Мостов нет");
        }
        static void Main(string[] args)
        {
            MyGraph = GraphGenerator(n);
            ShowGraph(MyGraph);
            FindBridges();
            Console.ReadLine();
        }
    }
}
