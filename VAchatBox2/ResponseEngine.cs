using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAchatBox2
{

  
    public class ResponseEngine
    {


            public string UserName { get; set; } = "User";
            private string _lastTopic = "";
            private string _favouriteTopic = "";
            private List<string> _mentionedTopics = new List<string>();

            
            private Random _random = new Random();

        
        private Dictionary<string, string[]> _keywordMap = new Dictionary<string, string[]>
            {
                { "password", new[] { "password", "passwords", "passphrase" } },
                { "phishing", new[] { "phishing", "scam email", "fake email", "scam" } },
                { "malware",  new[] { "malware", "virus", "ransomware", "spyware", "trojan" } },
                { "browsing", new[] { "browsing", "safe browsing", "https", "vpn", "website" } },
                { "2fa",      new[] { "2fa", "mfa", "two factor", "authenticator" } },
                { "social",   new[] { "social engineering", "vishing", "smishing", "pretexting" } },
                { "wifi",     new[] { "wifi", "wi-fi", "hotspot", "public wifi" } },
                { "privacy",  new[] { "privacy", "personal data", "data breach", "gdpr" } },
            };
        
        private string[] _phishingTips =
            {
            "Be cautious of emails asking for personal information. Scammers disguise themselves as trusted organisations.",
            "Always hover over links before clicking to check the real URL matches the sender's website.",
            "Legitimate banks and companies will NEVER ask for your password by email.",
            "Look for spelling mistakes and urgent language — these are classic phishing red flags.",
            "When in doubt, go directly to the website by typing it yourself instead of clicking a link."
        };

            private string[] _passwordTips =
            {
            "Use at least 12 characters mixing uppercase, lowercase, numbers and symbols.",
            "Never reuse the same password across multiple accounts.",
            "Consider a passphrase — three random words joined together are strong and memorable.",
            "Use a password manager like Bitwarden to generate and store strong passwords safely.",
            "Change your passwords immediately if you suspect an account has been compromised."
        };

            private string[] _malwareTips =
            {
            "Keep your antivirus software updated — new threats appear every day.",
            "Never open email attachments from senders you do not recognise.",
            "Only download software from official websites and app stores.",
            "Regularly back up your files so ransomware cannot hold your data hostage.",
            "If your device suddenly slows down it could be a sign of malware — run a scan."
        };

        public string GetResponse(string input)
        {
           
            if (string.IsNullOrWhiteSpace(input))
                return "Please type a question or keyword.";

            string trimmed = input.Trim();

            if (trimmed.Length < 2)
                return "That is too short. Try typing a full word!";

            string lower = trimmed.ToLower();

            
            string sentiment = DetectSentiment(lower);
            string sentimentPrefix = GetSentimentPrefix(sentiment);


            
            if (MatchesAny(lower, new[] { "more", "another", "again",
                                   "tell me more", "give me another",
                                   "another tip", "explain more", "go on" }))
            {
                if (!string.IsNullOrEmpty(_lastTopic))
                    return "Here is another tip on " + _lastTopic +
                           " for you, " + UserName + ":\n\n" +
                           GetAdviceForTopic(_lastTopic);
                else
                    return "What topic would you like more on? " +
                           "Type 'topics' to see what I can help with."; 
            }

           
            if (MatchesAny(lower, new[] { "interested in", "i like",
                                   "i want to know about", "my favourite" }))
            {
                foreach (string t in _keywordMap.Keys)
                {
                    if (lower.Contains(t))
                    {
                        _favouriteTopic = t;
                        if (!_mentionedTopics.Contains(t))
                            _mentionedTopics.Add(t);
                        return "Great! I will remember that you are interested in " +
                               t + ", " + UserName + ". Want a tip on it right now?";
                    }
                }
            }

            
            if (MatchesAny(lower, new[] { "quit", "bye", "goodbye","exit" }))
                return "QUIT_SIGNAL";

            foreach (var entry in _keywordMap)
            {
                if (MatchesAny(lower, entry.Value))
                {
                    _lastTopic = entry.Key;
                    if (!_mentionedTopics.Contains(entry.Key)) 
                        _mentionedTopics.Add(entry.Key);
                    return sentimentPrefix + GetAdviceForTopic(entry.Key);
                }
            }

            
            if (MatchesAny(lower, new[] { "hello", "hi", "hey" }))
                return "Hey there, " + UserName + "! Ready to stay cyber-safe? " +
                       "Type 'topics' to see what I know.";

            if (MatchesAny(lower, new[] { "how are you", "you okay" }))
                return "Fully operational and ready to help, " + UserName + "!";

            if (MatchesAny(lower, new[] { "help", "topics", "what can you do" }))
                return GetTopicsList();

           
            return "I am not sure I understand, " + UserName +
                   ". Can you try rephrasing? You could ask about:\n\n" +
                   "passwords, phishing, malware, wifi,\n" +
                   "privacy, 2fa, browsing, or social engineering.\n\n" +
                   "Or type 'topics' to see the full list!";
        }

        
        private string GetAdviceForTopic(string topic)
            {
                switch (topic)
                {
                    case "password": return GetPasswordAdvice();
                    case "phishing": return GetPhishingAdvice();
                    case "malware": return GetMalwareAdvice();
                    case "browsing": return GetSafeBrowsingAdvice();
                    case "2fa": return GetMFAAdvice();
                    case "social": return GetSocialEngineeringAdvice();
                    case "wifi": return GetWifiAdvice();
                    case "privacy": return GetPrivacyAdvice();
                    default:
                        return "I know a little about " + topic +
                               ". Could you be more specific?";
                }
            }

            private string GetFollowUp(string topic)
            {
                return "Here is another tip on " + topic + " for you, " +
                       UserName + ":\n\n" + GetAdviceForTopic(topic);
            }

            private string DetectSentiment(string input)
            {
                if (MatchesAny(input, new[] { "worried", "scared", "anxious",
                                           "nervous", "afraid", "frightened" }))
                    return "worried";

                if (MatchesAny(input, new[] { "confused", "don't understand",
                                           "lost", "not sure", "unclear" }))
                    return "confused";

                if (MatchesAny(input, new[] { "frustrated", "annoyed",
                                           "angry", "hopeless" }))
                    return "frustrated";

                if (MatchesAny(input, new[] { "curious", "interesting",
                                           "want to know", "tell me", "how does" }))
                    return "curious";

                return "";
            }

            private string GetSentimentPrefix(string sentiment)
            {
                switch (sentiment)
                {
                    case "worried":
                        return "It is completely understandable to feel that way, " + UserName +
                               ". You are already doing the right thing by learning about it! " +
                               "Here is what can help:\n\n";
                    case "confused":
                        return "No worries at all, " + UserName +
                               ". This can be tricky! Let me break it down simply:\n\n";
                    case "frustrated":
                        return "I hear you, " + UserName +
                               ". Let us slow down and work through this together:\n\n";
                    case "curious":
                        return "Great question! I love the curiosity, " + UserName + ":\n\n";
                    default:
                        return "";
                }
            }

           
            private string AddMemoryNote(string response)
            {
                if (!string.IsNullOrEmpty(_favouriteTopic) &&
                    response.ToLower().Contains(_favouriteTopic))
                {
                    return response + "\n\n  By the way — as someone interested in " +
                           _favouriteTopic + ", you might want to review your account " +
                           "security settings regularly too, " + UserName + ".";
                }
                return response;
            }

            
            private string GetTopicsList()
            {
                return "Here is what I can help you with, " + UserName + ":\n\n" +
                       "  passwords        — Strong passwords and managers\n" +
                       "  phishing         — Spotting email scams\n" +
                       "  safe browsing    — Staying safe on the web\n" +
                       "  malware          — Viruses, ransomware and more\n" +
                       "  social eng.      — Manipulation tactics\n" +
                       "  2fa              — Two-factor authentication\n" +
                       "  data privacy     — Protecting personal info\n" +
                       "  public wifi      — Risks of public networks\n\n" +
                       "  Just type any topic to get started!";
            }

            
            private string GetPasswordAdvice()
            {
                string tip = _passwordTips[_random.Next(_passwordTips.Length)];
                return AddMemoryNote(
                    "PASSWORD TIP:\n\n  " + tip +
                    "\n\n  Ask me again for another tip, " + UserName + "!");
            }

            private string GetPhishingAdvice()
            {
                string tip = _phishingTips[_random.Next(_phishingTips.Length)];
                return AddMemoryNote(
                    "PHISHING TIP:\n\n  " + tip +
                    "\n\n  Ask me again for a different tip, " + UserName + "!");
            }

            private string GetMalwareAdvice()
            {
                string tip = _malwareTips[_random.Next(_malwareTips.Length)];
                return AddMemoryNote(
                    "MALWARE TIP:\n\n  " + tip +
                    "\n\n  Ask me again for another tip, " + UserName + "!");
            }

            private string GetSafeBrowsingAdvice()
            {
                return AddMemoryNote(
                    "SAFE BROWSING TIPS:\n\n" +
                    "  Always check for HTTPS before entering any personal info.\n" +
                    "  Keep your browser and extensions up to date.\n" +
                    "  Use a reputable ad-blocker to block malicious ads.\n" +
                    "  Avoid downloading files from unknown or suspicious websites.\n" +
                    "  Use a VPN when on public networks.\n\n" +
                    "  Browse with caution, " + UserName + "!");
            }

            private string GetMFAAdvice()
            {
                return AddMemoryNote(
                    "TWO-FACTOR AUTHENTICATION (2FA):\n\n" +
                    "  2FA adds a second layer of security beyond your password.\n" +
                    "  Best option  — Authenticator app like Google Authenticator.\n" +
                    "  Good option  — Hardware key like YubiKey.\n" +
                    "  Acceptable   — SMS code (can be SIM-swapped so not ideal).\n\n" +
                    "  Enable 2FA on all important accounts today, " + UserName + "!");
            }

            private string GetSocialEngineeringAdvice()
            {
                return AddMemoryNote(
                    "SOCIAL ENGINEERING:\n\n" +
                    "  Attackers manipulate people, not just technology.\n" +
                    "  Pretexting — fake scenarios created to gain your trust.\n" +
                    "  Vishing    — phone call scams pretending to be IT or your bank.\n" +
                    "  Smishing   — SMS phishing messages with malicious links.\n\n" +
                    "  Always verify someone's identity before sharing any info, " +
                    UserName + "!");
            }

            private string GetWifiAdvice()
            {
                return AddMemoryNote(
                    "PUBLIC WI-FI SAFETY:\n\n" +
                    "  Always use a VPN when connecting to public Wi-Fi.\n" +
                    "  Avoid accessing banking or sensitive accounts on public networks.\n" +
                    "  Turn off auto-connect so your device does not join networks silently.\n" +
                    "  Verify the exact network name with staff before connecting.\n\n" +
                    "  When in doubt use your mobile data instead, " + UserName + "!");
            }

            private string GetPrivacyAdvice()
            {
                return AddMemoryNote(
                    "DATA PRIVACY TIPS:\n\n" +
                    "  Review app permissions — does a torch app really need your contacts?\n" +
                    "  Opt out of data sharing wherever possible.\n" +
                    "  Use encrypted messaging apps like Signal or WhatsApp.\n" +
                    "  Check haveibeenpwned.com to see if your data has been leaked.\n" +
                    "  Do not overshare personal details on social media.\n\n" +
                    "  Protect your digital footprint, " + UserName + "!");
            }

           
            private bool MatchesAny(string input, string[] keywords)
            {
                foreach (string kw in keywords)
                    if (input.Contains(kw))
                        return true;
                return false;
            }
        }
    }