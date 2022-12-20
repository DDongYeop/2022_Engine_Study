using System;
using System.Collections.Generic;

namespace _20221101
{
    internal class Program
    {
        //public delegate int Compare(int a, int b);
        public delegate int Compare<T>(T a, T b);

        static void Main(string[] args)
        {
            #region 대리자를 이용한 정렬프로그램
            int[] array = { 5, 3, 7, 9, 1 };

            BubbleSort<int>(array, AscendCompare<int>);
            string[] array2 = { "1", "2", "3", "4", "5" };
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");

            Console.WriteLine();

            BubbleSort<int>(array, DescendCompare<int>);
            string[] array3 = { "1", "2", "3", "4", "5" };
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");
            
            Console.WriteLine("\n");
            #endregion
        }

        #region 대리자를 이용한 정렬프로그램
        public static int AscendCompare<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b);
        }

        public static int DescendCompare<T>(T a, T b) where T : IComparable<T>
        {
            return b.CompareTo(a);
        }

        public static void BubbleSort<T>(T[] array, Compare<T> compare)
        {
            T temp;

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
