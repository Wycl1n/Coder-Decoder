﻿using System;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string t = Console.ReadLine();
            Console.WriteLine(CodeMessage(t));
            Console.WriteLine(DecodeMessage(CodeMessage(t)));
            Console.WriteLine();

            CodeMessageToFile(t, "D:\\text.txt");
            DecodeMessage("D:\\text.txt");

        }


        public static string CodeMessage(string message)
        {
            bool check;
            //if (message.Length > 20 || message.Length < 10) return "Invalid input";
            char[] symbols = new char[63];
            symbols[0] = '_';
            byte tI = 1;
            for (int i = 65; i <= 90; i++)
                symbols[tI++] = (char)i;
            for (int i = 48; i <= 57; i++)
                symbols[tI++] = (char)i;
            for (int i = 97; i <= 122; i++)
                symbols[tI++] = (char)i;
            for (int i = 0; i < message.Length; i++)
            {
                check = false;
                for (int j = 0; j < 63; j++)
                    if (message[i] == symbols[j])
                        check = true;
                if (!check)
                    return "Invalid input";
            }

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
        public static void CodeMessageToFile(string message, string path)
        {
            using(StreamWriter file = new StreamWriter(path))
            {
                file.WriteLine(CodeMessage(message));
            }
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
