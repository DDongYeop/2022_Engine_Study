using System;
using System.Threading;

namespace _220517
{
    class Program
    {
        class Product
        {
           public static int counter = 0;
           public int id;
           public string name;
           public int price;

           public Product(string name, int price)
           {
               Product.counter += 1;
               this.id = counter;
               this.name = name;
               this.price = price;
           }

           ~Product()
           {
               Console.WriteLine(DateTime.Now + "에 소멸자 호출됨");
           }
       }

        class Marathon
        {
            public const double distance = 42.195;
            static void Main(string[] args)
            {
                Test();
                GC.Collect();
                Thread.Sleep(1000);

               Console.WriteLine(distance);
            }
        }
        
        static void Test()
            {
                Product product = new Product("ddd", 32);
            }
    }
}
