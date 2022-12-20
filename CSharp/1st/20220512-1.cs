using System;

namespace _20220512
{
    internal class Program
    {
        class Archer
        {
            string name;
            int arrow;
            int bow;
            float experience;
            public static int count;
            int id;
            
            public Archer(string Name, int Arrow, int Bow, float Experience)
            {
                this.name = Name;
                this.arrow = Arrow;
                this.bow = Bow;
                this.experience = Experience;

                count++;

                this.id = count;
            }
        }



        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
