using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            //vvod dannyx
            Console.WriteLine("Введите число вершин");
            int n = Convert.ToInt32(Console.ReadLine());
            int[,] isxod = new int[n + 1, n + 1];
            int[,] promez = new int[n + 1, n + 1];
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
                promez[v1, v2] = weight; 
            }
            for (var i = 1; i < n + 1; i++)
            {
                for (var j = 1; j < n + 1; j++)
                {
                    if ((isxod[i, j] == 0) && (i!=j))
                    {
                        isxod[i, j] = 9999;
                        promez[i, j] = 9999;
                    }
                }
            }
            //algoritm
            for (var i = 1; i <= n; i++)
            {
                for (var j = 1; j <= n; j++)
                {
                    for (var k = 1; k <= n; k++)
                    {
                        int minr = Math.Min(promez[j,k], promez[j,i] + promez[i,k]);
                        otvet[j, k] = minr;
                    }
                }
                //Замена промежуточной матрицы
                for (var j = 1; j < n + 1; j++)
                {
                    for (var k = 1; k < n + 1; k++)
                    {
                        promez[j, k] = otvet[j, k];
                    }
                }
            }
            //Наводим Красоту(нумеруем столбцы и строки)
            for (var j = 1; j <= n; j++)
            {
                otvet[0, j] = j;
                otvet[j, 0] = j;
            }
            //Выводим ответ
            for (var i = 0; i <= n; i++)
            {
                for (var j = 0; j <= n; j++)
                {
                    Console.Write(otvet[i, j] + "\t");
                }
                Console.WriteLine("");
            }
            Console.ReadLine();
        }
    }
}
