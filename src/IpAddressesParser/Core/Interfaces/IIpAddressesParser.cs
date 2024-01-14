using System.Net;

namespace ParserIpAddresses.Core.Interfaces
{
    /// <summary>
    /// Represents a IpAddress Parser
    /// </summary>
    public interface IIpAddressesParser
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
        IReadOnlyCollection<IPAddress> Parse(string raw, string separator);
    }
}
