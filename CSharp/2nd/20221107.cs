using System;

namespace _20221107
{
    internal class Program
    {
        #region 대리자 체인
        public delegate void SendString(string aa);
        #endregion

        #region 익명 메서드
        public delegate int Compare(int a, int b);
        #endregion

        static void Main(string[] args)
        {
            #region 대리자 체인
            SendString SayHello = new SendString(Hello);
            SendString SayGoodBye = new SendString(GoodBye);
            
            SendString MultiDelegate = SayHello;
            MultiDelegate += SayGoodBye;
            MultiDelegate("경동엽");

            Console.WriteLine();

            MultiDelegate -= SayGoodBye;
            MultiDelegate("경동엽");
            #endregion

            Console.WriteLine();

            #region 익명 메서드
            Compare AscendCompare;
            AscendCompare = delegate (int a, int b)
            {
                return a.CompareTo(b);
            };

            Compare DescendCompare;
            DescendCompare = delegate (int a, int b)
            {
                return b.CompareTo(a);
            };

            int[] array = { 5, 3, 7, 9, 1 };

            BubbleSort(array, AscendCompare);
            string[] array2 = { "1", "2", "3", "4", "5" };
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");

            Console.WriteLine();

            BubbleSort(array, DescendCompare);
            string[] array3 = { "1", "2", "3", "4", "5" };
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");

            Console.WriteLine("\n");
            #endregion
        }

        #region 대리자 체인
        public static void Hello(string aa)
        {
            Console.WriteLine($"{aa}씨 안녕하세요");
        }

        public static void GoodBye(string aa)
        {
            Console.WriteLine($"{aa}씨 안녕히가세요");
        }
        #endregion

        #region 익명 메서드
        public static void BubbleSort(int[] array, Compare compare)
        {
            int temp;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - (i + 1); j++)
                {
                    if (compare(array[j], array[j + 1]) > 0)
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
        #endregion
    }
}
