using ParserIpAddresses.Core.Interfaces;
using System.Net;


namespace ParserIpAddresses.Core.Parsers
{
    /// <summary>
    /// Implementation of the Ip Addresses parser
    /// </summary>
    public class IpAddressesParser: IIpAddressesParser
    {
        /// <summary>
        /// Returns parsed list of ip addresses
        /// </summary>
        /// <param name="raw">raw list of ip addresses</param>
        /// <param name="separator">ip addresses separator</param>
        /// <returns>List of ip addresses</returns>
        /// <exception cref="ArgumentNullException">Thrown when raw or separator param is null</exception>
        /// <exception cref="ArgumentException">Thrown when separator param is empty string</exception>
        /// <exception cref="FormatException">Thrown when ip address is invalid</exception>
        public IReadOnlyCollection<IPAddress> Parse(string raw, string separator) 
        {           
            if (raw == null) throw new ArgumentNullException(nameof(raw), "Param raw list of ip addresses is null!");
            if (separator == null) throw new ArgumentNullException(nameof(separator), "Param ip addresses separator is null!");
            if (separator == string.Empty) throw new ArgumentException($"Param ip addresses separator is empty!",nameof(separator));

            var res = new List<IPAddress>();

            var adressesArray = raw.Split(separator, StringSplitOptions.RemoveEmptyEntries); //this option delete empty entries when separator added twice
            foreach (var addressRaw in adressesArray)
            {
                if (!IPAddress.TryParse(addressRaw, out var address)) throw new FormatException($"Ip address {addressRaw} is invalid!");

                res.Add(address);
            }

            return res.AsReadOnly();
        }        
    }
}
