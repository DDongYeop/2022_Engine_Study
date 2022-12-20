using System;

namespace _20221219
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1. 이벤트

            MyNotifier notifier = new MyNotifier();
            notifier.SomethingHappened += MyHandler;
            for (int i = 0; i <= 30; i++)
                notifier.Dosomething(i);

            #endregion

            Console.WriteLine();

            #region 2. 이벤트

            Button btn = new Button();
            btn.Click += Hi1;
            btn.Click += Hi2;
            btn.OnClick();
            // btn.Click?.Invoke;

            #endregion
        }

        #region 1. 이벤트

        public static void MyHandler(string str)
        {
            Console.WriteLine(str);
        }

        #endregion

        #region 2. 이벤트

        public static void Hi1()
        {
            Console.WriteLine("C sharp");
        }

        public static void Hi2()
        {
            Console.WriteLine("Dot NET");
        }

        #endregion
    }

    #region 1. 이벤트

    class MyNotifier
    {
        public delegate void EventHandler(string str);

        public EventHandler SomethingHappened;

        public void Dosomething(int number)
        {
            if (number % 3 == 0 && number != 0)
                SomethingHappened($"{number} : 3의 배수");
        }
    }

    #endregion

    #region 2. 이벤트

    class Button
    {
        public delegate void EventHandler2();
        public event EventHandler2 Click;

        public void OnClick()
        {
            Click?.Invoke();
        }
    }
    #endregion
}
