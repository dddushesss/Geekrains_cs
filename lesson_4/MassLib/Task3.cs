using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MassLib
{
    public class Task3
        {
            public int[] Mass { get; set; }

            public Task3(int size, int begin, int step)
            {
                Mass = new int[size];
                for (var i = 0; i < size; i++)
                {
                    Mass[i] = begin + step * i;
                }
                dic = new Dictionary<int, int>(Mass.Length);
                
                foreach (var num in Mass)
                {
                    if (dic.ContainsKey(num))
                    {
                        dic[num]++;
                    }
                    else
                    {
                        dic.Add(num, 1);
                    }
                }
            }

            public Dictionary<int, int> dic;
            
            public int Sum
            {
                get
                {
                    return Mass.Sum();
                }
            }

            public int MaxCount
            {
                get
                {
                    var maxNum = Mass.Max();
                    return Mass.Count(num => num == maxNum);
                }
            }

            public int[] Inverse()
            {
                var mass = new int[Mass.Length];
                for (var i = 0; i < Mass.Length; i++)
                {
                    mass[i] = -Mass[i];
                }
                return mass;
            }

            public void Multi(int a)
            {
                for (var i = 0; i < Mass.Length; i++)
                {
                    Mass[i] *= a;
                }
            }

            public static int DevidedByThreePairs(int[] mass)
            {
                var count = 0;
                for (var i = 0; i < mass.Length - 1; i++)
                {
                    if ((mass[i] % 3 == 0) && (mass[i + 1] % 3 != 0))
                    {
                        count++;
                    }
                    else if (mass[i + 1] % 3 == 0 && mass[i] % 3 != 0)
                    {
                        count++;
                    }
                }

                return count;
            }

            public static int[] MassFromFile(string fileName)
            {
                StreamReader sr;
                try
                {
                    sr = new StreamReader(fileName);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return new[] {0};
                }

                var s = sr.ReadLine();
                if (string.IsNullOrEmpty(s))
                    return new[] {0};
                s = s.Trim();
                s = Regex.Replace(s, @"\s+", " ");
                var mass = new int[s.Count(t => t.Equals(' ')) + 1];

                var i = 0;
                var j = 0;
                while (i < s.Length)
                {
                    var tmp = "";
                    while ((i < s.Length) && !s[i].Equals(' '))
                    {
                        tmp += s[i++];
                    }

                    ++i;

                    if (int.TryParse(tmp, out var num))
                    {
                        mass[j++] = num;
                    }
                }

                sr.Close();
                return mass;
            }
        }
}