using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication17
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число рёбер");
            int m = Convert.ToInt32(Console.ReadLine());
            int[] v1 = new int[m];
            int[] v2 = new int[m];
            Console.WriteLine("Введите число вершин");
            int n = Convert.ToInt32(Console.ReadLine());
            for (var i = 0; i < m; i++)
            {
                Console.WriteLine("Введите первую вершину");
                v1[i] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите вторую вершину");
                v2[i] = Convert.ToInt32(Console.ReadLine());
            }
            int[] ver = new int[n];
            List<List<int>> comp = new List<List<int>>();
            comp.Add(new List<int>() { 1 });

            for (var i = 0; i < n; i++)
            {
                ver[i] = i + 1;
            }

            //Alg
            for (var i = 0; i < n; i++)
            {
                int p = -1;
                for (var k = 0; k < comp.Count(); k++)
                {
                    if (comp[k].Contains(i) == true)
                    {
                        p = k;
                    }
                }
                //Если компонента связности , содержащая i-ую вершину, есть
                if (p >= 0)
                {
                    for (var j = 0; j < m; j++)
                    {
                        if (v1[j] == i)
                        {
                            if (comp[p].Contains(v2[j]) == false)
                            {
                                comp[p].Add(v2[j]);
                            }
                        }
                        if (v2[j] == i)
                        {
                            if (comp[p].Contains(v1[j]) == false)
                            {
                                comp[p].Add(v1[j]);
                            }
                        }
                    }
                }

                //Если компонента связности отсутствует
                else
                {
                    comp.Add(new List<int>() { i });
                    for (var k = 0; k < comp.Count(); k++)
                    {
                        if (comp[k].Contains(i) == true)
                        {
                            p = k;
                        }
                    }
                    for (var j = 0; j < m; j++)
                    {
                        if (v1[j] == i)
                        {
                            if (comp[p].Contains(v2[j]) == false)
                            {
                                comp[p].Add(v2[j]);
                            }
                        }
                        if (v2[j] == i)
                        {
                            if (comp[p].Contains(v1[j]) == false)
                            {
                                comp[p].Add(v1[j]);
                            }
                        }
                    }
                }
                //Слияние древ, если вершины в компонентах совпадают
                for (var b = 0; b < comp.Count; b++)
                {
                    for (var j = 1 + b; j < comp.Count; j++)
                    {
                        List<int> vrem = new List<int>();
                        for (var k = 0; k < comp[b].Count; k++)
                        {
                            if (comp[j].Contains(comp[b][k]))
                            {
                                for (var l = 0; l < comp[j].Count; l++)
                                {
                                    if (comp[j][l] != comp[b][k])
                                    {
                                        vrem.Add(comp[j][l]);
                                        comp[j][l] = 0;
                                    }
                                    else
                                    {
                                        comp[j][l] = 0;
                                    }
                                }
                            }
                        }
                        for (var z = 0; z < vrem.Count; z++)
                            comp[b].Add(vrem[z]);
                    }
                }

            }

            //Удаление пустых (состоящих из нулей) компонент
            for (var i = 0; i < comp.Count; i++)
            {
                int p = 0;
                for (var j = 0; j < comp[i].Count; j++)
                {
                    if (comp[i][j] != 0)
                    {
                        p++;
                    }
                }
                if (p == 0)
                {
                    comp.RemoveAt(i);
                    i--;
                }
            }

            Console.Clear();
            Console.WriteLine("Всего" + comp.Count);
            for (var i = 0; i < comp.Count; i++)
            {
                Console.WriteLine(i+1 + "-ая компонента связности");
                for (var j = 0; j < comp[i].Count; j++)
                {
                    Console.Write(comp[i][j] + " ");
                }
                Console.WriteLine("");
            }
            Console.ReadLine();
        }
    }
}
