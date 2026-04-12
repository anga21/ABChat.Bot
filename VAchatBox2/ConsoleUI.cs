using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Threading;


namespace VAchatBox2
{
    
    public static class ConsoleUI


    
    {
        public static void WriteColour(String text, ConsoleColor color, bool newLine = true)
        { 
          
            Console.ForegroundColor = color;
          
            if (newLine) Console.WriteLine(text);
            else Console.WriteLine();
        }
            
        public static void  TypeWrite(string text,ConsoleColor color = ConsoleColor.White,int delayMs = 18)
        {
            Console.ForegroundColor = color;
            foreach(char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);

            }
            Console.WriteLine();
            Console.ResetColor();
        }
        public static void PrintDivider(char symbol ='=' ,int width =60,ConsoleColor color = ConsoleColor.DarkCyan) {
            WriteColour(new string (symbol ,width ) ,color);

        }     
        
        public static void PrintSectionHeader(string title ,ConsoleColor color =ConsoleColor.DarkBlue)
        {
            Console.WriteLine();
            PrintDivider('-' ,60,ConsoleColor.DarkCyan);
            WriteColour("" + title.ToUpper() ,color);
            PrintDivider('_' , 60 ,ConsoleColor.DarkCyan);
            
        }
        public static void PrintBoxedMessage(string message , ConsoleColor borderColor = ConsoleColor.Blue) {
        
            int width = message.Length + 6;
            WriteColour("🐳" + new string('=' ,width) + "🐳" ,borderColor);
            WriteColour("||" + message + " || ",borderColor);
            WriteColour("🐳" + new string('=', width) + "🐳", borderColor);

        }
        //THE WRITECOLOUR MAKES SURE THAT THE TEXT IS WRITEN IN COLOR 

        public static void PrintBotMessage(string message)
        {
        Console.WriteLine();
        WriteColour(" VAchatBot ",ConsoleColor.Magenta,newLine:false);
        TypeWrite(message,ConsoleColor.White,delayMs:15);


        }

    public static void PrintUserPrompt(string userName)
        {

            Console.WriteLine();
            WriteColour(" " + userName + ":" ,ConsoleColor.Magenta, newLine:false);
        }

        public static void PrintWarning(string message)
        {
            WriteColour("WARNING:" + message ,ConsoleColor.Red);
        }

        public static void PrintQuickTips() { 
        
            Console.WriteLine();
            WriteColour("QUICK COMMANDS:" ,ConsoleColor.DarkBlue);
            WriteColour("topics - See all cybersecurityn topics " , ConsoleColor.Blue);
            WriteColour("help - What can ABChat do?" ,ConsoleColor.Blue);
            WriteColour("Quit - Exit ABChat" ,ConsoleColor.Blue);
            PrintDivider('─', 60, ConsoleColor.Blue);

        }
        public static void PrintLogo()
        {
            Console.Clear();
            Console.WriteLine();
            String logo = @"           ____   _____ _           _   
                 /\   |  _ \ / ____| |         | |  
                /  \  | |_) | |    | |__   __ _| |_ 
               / /\ \ |  _ <| |    | '_ \ / _` | __|
              / ____ \| |_) | |____| | | | (_| | |_ 
             /_/    \_\____/ \_____|_| |_|\__,_|\__|  ";

            ConsoleUI.WriteColour(logo, ConsoleColor.Magenta);
            Console.WriteLine();

            string slogan = @" 
             ╔══════════════════════════════════════════════╗
             ║         CYBERSECURITY AWARENESS BOT          ║
             ║    Making your security as easy as ABC       ║
             ╚══════════════════════════════════════════════╝

            "; ConsoleUI.WriteColour(slogan, ConsoleColor.DarkMagenta);
            Console.WriteLine();

        }
        
            }
        }
    
