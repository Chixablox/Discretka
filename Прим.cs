using System;
using System.Collections.Generic;

namespace Алгоритм_Прима_новый_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число рёбер");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] v1 = new int[n];
            int[] v2 = new int[n];
            int[] len = new int[n];
            Console.WriteLine("Введите число вершин");
            int m = Convert.ToInt32(Console.ReadLine());
            //Массив для неиспользованных вершин
            List<int> nv = new List<int>();
            //Массив для использованных вершин
            List<int> iv = new List<int>();
            for (var i = 1; i <= m; i++)
            {
                nv.Add(i);
            }
            int min = 99999;
            int otvet = 0;
            int v_1 = 0;
            int v_2 = 0;
            for (var i=0; i<n; i++)
            {
                Console.WriteLine("Введите первую вершину");
                v1[i]= Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите вторую вершину");
                v2[i] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите вес ребра");
                len[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.Clear();
            iv.Add(1);
            nv.Remove(1);
            while (nv.Count>0)
            {
                for(var i=0; i<n; i++)
                {
                    if (((nv.Contains(v1[i])==true) && (iv.Contains(v2[i])==true)) || ((nv.Contains(v2[i])==true) && (iv.Contains(v1[i])==true)))
                    {
                        if (len[i] < min) {
                        min = len[i];
                        v_1 = v1[i];
                        v_2 = v2[i];
                            }
                    }
                }
                if (iv.Contains(v_1) == true)
                {
                    iv.Add(v_2);
                    nv.Remove(v_2);
                    otvet += min;
                }
                else
                {
                    iv.Add(v_1);
                    nv.Remove(v_1);
                    otvet += min;
                }
                min = 99999;
            }
            Console.WriteLine("Ответ: " + otvet);
        }
    }
}
