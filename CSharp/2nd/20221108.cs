using System;

namespace _20221108
{
    #region 이벤트
    public delegate void EventHandler(string s);
    #endregion

    internal class Program
    {
        #region 익명 메서드
        public delegate bool MemberTest(int a);
        #endregion

        static void Main(string[] args)
        {
            #region 익명 메서드
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };

            MemberTest memberTest;
            memberTest = delegate (int a)
            {
                if (a % 2 == 0)
                    return true;
                else
                    return false;
            };
            int even = Count(arr, memberTest);

            memberTest = delegate (int a)
            {
                if (a % 2 == 1)
                    return true;
                else
                    return false;
            };
            int odd = Count(arr, memberTest);

            Console.WriteLine($"짝수 : {even}\n홀수 : {odd}");
            #endregion

            #region 이벤트
            MyNotifier notifier = new MyNotifier();
            notifier.SomethingHappened += new EventHandler(MyHandler);

            for (int i = 0; i < 30; i++)
                notifier.Dosometing(i);
            #endregion
        }

        #region 익명 메서드
        public static int Count(int[] vs, MemberTest memberTest)
        {
            int cnt = 0;

            for (int i = 0; i < vs.Length; i++)
            {
                if (memberTest(vs[i]))
                    cnt++;
            }

            return cnt;
        }
        #endregion

        #region 이벤트
        public static void MyHandler(string st)
        {
            Console.WriteLine(st);
        }
        #endregion
    }

    #region 이벤트
    class MyNotifier
    {
        public event EventHandler SomethingHappened;

        public void Dosometing(int number)
        {
            if (number % 3 == 0)
                SomethingHappened($"{number} : 3의 배수");
        }
    }
    #endregion
}
