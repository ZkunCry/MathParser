using System;

namespace MathParser
{
    class Program
    {
        public static void Swap(string[] src, string operation, int index)
        {
            dynamic num = 0;
            double num1 = 0, num2 = 0;
            double.TryParse(src[index - 1], out num1);
            double.TryParse(src[index + 1], out num2);
            string[] temp = new string[src.Length - 2];
            switch (operation)
            {
                case "*":
                    num = num1 * num2;
                    break;
                case "/":
                    num = num1 / num2;
                    break;
                case "+":
                    num = num1 + num2;
                    break;
                case "-":
                    num = num1 - num2;
                    break;
        
            }
            src[index - 1] = num.ToString();
            src[index] = "";
            src[index + 1] = "";
            Copy(ref src, ref temp);
        }
        public static void Calc(string[]op)
        {
            
            for (int i = 0; i < op.Length; i++)
            {
                if (op[i] == "*")
                {
                    Swap(op, "*", i);
                    i = 0;
                }
                else if (op[i] == "/")
                {
                    Swap(op, "/", i);
                    i = 0;
                }
            }
            for (int i = 0; i < op.Length; i++)
            {
                if (op[i] == "+")
                {
                    Swap(op, "+", i);
                    i = 0;
                }
                else if (op[i] == "-")
                {
                    i = 0;
                    Swap(op, "-", i);
                }
            }
        }
        public static void CheckBrackets(ref string[]op)
        {
            string[] temp = new string[op.Length];
            for (int j = 0; j < op.Length; j++)
            {
                if (op[j] == "(")
                {
                    int tempj = j;
                    op[j] = "";
                    j++;
                    for (int q = 0; op[j] != ")"; q++, j++)
                    {
                        temp[q] = op[j];
                        op[j] = "";
                    }
                    op[j] = "";
                    Calc(temp);
                    op[tempj] = temp[0];
                    string[] temp2 = new string[op.Length];
                    Copy(ref op, ref temp2);
                    j = 0;
                }
            }
        }
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string[] op = str.Split();
            CheckBrackets(ref op);
            Calc(op);
            foreach (var item in op)
                Console.WriteLine(item);
            Console.ReadKey();
        }
        public static void Copy(ref string[] src, ref string[] temp)
        {
            for (int j = 0, q = 0; j < src.Length; j++)
            {
                if (src[j] == "")
                    continue;
                else
                {
                    temp[q] = src[j];
                    q++;
                }
            }
            src = temp;
        }
    }
}

