using System;
using System.Collections;

namespace _20220915
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NickName nickName = new NickName();
            nickName["정유철"] = "바부냥이";
            Console.WriteLine(nickName["정유철"]);
        }
    }
}
