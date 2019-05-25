namespace Contract
{
using System.Xml.Linq;

    public interface IXmlToFileSaver
    {
        void Save(XDocument document);
    }
}