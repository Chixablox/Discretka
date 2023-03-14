using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ввод данных
            Console.WriteLine("Введите число вершин");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите число рёбер");
            int m = Convert.ToInt32(Console.ReadLine());
            int[] v1 = new int[m];
            int[] v2 =  new int[m];
            int[] ves = new int[m];
            for (var i = 0; i < m; i++)
            {
                Console.WriteLine("Введите первую вершину");
                v1[i] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите вторую вершину");
                v2[i] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите вес ребра");
                ves[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Введите вершину, путь от которой надо найти");
            int vn = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите вершину, путь до которой надо найти");
            int vk = Convert.ToInt32(Console.ReadLine());
            List<int> isp = new List<int>();
            //Массив с наименьшими путями от начальной точки до остальных(индекс - номер вершины, значение - длина пути)
            int[] put = new int[n + 1];
            for (var i = 1; i <= n; i++)
            {
                put[i] = 9999;
            }
            put[vn] = 0;
            int min = 9999;
            isp.Add(vn);
            //Алгоритм
            while (isp.IndexOf(vk)<0)
            {
                int v_1 = 0;
                int v_2 = 0;
                int number = 0;
                for (var i = 0; i < isp.Count; i++)
                {
                    for(var j = 0; j<m; j++)
                    {
                        if (((v1[j] == isp[i]) && (isp.Contains(v2[j]) == false)) || ((v2[j] == isp[i]) && (isp.Contains(v1[j]) == false)))
                        {
                            if (ves[j] + put[isp[i]] < min)
                            {
                                min = ves[j] + put[isp[i]];
                                v_1 = v1[j];
                                v_2 = v2[j];
                                number = j;
                            }
                        }
                    }
                }
                if ((isp.Contains(v_1) == true) && (isp.Contains(v_2) == false))
                {
                    isp.Add(v_2);
                    put[v_2] = min;
                }
                else if ((isp.Contains(v_2) == true) && (isp.Contains(v_1) == false))
                {
                    isp.Add(v_1);
                    put[v_1] = min;
                }
                min = 9999;
                ves[number] = 9999;
            }
            Console.WriteLine("" + put[vk]);
            Console.ReadLine();
        }
    }
}
