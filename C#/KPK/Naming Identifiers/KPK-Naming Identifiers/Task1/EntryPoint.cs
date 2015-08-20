namespace BoolToStringConverter
{
    using System;

    internal class EntryPoint
    {
        private const int MaxCount = 6; // or MAX_COUNT (both valid)

        public static void Main()
        {
            Converter myConverter = new Converter();
            string trueAsString = myConverter.BoolToString(true);
            Console.WriteLine(trueAsString);
        }
    }
}