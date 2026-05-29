using System;
using System.Windows.Forms;

namespace VAchatBox2
{

   static class Program
    {  
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ChatForm());

        }

     }

}