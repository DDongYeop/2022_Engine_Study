using System;
using System.Collections.Generic;

namespace _20220531
{
    internal class Program
    {
        public class Hero
        {
            

            public string name;
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
        }
        class Archer : Hero
        {
           
            int arrow;
            int bow;
            public static int count;
            int id;

           
            public string go(string input)
            {
                if (input == "go")
                {
                    Console.WriteLine("활 쏘는 중입니다 . . .");
                }
                return input;
            }
        }
        public class Swordsman :Hero
        {
            public string sword;                  

            public void swordAttack()
            {
                Console.WriteLine("찌르기 ! !");
            }           
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<Hero> Heros = new List<Hero>()
            {
                new Archer(), new Archer(), new Archer(), new Archer(), new Archer(),
                new Swordsman(), new Swordsman(), new Swordsman(), new Swordsman(), new Swordsman()
            };

            foreach (Hero item in Heros)
            {
                item.walk("walk");
                item.Run("run");
                item.fire("fire");
                
                if (item is Archer)
                {
                    ((Archer)item).go("go");
                }
                if (item is Swordsman)
                {
                    ((Swordsman)item).swordAttack();
                }

                var archer = item as Archer;
                var swordman = item as Swordsman;

                if (archer != null)
                {
                    ((Archer)item).go("go");
                }
                if (swordman != null)
                {
                    ((Swordsman)item).swordAttack();
                }
            }
        }
    }
}
