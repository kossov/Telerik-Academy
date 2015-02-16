using System;

class Program
{
    static void Main(string[] args)
    {
        int j = 50;
        Console.WriteLine("The program compares lexicographically letters, not symbols nor numbers!\n");
        Console.Write("Enter the FIRST array: ");
        string firstArrayAsString = Console.ReadLine();
        firstArrayAsString = firstArrayAsString.Trim(); // removes all empty spaces before other characters Ex. "   v" => "v"
        firstArrayAsString = firstArrayAsString.Replace(" ", ""); // removes all spaces between characters Ex. "v  b" => "vb"
        char[] firstArrayAsChar = firstArrayAsString.ToCharArray();
        Console.Write("Enter the SECOND array: ");
        string secondArrayAsString = Console.ReadLine();
        secondArrayAsString = secondArrayAsString.Trim();
        secondArrayAsString = secondArrayAsString.Replace(" ", "");
        char[] secondArrayAsChar = secondArrayAsString.ToCharArray();
        if (firstArrayAsString.Length > secondArrayAsString.Length)
        {
            Console.WriteLine(new string('~', j));
            Console.WriteLine("Both arrays have different size!\nThe only possible comparison size is {0} char symbols!", secondArrayAsString.Length);
            Console.WriteLine(new string('~', j));
            for (int i = 0; i < secondArrayAsString.Length; i++)
            {
                Console.WriteLine();
                char tempFirst = Convert.ToChar(firstArrayAsChar[i].ToString().ToUpper()); // you cant substract string-string so I needed it in
                char tempSecond = Convert.ToChar(secondArrayAsChar[i].ToString().ToUpper()); // char-as a symbol and also as a Upper because in
                Console.WriteLine("The [{0}] char symbol", i + 1);                                // ASCII 'a' - 'A' is not 0
                Console.Write("In the First array: {0}", firstArrayAsChar[i]);
                Console.WriteLine("{0}In the Second Array: {1}", new string(' ', 10), secondArrayAsChar[i]);
                if (firstArrayAsChar[i] == secondArrayAsChar[i])
                    Console.WriteLine("Both letters are the same.");
                else if (firstArrayAsChar[i] > secondArrayAsChar[i])
                    Console.WriteLine("'{0}' is lexicographically {1} places after '{2}'", firstArrayAsChar[i], tempFirst - tempSecond, secondArrayAsChar[i]);
                else
                    Console.WriteLine("'{0}' is lexicographically {1} places before '{2}'", firstArrayAsChar[i], tempSecond - tempFirst, secondArrayAsChar[i]);
            }
        }
        else if (firstArrayAsString.Length < secondArrayAsString.Length)
        {
            Console.WriteLine(new string('~', j));
            Console.WriteLine("Both arrays have different size!\nThe only possible comparison size is {0} char symbols!", firstArrayAsString.Length);
            Console.WriteLine(new string('~', j));
            for (int i = 0; i < firstArrayAsString.Length; i++)
            {
                Console.WriteLine();
                char tempFirst = Convert.ToChar(firstArrayAsChar[i].ToString().ToUpper());
                char tempSecond = Convert.ToChar(secondArrayAsChar[i].ToString().ToUpper());
                Console.WriteLine("The [{0}] char symbol", i + 1);
                Console.Write("In the First array: {0}", firstArrayAsChar[i]);
                Console.WriteLine("{0}In the Second Array: {1}", new string(' ', 10), secondArrayAsChar[i]);
                if (firstArrayAsChar[i] == secondArrayAsChar[i])
                    Console.WriteLine("Both letters are the same.");
                else if (firstArrayAsChar[i] > secondArrayAsChar[i])
                    Console.WriteLine("'{0}' is lexicographically {1} places after '{2}'", firstArrayAsChar[i], tempFirst - tempSecond, secondArrayAsChar[i]);
                else
                    Console.WriteLine("'{0}' is lexicographically {1} places before '{2}'", firstArrayAsChar[i], tempSecond - tempFirst, secondArrayAsChar[i]);
            }
        }
        else
        {
            Console.WriteLine(new string('~', j));
            Console.WriteLine("Both arrays have the same size so they can be fully compared!");
            Console.WriteLine(new string('~', j));
            for (int i = 0; i < firstArrayAsString.Length; i++)
            {
                Console.WriteLine();
                char tempFirst = Convert.ToChar(firstArrayAsChar[i].ToString().ToUpper());
                char tempSecond = Convert.ToChar(secondArrayAsChar[i].ToString().ToUpper());
                Console.WriteLine("The [{0}] char symbol", i + 1);
                Console.Write("In the First array: {0}", firstArrayAsChar[i]);
                Console.WriteLine("{0}In the Second Array: {1}", new string(' ', 10), secondArrayAsChar[i]);
                if (firstArrayAsChar[i] == secondArrayAsChar[i])
                    Console.WriteLine("Both letters are the same.");
                else if (firstArrayAsChar[i] > secondArrayAsChar[i])
                    Console.WriteLine("'{0}' is lexicographically {1} places after '{2}'", firstArrayAsChar[i], tempFirst - tempSecond, secondArrayAsChar[i]);
                else
                    Console.WriteLine("'{0}' is lexicographically {1} places before '{2}'", firstArrayAsChar[i], tempSecond - tempFirst, secondArrayAsChar[i]);
            }

        }

    }
}

