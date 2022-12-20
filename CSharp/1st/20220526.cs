using System;

namespace _2022._05._26
{
    internal class Program
    {
        public class Swordsman
        {
            public string name;
            public string sword;
            public double experience;

            public void walk(string input)
            {
                if (input == "walk")
                {
                    Console.WriteLine("걸어서 이동중 . . .");
                }
            }

            public void Run(string input)
            {
                if (input == "run")
                {
                    Console.WriteLine("뛰어서 이동중 . . .");
                }
            }

            public string fire(string input)
            {
                if (input == "fire")
                {
                    Console.WriteLine("필살기 ! !");
                }
                return input;
            }

            public void swordAttack()
            {
                Console.WriteLine("찌르기 ! !");
            }


            class Archer
            {
                string name;
                int arrow;
                int bow;
                float experience;
                public static int count;
                int id;

                public string walk1(string input)
                {
                    if (input == "walk")
                    {
                        Console.WriteLine("걸어서 이동 중 입니다 . . .");
                    }
                    return input;
                }

                public string run(string input)
                {
                    if (input == "run")
                    {
                        Console.WriteLine("뛰어가는 중입니다 . . .");
                    }
                    return input;
                }

                public string go(string input)
                {
                    if (input == "go")
                    {
                        Console.WriteLine("활 쏘는 중입니다 . . .");
                    }
                    return input;
                }

                void fire()
                {
                    Console.WriteLine("필 살 기 ! !");
                }
            }

            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
            }
        }
    }
}
