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


        public string GetResponse(string input)
        {
                    if(string.IsNullOrWhiteSpace(input))
                        return "Please type a question or keyword";

          string trimmed = input.Trim();

            if (trimmed.Length < 2)
                return "That is too short.Try a full word or topic!";

            string lower = trimmed.ToLower();


                    if (MatchesAny(lower, "how are you", "you okay"))
                        return "I am fullyOJIH operational and ready to keep you safe, " + UserName + "!";


          if(MatchesAny(lower, "purpose", "what do you do", "help", "topics","what can"))
                  return GetTopicsList();

            if (MatchesAny(lower, "password", "passwords", "passphrase") )
                return GetPasswordAdvice();

          if(MatchesAny(lower, "phishing", "scam email" ,"fake email" ))
                    return GetPhishingAdvice();

            if(MatchesAny(lower, "malware", "virus" , "ransomware","spyware", "trojan"))
                 return GetMalwareAdvice();

            if(MatchesAny(lower, "browsing", "safe browsing", "https", "website", "vpn"))
                return GetSafeBrowsingAdvice();

                 if (MatchesAny(lower, "2fa", "mfa", "two factor","multi factor","authenticator"))
                return GetMFAAdvice();

            if (MatchesAny(lower, "social engineering", "pretexting", "vishing", "smishing"))
               return GetSocialEngineeringAdvice();

                if(MatchesAny(lower, "wifi","wi-fi","public wifi", "hotspot") )
                return GetWifiAdvice();

            if(MatchesAny(lower,"privacy", "personal data", "data breach", "gdpr"))
                return GetPrivacyAdvice();

            if (MatchesAny(lower, "quit","bye","goodbye","exit" ))
                     return "QUIT_SIGNAL";

            return "I did not quite understand that, " + UserName +
                   ". Could you rephrase? Type 'topics' to see everything I can help with.";
        }

       
        private bool MatchesAny(string input, params string[] keywords)
        {
            foreach (var word in keywords)
            {
                if(input.Contains(word))
                    return true;
            }
            return false;
        }


        private string GetTopicsList()
        {
            return "Here is what I can help you with, " + UserName + ":\n\n" +
                   "  passwords       - Strong passwords and managers\n" +
                   "  phishing        - Spotting email scams\n" +
                   "  safe browsing   - Staying safe on the web\n" +
                   "  malware         - Viruses, ransomware and more\n" +
                   "  social eng.     - Manipulation tactics\n" +
                   "  2fa             - Two-factor authentication\n" +
                   "  data privacy    - Protecting personal info\n" +
                   "  public wifi     - Risks of public networks\n\n" +
                   "Just type any topic!";
        }

        private string GetPasswordAdvice()
        {
            return "PASSWORD SAFETY TIPS:\n\n" +
                   "  Use at least 12 to 16 characters\n" +
                   "  Mix uppercase, lowercase, numbers and symbols\n" +
                   "  Never use personal info like birthdays\n" +
                    "  Use a different password for every account\n" +
                   "  Consider a password manager\n" +
                   "  Never share your password with anyone\n\n" +
                   "Your password is your first line of defence, " + UserName + "!";
        }

        private string GetPhishingAdvice()
        {
            return "PHISHING TIPS:\n\n" +
                   "  Do not click suspicious links\n" +
                   "  Check sender email carefully\n" +
                   "  Watch for urgent language\n" +
                   "  Never enter credentials on unknown sites\n\n" +
                   "Stay alert, " + UserName + "!";
      }

        private string GetMalwareAdvice()
         {
            return "MALWARE TIPS:\n\n" +
                   "  Install antivirus software\n" +
                   "  Keep your system updated\n" +
                   "  Avoid downloading unknown files\n\n" +
                   "Stay protected," + UserName + "!";
        }

             private string GetSafeBrowsingAdvice()
        {
            return "SAFE BROWSING:\n\n" +
                   "  Look for HTTPS in URLs\n" +
                   "  Avoid suspicious websites\n" +
                   "  Use a VPN on public networks\n\n" +
                   "Browse smart," + UserName + "!";
        }

        private string GetMFAAdvice() {
            return "2FA / MFA:\n\n" +
                   "  Adds extra security layer\n" +
                   "  Use authenticator apps\n" +
                   "  Avoid SMS if possible\n\n" +
                   "Lock it down, " + UserName + "!";
        }

        private string GetSocialEngineeringAdvice()
        {
            return "SOCIAL ENGINEERING:\n\n" +
                   "  Attackers manipulate people\n" +
                   "  Verify identities before trusting\n" +
                   "  Do not share sensitive info\n\n" +
                   "Think before you trust, " + UserName + "!";
           }

        private string GetWifiAdvice()
        {
            return "PUBLIC WIFI:\n\n" +
                   "  Avoid sensitive transactions\n" +
                   "  Use a VPN\n" +
                   "  Turn off auto-connect\n\n" +
                   "Stay cautious, " + UserName + "!";
        }

        private string GetPrivacyAdvice()
        {
            return "DATA PRIVACY:\n\n" +
                   "  Limit personal info shared online\n" +
                   "  Use strong privacy settings\n" +
                   "  Monitor for breaches\n\n" +
                   "Protect your digital footprint, " + UserName +"!";
     }
    }
}