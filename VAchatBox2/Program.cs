using System;

namespace VAchatBox2
{

    class Program
    {  static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Cybersecurity Aweareness Bot ";


            ChatBot bot = new ChatBot();
            bot.Run();
        }

     }

}