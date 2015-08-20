using System;
using System.Data;

class Program
{
    static void Main(string[] args)
    {
        string input = "4+6/5+(4*9–8)/7*2";// Console.ReadLine();
        string withoutShitInput = "";
        double sum = 0;
        foreach (char symbol in input)
        {
            if (symbol.Equals(')') || symbol.Equals('(') || symbol.Equals('*') || symbol.Equals('-') || symbol.Equals('+') || symbol.Equals('/') || (symbol - '0' >= 0 && symbol - '0' <= 9))
            {
                withoutShitInput = withoutShitInput + symbol;
            }
        }
        char[] calculations = new char[withoutShitInput.Length];
        int j = 0;
        foreach (char item in withoutShitInput)
        {

            calculations[j] = item;
            j++;
        }
        for (int i = 0; i < calculations.Length; i++)
        {
            if (calculations[i] - '0' >= 0 && calculations[i] - '0' <= 9)
            {
                if (calculations[i + 2] == ')' || calculations[i + 2] == '(')
                {
                    i = i + 3;
                    continue;
                }
                if (calculations[i - 1] == '(')
                {
                    #region #region * && sum +/*- =
                    if (calculations[i + 1] == '*' && calculations[i - 2] == '+')
                        sum += (calculations[i] - '0') * (calculations[i + 2] - '0');
                    if (calculations[i + 1] == '*' && calculations[i - 2] == '-')
                        sum -= (calculations[i] - '0') * (calculations[i + 2] - '0');
                    if (calculations[i + 1] == '*' && calculations[i - 2] == '*')
                        sum *= (calculations[i] - '0') * (calculations[i + 2] - '0');
                    if (calculations[i + 1] == '*' && calculations[i - 2] == '/')
                        sum /= (calculations[i] - '0') * (calculations[i + 2] - '0');
                    #endregion

                    #region + && sum +/*- =
                    if (calculations[i + 1] == '+' && calculations[i - 2] == '+')
                        sum += (calculations[i] - '0') + (calculations[i + 2] - '0');
                    if (calculations[i + 1] == '+' && calculations[i - 2] == '-')
                        sum -= (calculations[i] - '0') * (calculations[i + 2] - '0');
                    if (calculations[i + 1] == '+' && calculations[i - 2] == '*')
                        sum *= (calculations[i] - '0') * (calculations[i + 2] - '0');
                    if (calculations[i + 1] == '+' && calculations[i - 2] == '/')
                    #endregion

                        #region / && sum +/*- =
                        sum /= (calculations[i] - '0') * (calculations[i + 2] - '0'); // must be added for sum (+ - * / )=
                    if (calculations[i + 1] == '-')
                        #endregion
                        sum -= (calculations[i] - '0') - (calculations[i + 2] - '0');
                    if (calculations[i + 1] == '/')
                        sum /= (calculations[i] - '0') / (calculations[i + 2] - '0');
                }
                if (calculations[i + 1] == '*')
                    sum += (calculations[i] - '0') * (calculations[i + 2] - '0');
                if (calculations[i + 1] == '+')
                    sum += (calculations[i] - '0') + (calculations[i + 2] - '0');
                if (calculations[i + 1] == '-')
                    sum -= (calculations[i] - '0') - (calculations[i + 2] - '0');
                if (calculations[i + 1] == '/')
                    sum /= (calculations[i] - '0') / (calculations[i + 2] - '0');
                i = i + 2;
            }
        }
        Console.WriteLine(sum);
    }
}
