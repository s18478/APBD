using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Classes1
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.Write("Enter the page address:");
            var url = Console.ReadLine();

            try
            {
                var httpClient = new HttpClient();
                var content = await httpClient.GetStringAsync(url);
                string results = string.Join(", ", ExtractEmails(content));

                if (results.Equals(""))
                    results = "No email adresses on the page !";
                
                Console.WriteLine(results);
                
                httpClient.Dispose();
            }
            catch (System.InvalidOperationException)
            {
                Console.WriteLine("Incorrect url address !");
            }
            
            //Console.WriteLine(content);
        }
        
        public static string[] ExtractEmails(string str)
        {
            string RegexPattern = @"\b[A-Z0-9._-]+@[A-Z0-9][A-Z0-9.-]{0,61}[A-Z0-9]\.[A-Z.]{2,6}\b";

            // Find matches
            System.Text.RegularExpressions.MatchCollection matches
                = System.Text.RegularExpressions.Regex.Matches(str, RegexPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            string[] MatchList = new string[matches.Count];

            // add each match
            int c = 0;
            foreach (System.Text.RegularExpressions.Match match in matches)
            {
                MatchList[c] = match.ToString();
                c++;
            }

            return MatchList;
        }
    }
}