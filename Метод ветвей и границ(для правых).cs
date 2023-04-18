using System;
using System.Collections.Generic;

namespace Метод_ветвей_и_границ
{
    class Program
    {
        static void Main(string[] args)
        {
            //Заполнение матрицы смежности(изнач)
            Console.WriteLine("Введите число вершин");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите число рёбер");
            int[,] smez = new int[n + 1, n + 1];
            for (var i = 1; i < n + 1; i++)
            {
                for (var j = 1; j < n + 1; j++)
                {
                    Console.Clear();
                    for (var k = 1; k < n + 1; k++)
                    {
                        for (var l = 1; l < n + 1; l++)
                        {
                            Console.Write(smez[k,l] + "\t");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("Введите вес ребра между вершинами " + i + " и " + j);
                    int value = Convert.ToInt32(Console.ReadLine());
                    smez[i, j] = value;
                }
            }
            Console.Clear();
            for (var i = 1; i < n + 1; i++)
            {
                for (var j = 1; j < n + 1; j++)
                {
                    if ((i == j) || (smez[i, j] == 0))
                    {
                        smez[i, j] = 9999;
                    }
                }
            }
            for (var j = 0; j < n + 1; j++)
            {
                smez[0, j] = j;
                smez[j, 0] = j;
            }
            int min = 9999;
            int put = 0;
            //Алгоритм
            for (var k = 0; k < n - 1; k++)
            {
                //Минимумы в строках
                for (var i = 1; i < n + 1; i++)
                {
                    if (smez[i, 0] == 10000)
                    {
                        continue;
                    }
                    for (var j = 1; j < n + 1; j++)
                    {
                        if (smez[i, j] < min)
                        {
                            min = smez[i, j];
                        }
                    }
                    for (var j = 1; j < n + 1; j++)
                    {
                        if ((smez[i, j] != 9999) && (smez[i, j] != 10000))
                            smez[i, j] = smez[i, j] - min;
                    }
                    put = put + min;
                    min = 9999;
                }
                //Минимумы в столбцах
                for (var j = 1; j < n + 1; j++)
                {
                    if (smez[0, j] == 10000)
                    {
                        continue;
                    }
                    for (var i = 1; i < n + 1; i++)
                    {
                        if (smez[i, j] < min)
                        {
                            min = smez[i, j];
                        }
                    }
                    for (var i = 1; i < n + 1; i++)
                    {
                        if ((smez[i, j] != 9999) && (smez[i, j] != 10000))
                            smez[i, j] = smez[i, j] - min;
                    }
                    put = put + min;
                    min = 9999;
                }
                int minstolb = 9999;
                int minstroka = 9999;
                int maxstep = -1;
                int v1 = 0;
                int v2 = 0;
                //Выбираем степени нулей
                for (var i = 1; i < n + 1; i++)
                {
                    if (smez[i, 0] == 10000)
                    {
                        continue;
                    }
                    for (var j = 1; j < n + 1; j++)
                    {
                        if (smez[i, j] == 0)
                        {
                            for (var c = 1; c < n + 1; c++)
                            {
                                if ((smez[i, c] < minstroka) && (c != j))
                                {
                                    minstroka = smez[i, c];
                                }
                                if ((smez[c, j] < minstolb) && (c != i))
                                {
                                    minstolb = smez[c, j];
                                }
                            }
                            if ((minstolb + minstroka) > maxstep)
                            {
                                maxstep = minstroka + minstolb;
                                v1 = i;
                                v2 = j;
                            }
                            minstroka = 9999;
                            minstolb = 9999;
                        }
                    }
                }
                //Взаимодействие с этой максимальной степенью
                if (smez[v2, v1] != 9999)
                {
                    smez[v2, v1] = 9999;
                }
                for (var i = 0; i < n + 1; i++)
                {
                    smez[v1, i] = 10000;
                    smez[i, v2] = 10000;
                }
            }
            Console.WriteLine("Путь: " + put);
            Console.ReadLine();
        }
    }
}
