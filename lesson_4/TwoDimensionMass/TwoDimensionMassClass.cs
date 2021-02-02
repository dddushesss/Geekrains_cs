using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace TwoDimensionMass
{
    public class TwoDimensionMassClass
    {
        public int[,] Mass { get; set; }
        private int x, y;

        public TwoDimensionMassClass(string filename)
        {
            if (File.Exists(filename))
            {
                var sr = File.ReadAllLines(filename);
                for (var i = 0; i < sr.Length; i++)
                {
                    sr[i] = Regex.Replace(sr[i], @"\s+", " ").Trim();
                    
                }

                x = sr.Length;
                y = sr[0].Split(' ').Length;
                Mass = new int[x, y];
                for (var i = 0; i < sr.Length; i++)
                {
                    var tmp = sr[i].Split(' ');
                    for (var j = 0; j < tmp.Length; j++)
                    {
                        Mass[i, j] = int.Parse(tmp[j]);
                    }
                }
            }
            else

            {
                Console.WriteLine("Файл не найден");
                Mass = new int[0, 0];
            }
        }

        public TwoDimensionMassClass(int lengthX, int lengthY)
        {
            Mass = new int[lengthX, lengthY];

            var rnd = new Random();
            for (var i = 0; i < lengthX; i++)
            {
                for (var j = 0; j < lengthY; j++)
                {
                    Mass[i, j] = rnd.Next(-10, 10);
                }
            }
        }

        public int Max
        {
            get
            {
                var max = int.MinValue;
                foreach (var num in Mass)
                {
                    if (max < num)
                    {
                        max = num;
                    }
                }

                return max;
            }
        }

        public int Min
        {
            get
            {
                var min = int.MaxValue;
                foreach (var num in Mass)
                {
                    if (min > num)
                    {
                        min = num;
                    }
                }

                return min;
            }
        }

        public void IndexOfMax(ref int xMax, ref int yMax)
        {
            var max = int.MinValue;
            for (var i = 0; i < x; i++)
            {
                for (var j = 0; j < y; j++)
                {
                    if (max < Mass[i, j])
                    {
                        max = Mass[i, j];
                        xMax = i;
                        yMax = j;
                    }
                }
            }
        }

        public void Save(string filename)
        {
            var path = filename.Remove(filename.LastIndexOf('\\'));
            var dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            var s = "";
            for (var i = 0; i < x; i++)
            {
                for (var j = 0; j < y; j++)
                {
                    s += $"{Mass[i, j]} ";
                }

                s += '\n';
            }

            s = s.Remove(s.Length - 1);
            using (var fstream = new FileStream($"{filename}", FileMode.OpenOrCreate))
            {
                var array = System.Text.Encoding.Default.GetBytes(s);
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("Массив записан в файл");
            }
        }

        public int Sum()
        {
            return Mass.Cast<int>().Sum();
        }

        public int SumOfNumMoreThen(int a)
        {
            return Mass.Cast<int>().Where(num => num > a).Sum();
        }
    }
}