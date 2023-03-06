using System;
using System.Collections.Generic;

namespace Крускал
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
            /*//Массив для неиспользованных вершин
            List<int> nv = new List<int>();
            //Массив для использованных вершин
            List<int> iv = new List<int>();
            for (var i = 1; i <= m; i++)
            {
                nv.Add(i);
            }*/
            List<List<int>> drevo = new List<List<int>>();
            int min = 99999;
            int otvet = 0;
            int v_1 = 0;
            int v_2 = 0;
            int number = 0;
            int r = 0;
            int sch = 0;
            List<int> vrem = new List<int>();
            for (var i = 0; i < n; i++)
            {
                Console.WriteLine("Введите первую вершину");
                v1[i] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите вторую вершину");
                v2[i] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите вес ребра");
                len[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.Clear();
            while (r<m-1)
            {
                for (var i = 0; i < n; i++)
                {
                    if (len[i] < min)
                    {
                        min = len[i];
                        v_1 = v1[i];
                        v_2 = v2[i];
                        number = i;
                    }
                }
                for(var i=0; i<drevo.Count; i++)
                {
                    if(((drevo[i].Contains(v_1)==true) && (drevo[i].Contains(v_2)==false)) || ((drevo[i].Contains(v_2) == true) && (drevo[i].Contains(v_1) == false)))
                    {
                        if (drevo[i].Contains(v_1) == true) drevo[i].Add(v_2);
                        else drevo[i].Add(v_1);
                        otvet += min;
                        r = r + 1;
                        break;
                    }
                }
                for (var i = 0; i < drevo.Count; i++)
                {
                    if ((drevo[i].Contains(v_1) == true) && (drevo[i].Contains(v_2) == true))
                    {
                        sch += 1;
                    }
                }
                if (sch == 0)
                {
                    drevo.Add(new List<int>());
                    drevo[drevo.Count - 1].Add(v_1);
                    drevo[drevo.Count - 1].Add(v_2);
                    otvet += min;
                    r = r + 1;
                }
                for (var i = 0; i<drevo.Count; i++)
                {
                    for(var j=1+i; j<drevo.Count; j++)
                    {
                        for(var k = 0; k<drevo[i].Count; k++)
                        {
                            if (drevo[j].Contains(drevo[i][k]))
                            {
                                for(var l=0; l<drevo[j].Count; l++)
                                {
                                    if (drevo[j][l] != drevo[i][k])
                                    {
                                        vrem.Add(drevo[j][l]);
                                        drevo[j][l] = 0;
                                    }
                                    else
                                    {
                                        drevo[j][l] = 0;
                                    }
                                }
                            }
                        }
                        for (var z = 0; z < vrem.Count; z++)
                            drevo[i].Add(vrem[z]);
                        vrem.Clear();
                    }
                }
                Console.WriteLine(otvet);
                len[number] = 999999;
                min = 999999;
                sch = 0;
            }
            Console.WriteLine(otvet);
        }
    }
}
