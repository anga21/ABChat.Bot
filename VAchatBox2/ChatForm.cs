using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace VAchatBox2
{
    public partial class ChatForm : Form
    {
        private ResponseEngine _engine;
        private VoiceGreeting _voice;
        private string _userName = "";

        public ChatForm()
        {
            InitializeComponent();
            _engine = new ResponseEngine();
            _voice = new VoiceGreeting();
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            
            _voice.PlayGreeting();

            
            string name = Interaction.InputBox(
                "Welcome to the Cybersecurity Awareness Bot!\n" +
                "I am here to help you stay safe online.\n\n" +
                "What is your name?",
                "Welcome",
                "");

             
            _userName = string.IsNullOrWhiteSpace(name) ? "User" : name.Trim();

            _engine.UserName = _userName;

           
            AppendBotMessage("Hello " + _userName + "! I am your " +
                "Cybersecurity Awareness Bot. Ask me about passwords, " +
                "phishing, malware, privacy and more. " +
                "Type 'topics' to see everything I know!");
        }

 

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendMessage();
            }
        }

       
        private void SendMessage()
        {
            string input = txtInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(input)) return;

            AppendUserMessage(input);
            txtInput.Clear();

            string response = _engine.GetResponse(input);

            if (response == "QUIT_SIGNAL")
            {
                AppendBotMessage("Goodbye " + _userName +
                    "! Stay cyber-safe out there!");
                
                txtInput.Enabled = false;
                return;
            }

            AppendBotMessage(response);
        }

       
        private void AppendUserMessage(string text)
        {
            rtbChat.SelectionStart = rtbChat.TextLength;
            rtbChat.SelectionColor = Color.LimeGreen;
            rtbChat.SelectionFont = new Font("Segoe UI", 10f, FontStyle.Bold);
            rtbChat.AppendText("\n  " + _userName + ":  ");
            rtbChat.SelectionColor = Color.White;
            rtbChat.SelectionFont = new Font("Segoe UI", 10f);
            rtbChat.AppendText(text + "\n");
            rtbChat.ScrollToCaret();
        }

        
        private void AppendBotMessage(string text)
        {
            rtbChat.SelectionStart = rtbChat.TextLength;
            rtbChat.SelectionColor = Color.Magenta;
            rtbChat.SelectionFont = new Font("Segoe UI", 10f, FontStyle.Bold);
            rtbChat.AppendText("\n 🤖ABChat:  ");
            rtbChat.SelectionColor = Color.LightGray;
            rtbChat.SelectionFont = new Font("Segoe UI", 10f);
            rtbChat.AppendText(text + "\n");
            rtbChat.ScrollToCaret();
        }
    }
}