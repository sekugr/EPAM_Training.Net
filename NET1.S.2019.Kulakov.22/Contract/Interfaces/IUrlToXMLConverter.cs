namespace Contract
{
using System.Collections.Generic;
using System.Xml.Linq;

    public interface IUrlToXMLConverter
    {
        XDocument Convert(IEnumerable<string> urls);
    }
}