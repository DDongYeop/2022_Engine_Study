using System;
using System.Collections.Generic;

namespace _20221226
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action jummpRope = () => Console.WriteLine();

            #region 1. Action 형식의 대리자
            Action act1 = () => Console.WriteLine("Action()");
            act1();

            int result = 0;
            Action<int> act2 = (int num) => result = num * num;
            act2(5);
            Console.WriteLine(result);

            Action<float, float> act3 = (num1, num2) => Console.WriteLine(num1 / num2);
            act3(10, 2);
            #endregion

            jummpRope();

            #region Predicate<T> 대리자
            Predicate<int> isOdd = (num) => (num % 2 == 0);
            Console.WriteLine(isOdd(7));

            Predicate<string> isLowerCase = (str) => str.Equals(str.ToLower());
            string str = Console.ReadLine();
            Console.WriteLine(isLowerCase(str));
            #endregion

            jummpRope();

            #region Predicate 리스트
            List<string> myList = new List<string> { "cat", "rabbit", "tiger", "elephant", "zebra", "lion", "snake" };
            bool exist = myList.Exists(s => s.Contains("z"));
            Console.WriteLine(exist);

            string name = myList.Find(s => s.Length > 5);
            Console.WriteLine(name);

            List<string> Longname = myList.FindAll(s => s.Length > 5);
            foreach(var item in Longname)
                Console.WriteLine(item + " ");
            #endregion

            jummpRope();
        }
    }
}
