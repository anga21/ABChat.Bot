using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Speech;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;


namespace VAchatBox2
{
   
        public class VoiceGreeting
        {
            private readonly string _wavPath;

            private const string GreetingText =
                "Hello! Welcome to the Cybersecurity Awareness Bot." +
                "I am here to help you stay safe online!";

            public VoiceGreeting()
            {
                _wavPath = System.IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "greeting.wav");
            }

            public void PlayGreeting()
            {
                try
                {
                    if (!File.Exists(_wavPath))
                        GenerateWav();

                    using (SoundPlayer player = new SoundPlayer(_wavPath))
                    {
                        player.PlaySync();
                   }
                }
                catch (Exception ex)
                {
                    ConsoleUI.PrintWarning("Voice playback failed: " + ex.Message);
                 }
            }

            private void GenerateWav()
            {
                using (SpeechSynthesizer synth = new SpeechSynthesizer() )
                {
                    synth.Rate = -1;
                    synth.Volume = 100;

                    try { synth.SelectVoiceByHints(VoiceGender.Female); }
                    catch { }

                    synth.SetOutputToWaveFile(_wavPath);
                    synth.Speak(GreetingText);
                    synth.SetOutputToDefaultAudioDevice();
              }
            }
        }
    }