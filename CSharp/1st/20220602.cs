using System;
using static System.Console;

namespace _20220602
{
    internal class Program
    {
        public class Hero
        {
            public Hero()
            {
                WriteLine("Hero 클래스 생성자");
            }
        }

        class Archer : Hero
        {
            public Archer()
            {
                WriteLine("Archer 클래스 생성자");
            }
        }

        static void Main(string[] args)
        {
            Archer archer = new Archer();
        }
    }
}
