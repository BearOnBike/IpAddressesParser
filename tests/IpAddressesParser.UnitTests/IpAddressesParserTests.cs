using ParserIpAddresses.Core.Parsers;
using System.Collections.ObjectModel;
using System.Net;

namespace IpAddressesParser.UnitTests;

public class IpAddressesParserTests
{
    [Fact]
    public void ParseReturnsIReadOnlyCollectionIpAddresses()
    {       
        //init parser
        var parser = new ParserIpAddresses.Core.Parsers.IpAddressesParser();
        //init params for example
        var adressesRaw = "0.0.0.0/*-255.255.255.255/*-127.0.0.1/*-2001:0db8:85a3:0000:0000:8a2e:0370:7334";
        var separator = "/*-";
        
        var resultActual = parser.Parse(adressesRaw, separator);
        var resultExpected = new List<IPAddress>() { 
            IPAddress.Parse("0.0.0.0"), IPAddress.Parse("255.255.255.255"), IPAddress.Parse("127.0.0.1"), 
            IPAddress.Parse("2001:0db8:85a3:0000:0000:8a2e:0370:7334") }
            .AsReadOnly();

        Assert.Equal(resultExpected, resultActual);
    }


    [Fact]
    public void ParseReturnCorrectExceptions() 
    {
        // init parser
        var parser = new ParserIpAddresses.Core.Parsers.IpAddressesParser();
        //init params for example
        var adressesRaw = "0.0.0.0/*-255.255.255.255/*-127.0.0.1/*-2001:0db8:85a3:0000:0000:8a2e:0370:7334";
        var separator = "/*-";

        //ArgumentNullException - Thrown when raw or separator param is null
        Assert.Throws<ArgumentNullException>(()=> parser.Parse(adressesRaw, null));
        Assert.Throws<ArgumentNullException>(() => parser.Parse(null, separator));
        //ArgumentException - Thrown when separator param is empty string
        Assert.Throws<ArgumentException>(() => parser.Parse(adressesRaw, ""));
        //FormatException - Thrown when ip address is invalid
        Assert.Throws<FormatException>(() => parser.Parse("0.0.0.0/*-255.255.255.2555", separator));
    }
}