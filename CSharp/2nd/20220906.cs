using System;
using System.Collections.Generic;

namespace _202209006
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1번
            dynamic[] source = {1, 9, 3, 10, 5};
            dynamic[] target = {5, 10, 3, 9, 1};

            dynamic[] help = { };
            int i = 0;
            
            Rary(source, target);

            foreach(dynamic item in target)
            {
                source[i] = item;
                Console.WriteLine(item);
                i++;
            }
            #endregion

            #region 2번
            List<int> intList = new List<int>();
            List<string> stringList = new List<string>();
            for (int j = 0; j < 5; j++)
            {
                intList.Add(j);
                stringList.Add("alla" + j);
            }

            intList.Remove(3);
            stringList.Remove("alla3");
            intList.RemoveAt(2);
            stringList.RemoveAt(2);
            #endregion

            #region 3번
            Stack<int> a = new Stack<int>();
            Stack<string> b = new Stack<string>();

            Random random = new Random();
            for (int j = 0; j < 5; j++)
            {
                a.Push(random.Next(0, 9));
            }
            for (int j = 0; j < 3; j++)
            {
                a.Pop();
            }
            Console.WriteLine(a);
            for (int j = 0; j < 3; j++)
            {
                string[] q = { "aa", "bb", "cc" }; 
                b.Push(q[j]);
            }
            for (int j = 0; j < b.Count; j++)
            {
                b.Pop();
            }
            Console.WriteLine(b);
            #endregion

            #region 4번
            Dictionary<int, string> nick = new Dictionary<int, string>();
            nick.Add(10101, "강민성");
            nick.Add(10102, "경동엽");
            nick.Add(10103, "고다민");
            
            foreach (var j in nick)
            {
                Console.WriteLine(j);
            }
            #endregion


        }

        #region 1번
        static dynamic Rary(dynamic[] Source, dynamic[] Target)
        {
            int j = 1;
            for (int i = 0; i < Source.Length; i++)
            {
                Target[Source.Length - j] = Source[i];
                j++;
            }
            return Target;
        }
        #endregion
        


    }
}
