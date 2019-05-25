namespace Implementations
{
    using System.IO;
    using System.Xml.Linq;
    using Contract;

    public class XmlToFileSaver : IXmlToFileSaver
    {
        private string _file;

        public XmlToFileSaver(string file)
        {
            _file = file;
        }

        public void Save(XDocument document)
        {
            using (var sw = new StreamWriter(File.Open(_file, FileMode.Create, FileAccess.ReadWrite)))
            {
                sw.Write(document.Declaration);
                sw.Write('\n');
                sw.Write(document);
            }
        }
    }
}
