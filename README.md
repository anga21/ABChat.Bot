ABChat-Cybersecurity Awareness Chatbot

ABChat is a C# console-based chatbot designed to promote and raise
cybersecurity awareness.
It is interactve with users through GUI ,voice massege and ASCII art .ABChat provides helpful safety tips and creates a more engaging learning experience.

 Features

Voice greeting played from a custom WAV file on startup.
ASCII art logo displayed in a dark-themed GUI.
Personalised responses using the user's name.
Keyword-based response engine covering eight cybersecurity topics.
Random tip selection so the same question gives varied answers.
Sentiment detection that adjusts responses based on the user's tone.
Memory system that remembers the user's favourite topic.
Conversation flow support for follow-up questions like "tell me more".
Input validation for empty, short, or unrecognised queries.
Clean exit sequence when the user types quit or bye.

Technologies Used

 C# \.NET.
 Console Application.
 System.Speech / WAV audio playback.
 GitHub Actions (CI).
 System.Windows.Forms/GUI controls and SoundPlayer .
 System.Drawing	/Colours, fonts, and graphics.


How It Works

The chatbot uses a Response Engine to process user input.
A VoiceGreeting class plays an audio welcome message.
A Windows popup prompts user for for nae .
WindForm Window contains logo,slogan and welcome statement. 
User enters questions text area .
User input is handled through a loop for continuous interaction.
Tips and appropriate responses to users input .

Project Structure

ChatBot.cs.
ChatForm.cs.
ResponseEngine.cs.
ConsoleUI.cs.
greeting.wav.
github/workflows/dotnet.yml.


Author
-Angaho Lishivha


