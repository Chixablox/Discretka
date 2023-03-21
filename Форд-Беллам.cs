using System;

namespace Алгоритм_Форда_Беллмана
{
    class Program
    {
        static void Main(string[] args)
        {
            //vvod dannyx
            Console.WriteLine("Введите число вершин");
            int n = Convert.ToInt32(Console.ReadLine());
            int[,] isxod = new int[n + 1, n + 1];
            int[,] otvet = new int[n + 1, n + 1];
            Console.WriteLine("Введите число рёбер");
            int m = Convert.ToInt32(Console.ReadLine());
            for (var i = 0; i < m; i++)
            {
                Console.WriteLine("Введите первую вершину");
                int v1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите вторую вершину");
                int v2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите вес ребра");
                int weight = Convert.ToInt32(Console.ReadLine());
                isxod[v1, v2] = weight;
            }
            Console.WriteLine("Введите вершину, путь от которой надо искать");
            int x = Convert.ToInt32(Console.ReadLine());
            for (var i = 1; i < n + 1; i++)
            {
                for (var j = 1; j < n + 1; j++)
                {
                    if (isxod[i, j] == 0)
                    {
                        isxod[i, j] = 9999;
                    }
                }
            }
            //Работа с алгоритмом
            //Заполнение первого столбца
            for(var i = 1; i<n+1; i++)
            {
                if (i != x)
                    otvet[i, 1] = 9999;
                else
                    otvet[i, 1] = 0;
            }
            for(var i = 1; i<n+1; i++)
            {
                otvet[x, i] = 0;
            } 
            //Подсчёт ответа
            for(var i = 1; i<n; i++)
            {
                int min = 9999;
                for(var j=2; j<n+1; j++)
                {
                    for (var k = 1; k < n + 1; k++)
                    {
                        if (otvet[k, i] + isxod[k, j] < min)
                        {
                            min = otvet[k, i] + isxod[k, j];
                        }
                    }
                    otvet[j, i+1] = min;
                    min = 9999;
                }
            }
            //Вывод ответа
            //Вывод матрицы
            for(var i=1; i<n+1; i++)
            {
                for (var j= 1; j<n+1; j++)
                {
                    Console.Write(otvet[i,j]+"\t");
                }
                Console.WriteLine();
            }
            //Вывод кратчайших путей
            for(var i=2; i<n+1; i++)
            {
                Console.WriteLine("Кратчайший путь из вершины " + x + " в вершину " + i + " равен: " + otvet[i,n]);
            }
            Console.ReadLine();
        }
    }
}
