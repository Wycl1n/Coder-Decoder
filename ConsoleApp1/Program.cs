using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string t = CodeMessage("HelloWorld123");
            Console.WriteLine(t);
            Console.WriteLine(DecodeMessage(t));

            /*
            byte action = 1;
            while (action != 0) 
            {
                Console.WriteLine("Choose what you wanna do");
                Console.WriteLine("1) Code");
                Console.WriteLine("2) Decode");
                Console.WriteLine("0) Exit");
                action = Convert.ToByte(Console.ReadLine());
                switch (action)
                {
                    case 1:
                        Codemessage(Console.ReadLine());
                        Console.WriteLine("message already coded");
                        break;
                    case 2:
                        Console.WriteLine("Write your message in \"input.txt\", save and input smth");
                        Console.ReadKey();
                        string decodedmessage = Decodemessage("C:\\input.txt");
                        Console.WriteLine("message ucoded");
                        Console.WriteLine(decodedmessage);
                        break;
                    case 0:
                        break;
                    default:
                        break;
                }
            }
            */
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

            Random rand = new Random();
            string resultString = "";
            string randomString = "";
            for (int i = 0; i < message.Length; i++)
            {
                randomString += (char)(rand.Next() % 200);
                resultString += (char)(((int)message[i] + (int)randomString[i]));
            }
            resultString += randomString;
            return resultString;
        }
        public static string DecodeMessage(string codedMessage)
        {
            string resultString = "";
            for (int i = 0; i < codedMessage.Length / 2; i++) 
            {
                resultString += (char)((int)codedMessage[i] - (int)codedMessage[i + codedMessage.Length / 2]);
            }

            return resultString;
        }
    }
}
