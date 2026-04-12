using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VAchatBox2
{
    public  class ChatBot
    {
        private readonly ResponseEngine _engine;
        private readonly VoiceGreeting _voice;
        private string _userName = "User";

        public ChatBot()
        {
            _engine = new ResponseEngine();
            _voice = new VoiceGreeting();
        }

        public void Run()
        {
            ConsoleUI.PrintLogo();
            ConsoleUI.WriteColour("Playing Voice Greeting.......",ConsoleColor.Cyan);
            _voice.PlayGreeting();

            ConsoleUI.PrintDivider('═', 60, ConsoleColor.DarkCyan);
            ConsoleUI.TypeWrite("  Welcome to the Cybersecurity Awareness Bot!", ConsoleColor.Yellow);
            ConsoleUI.TypeWrite("  I am here to help you stay safe online.", ConsoleColor.DarkCyan);
            ConsoleUI.PrintDivider('═', 60, ConsoleColor.DarkCyan);

            _userName = GreetAndGetName();
            _engine.UserName = _userName;     

            ConsoleUI.PrintBoxedMessage("Welcome," + _userName + " Your security is our priority.");
            ConsoleUI.PrintQuickTips();

            ConversationLoop();

        }
        private string GreetAndGetName()
        {
            ConsoleUI.PrintSectionHeader("Lets get Started");
            ConsoleUI.TypeWrite("\n  Before we begin, What Is Your Name?", ConsoleColor.Cyan);

            string name = string.Empty;

            while (string.IsNullOrWhiteSpace(name))
            {
                ConsoleUI.WriteColour("  Your name: ", ConsoleColor.Magenta, newLine: false);
                name = Console.ReadLine()?.Trim() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(name))
                    ConsoleUI.PrintWarning("Please enter your name to continue.");
            }

            ConsoleUI.TypeWrite("\n  🍒Great, It is nice to meet you, " + name + " Let's keep you cyber-safe.🍒", ConsoleColor.Magenta);
            return name;
        }

        private void ConversationLoop()
        {
            bool running = true;

            while (running)
            {
                ConsoleUI.PrintUserPrompt(_userName);
                string input = Console.ReadLine() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(input))
                {
                    ConsoleUI.PrintWarning("You have not typed anything. Please enter a question.");
                    continue;
                }

                string response = _engine.GetResponse(input);

                if (response == "QUIT_SIGNAL")
                {
                    running = false;
                    ExitSequence();
                }
                else
                {
                    ConsoleUI.PrintBotMessage(response);
                    Thread.Sleep(200);
                }
            }
        }

        private void ExitSequence()
        {
            Console.WriteLine();
            ConsoleUI.PrintDivider('═', 60, ConsoleColor.DarkCyan);
            ConsoleUI.TypeWrite("  Goodbye, " + _userName + "! Stay cyber-safe out there.", ConsoleColor.Yellow);
            ConsoleUI.TypeWrite("  Remember: Think before you click!", ConsoleColor.Cyan);
            ConsoleUI.PrintDivider('═', 60, ConsoleColor.DarkCyan);
            Console.WriteLine();
            ConsoleUI.WriteColour("  Press any key to close...", ConsoleColor.DarkGray);
            Console.ReadKey();
        }
    }
}

    

