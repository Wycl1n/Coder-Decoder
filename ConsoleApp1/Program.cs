using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string t = CodeMessage(Console.ReadLine());
            Console.WriteLine(t);
            Console.WriteLine(DecodeMessage(t));
        }


        public static string CodeMessage(string message)
        {
            bool check;
            if (message.Length > 20 || message.Length < 10) return "Invalid input";
            for (int i = 0;i<message.Length;i++)
            {
                check = false;
                for (int j = 48; j <= 57; j++)
                    if (message[i] == (char)j) check = true;
                for (int j = 65; j <= 90; j++)
                    if (message[i] == (char)j) check = true;
                for (int j = 97; j <= 122; j++)
                    if (message[i] == (char)j) check = true;
                if (!check) return "Invalid input";
            }

            char[] symbols = new char[62];
            byte tI = 0;
            for (int i = 65; i <= 90; i++)
                symbols[tI++] = (char)i;
            for (int i = 48; i <= 57; i++)
                symbols[tI++] = (char)i;
            for (int i = 97; i <= 122; i++)
                symbols[tI++] = (char)i;

            Random rand = new Random();
            string tNumber = "";
            for (int i = 0; i < message.Length; i++)
                tNumber += symbols[rand.Next() % 62];
            string resultString = "";
            for (int i = 0; i < message.Length; i++)
            {
                resultString += (char)((int)message[i] + (int)tNumber[i]);
                resultString += tNumber[message.Length - 1 - i];
            }
            return resultString;
        }
        public static string DecodeMessage(string codedMessage)
        {
            string resultString = "";
            for (int i = 0; i < codedMessage.Length; i+=2) 
            {
                resultString += (char)((int)codedMessage[i] - (int)codedMessage[codedMessage.Length - 1 - i]);
            }

            return resultString;
        }
    }
}
