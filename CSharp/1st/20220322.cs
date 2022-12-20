using System;

namespace _20220322
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nname = "경동엽";
            nname += "저는 언리얼이좋아요";
            Console.WriteLine(nname[0]);
            Console.WriteLine(nname[4]);
            Console.WriteLine(nname[6]);
            int one = DateTime.Now.Hour;
            int two = DateTime.Now.Hour;
            Console.WriteLine(one < 19);
            Console.WriteLine(two == 10);
            Console.WriteLine(DateTime.Now.Hour);
            string output = "C#";
            output += "프로그래밍";
            output += "!";
            Console.WriteLine(output);
            int age = 17;

            Console.WriteLine(age);
            age--;
            Console.WriteLine(age);
            age++;
            age--;
            age--;
            Console.WriteLine(age);
            age++;
            Console.WriteLine(age);
        }
    }
}
