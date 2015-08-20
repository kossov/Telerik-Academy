namespace BitArray64
{
    using System;

    public class BitArray64Test
    {
        public static void Main(string[] args)
        {
            BitArray64 firstNum = new BitArray64(240); // 1111 0000
            BitArray64 secondNum = new BitArray64(248);// 1111 1000
            Console.WriteLine("~240~");
            Console.WriteLine(firstNum);
            Console.WriteLine("~248~");
            Console.WriteLine(secondNum);
            Console.WriteLine("~MAKE AT POSITION 3 OF NUMBER 248 BIT 1 TO BIT 0~");
            secondNum[3] = 0;
            Console.WriteLine(secondNum);
        }
    }
}
