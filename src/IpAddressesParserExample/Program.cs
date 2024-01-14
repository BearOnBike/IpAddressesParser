using ParserIpAddresses.Core.Parsers;
using System.Text;

namespace ParserIpAddresses
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region Example of working with a parser
                Console.WriteLine("Parser Ip Adresses\n");
                Console.WriteLine("Example below");
                //init parser
                var parser = new IpAddressesParser();
                //init params for example
                var adresses = "0.0.0.0/*-255.255.255.255/*-127.0.0.1/*-2001:0db8:85a3:0000:0000:8a2e:0370:7334";
                var separator = "/*-";
                Console.WriteLine($"Our parameters:" +
                    $"\n1) united string of ip addresses with separators\n{adresses}" +
                    $"\n2) separator\n{separator}");

                Console.WriteLine("Run a parse phase");
                var resultIpAdressesList = parser.Parse(adresses, separator);
                
                #region Formation of the output result
                var strResult = new StringBuilder();
                foreach (var ipAdress in resultIpAdressesList)
                {
                    //we can have a lot of ip addresses, string bulder is more useful for this task, because we exclude part of the string copying process
                    //here add whitespace to ip string for visual presentation and add new string in our string builder instance 
                    var strIpWithWhitespace = String.Concat(ipAdress.ToString(), " ");
                    strResult.Append(strIpWithWhitespace);
                }
                #endregion

                Console.WriteLine($"Result \n{strResult.ToString()}");
                #endregion               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong, contact the system administrator.\n{ex.Message}");                
            }

            Console.WriteLine("Press any key for exit");
            Console.ReadKey();
        }
    }
}