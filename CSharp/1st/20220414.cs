using System;

namespace _2022._04._14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int X = int.Parse(Console.ReadLine()); //배열의 크기
            int[] A = new int[X];
            int N = int.Parse(Console.ReadLine()); // 배열에서 N보다 작은 수를 찾고자 함

            for (int i = 0; i < X; i++)
            {
                A[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("N보다 작은 값을 출력합니다");

            for(int i = 0; i < X; i++)
            {
                if(N > A[i])
                {
                    Console.Write(A[i]+" ");
                }
            }

        }
    }
}
