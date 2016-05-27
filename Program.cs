using System;
using Twilio;

namespace WhiteRabbitJob
{
    public class Program
    {
        static void Main(string[] args)
        {
            WhiteRabbit();
        }

        public static void WhiteRabbit()
        {
            var cred = System.IO.File.ReadAllLines(@"cred.txt");
            var sid = cred[0];
            var authToken = cred[1];
            var fromShort = cred[2];
            var phoneNumbers = System.IO.File.ReadAllLines(@"phoneNumbers.txt");

            var body = "Happy White Rabbit day 🐰\n\n>>White Rabbit Bot";
            var twilio = new TwilioRestClient(sid, authToken);

            foreach (var to in phoneNumbers)
            {
                if (to.StartsWith("+")) twilio.SendMessage(fromShort, to, body);
            }
        }
    }
}
