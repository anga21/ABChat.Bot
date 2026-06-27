using System;
using System.Collections.Generic;

namespace VAchatBox2
{
    public class QuizQuestion
    {
        public string Question { get; set; }
        public string[] Options { get; set; }
        public int CorrectIndex { get; set; }
        public string Explanation { get; set; }
        public bool IsTrueFalse { get; set; }
    }

    public static class QuizEngine
    {
        private static readonly List<QuizQuestion> _questions = new List<QuizQuestion>
        {
            
            new QuizQuestion {
                Question     = "What does 2FA stand for?",
                Options      = new[] { "Two File Access",
                                       "Two-Factor Authentication",
                                       "Trusted Firewall Agent",
                                       "Transfer File Approval" },
                CorrectIndex = 1,
                Explanation  = "Two-Factor Authentication adds a second verification step beyond your password."
            },
            new QuizQuestion {
                Question     = "Which of these is the STRONGEST password?",
                Options      = new[] { "password123", "MyDog2010",
                                       "$kY!r4in#Bol7", "qwerty" },
                CorrectIndex = 2,
                Explanation  = "A mix of symbols, numbers, upper and lower case makes passwords much harder to crack."
            },
            new QuizQuestion {
                Question     = "What is phishing?",
                Options      = new[] { "A type of antivirus",
                                       "Fraudulent messages designed to steal your info",
                                       "A secure email protocol",
                                       "A firewall configuration" },
                CorrectIndex = 1,
                Explanation  = "Phishing tricks you into revealing passwords or personal data via fake messages."
            },
            new QuizQuestion {
                Question     = "What should you do on public Wi-Fi?",
                Options      = new[] { "Log into your bank immediately",
                                       "Use a VPN to encrypt your traffic",
                                       "Turn off your firewall",
                                       "Share your mobile hotspot" },
                CorrectIndex = 1,
                Explanation  = "A VPN encrypts your traffic so attackers on the same network cannot read it."
            },
            new QuizQuestion {
                Question     = "What does HTTPS tell you about a website?",
                Options      = new[] { "The site loads faster",
                                       "The site is government-owned",
                                       "The connection is encrypted",
                                       "The site contains no ads" },
                CorrectIndex = 2,
                Explanation  = "HTTPS uses TLS encryption to protect data between your browser and the server."
            },
            new QuizQuestion {
                Question     = "What should you do if you receive an email asking for your password?",
                Options      = new[] { "Reply with your password",
                                       "Delete the email",
                                       "Report it as phishing",
                                       "Ignore it" },
                CorrectIndex = 2,
                Explanation  = "Legitimate organisations never ask for your password by email. Always report phishing."
            },
            new QuizQuestion {
                Question     = "What is ransomware?",
                Options      = new[] { "Software that speeds up your PC",
                                       "Malware that locks your files and demands payment",
                                       "A type of firewall",
                                       "A secure password manager" },
                CorrectIndex = 1,
                Explanation  = "Ransomware encrypts your files and demands a ransom payment to restore access."
            },
            new QuizQuestion {
                Question     = "Which is the SAFEST way to store passwords?",
                Options      = new[] { "Written on a sticky note on your monitor",
                                       "Saved in a plain text file",
                                       "Memorised without writing down",
                                       "Stored in a reputable password manager" },
                CorrectIndex = 3,
                Explanation  = "Password managers like Bitwarden generate and securely store strong unique passwords."
            },
            new QuizQuestion {
                Question     = "What is social engineering?",
                Options      = new[] { "Building social media apps",
                                       "Manipulating people into revealing confidential info",
                                       "Engineering a social network",
                                       "A type of antivirus software" },
                CorrectIndex = 1,
                Explanation  = "Social engineering exploits human psychology rather than technical vulnerabilities."
            },
            new QuizQuestion {
                Question     = "Which authentication method is MOST secure?",
                Options      = new[] { "SMS one-time code",
                                       "Security question",
                                       "Authenticator app (e.g. Google Authenticator)",
                                       "Email verification link" },
                CorrectIndex = 2,
                Explanation  = "Authenticator apps generate time-based codes locally and cannot be SIM-swapped."
            },
            new QuizQuestion {
                Question     = "What does a VPN primarily protect you from?",
                Options      = new[] { "Viruses and malware",
                                       "Weak passwords",
                                       "Traffic interception on public networks",
                                       "Phishing emails" },
                CorrectIndex = 2,
                Explanation  = "A VPN encrypts your internet traffic, protecting it from eavesdroppers on the network."
            },

           
            new QuizQuestion {
                IsTrueFalse  = true,
                Question     = "TRUE or FALSE: You should use the same password for all your accounts to make it easier to remember.",
                Options      = new[] { "True", "False" },
                CorrectIndex = 1,
                Explanation  = "Reusing passwords is dangerous. If one account is breached, all others become vulnerable."
            },
            new QuizQuestion {
                IsTrueFalse  = true,
                Question     = "TRUE or FALSE: HTTPS means a website is completely safe and trustworthy.",
                Options      = new[] { "True", "False" },
                CorrectIndex = 1,
                Explanation  = "HTTPS only means the connection is encrypted — phishing sites can also use HTTPS."
            },
            new QuizQuestion {
                IsTrueFalse  = true,
                Question     = "TRUE or FALSE: Antivirus software alone is enough to keep your device fully secure.",
                Options      = new[] { "True", "False" },
                CorrectIndex = 1,
                Explanation  = "Antivirus is one layer. You also need strong passwords, 2FA, updates, and safe habits."
            },
            new QuizQuestion {
                IsTrueFalse  = true,
                Question     = "TRUE or FALSE: Enabling two-factor authentication significantly improves account security.",
                Options      = new[] { "True", "False" },
                CorrectIndex = 0,
                Explanation  = "2FA makes it much harder for attackers to access your account even if they have your password."
            },
            new QuizQuestion {
                IsTrueFalse  = true,
                Question     = "TRUE or FALSE: It is safe to click links in emails from unknown senders if the email looks professional.",
                Options      = new[] { "True", "False" },
                CorrectIndex = 1,
                Explanation  = "Professional-looking emails can still be phishing. Always verify the sender before clicking."
            },
        };

        private static readonly Random _rng = new Random();

        public static List<QuizQuestion> GetRandomQuestions(int count = 5)
        {
            var pool = new List<QuizQuestion>(_questions);
            for (int i = pool.Count - 1; i > 0; i--)
            {
                int j = _rng.Next(i + 1);
                var tmp = pool[i]; pool[i] = pool[j]; pool[j] = tmp;
            }
            return pool.GetRange(0, Math.Min(count, pool.Count));
        }
    }
}
