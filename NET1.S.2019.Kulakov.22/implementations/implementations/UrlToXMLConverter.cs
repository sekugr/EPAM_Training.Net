namespace Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Xml.Linq;
    using Contract;

    public class UrlToXMLConverter : IUrlToXMLConverter
    {
        public XDocument Convert(IEnumerable<string> urls)
        {
            XDocument xd = new XDocument(new XDeclaration("1.0", "utf-8", "no"), new XElement("urlAdresses"));
            xd.Root.Add(urls.Select(x => (new XElement("urlAdress",
            new XElement("host",
            new XAttribute("name", new Uri(x).Host)), GetSegments(new Uri(x)), GetParams(new Uri(x))))));
            return xd;
        }

        private XElement GetSegments(Uri source)
        {
            if (source.Segments.Count() > 0)
            {
                XElement element = new XElement("uri");
                foreach (string item in source.Segments)
                {
                    if (item.Trim('/').Length > 0)
                    {
                        element.Add(new XElement("segment", item.Trim('/')));
                    }
                }

                return element;
            }

            return null;
        }

        private XElement GetParams(Uri source)
        {
            var parametrValue = HttpUtility.ParseQueryString(source.Query);
            if (parametrValue.Count > 0)
            {
                XElement element = new XElement("parameters");
                foreach (string item in parametrValue)
                {
                    element.Add(new XElement("parametr", new XAttribute("value", parametrValue.Get(item)), new XAttribute("key", item)));
                }

                return element;
            }

            return null;
        }
    }
}
