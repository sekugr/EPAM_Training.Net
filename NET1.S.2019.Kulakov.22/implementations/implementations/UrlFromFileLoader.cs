namespace Implementations
{
    using System.Collections.Generic;
    using System.IO;
    using Contract;

    public class UrlFromFileLoader : IUrlFromFileLoader
    {
        private string _file;

        public UrlFromFileLoader(string sourceFileName)
        {
            _file = sourceFileName;
        }

        public IEnumerable<string> Load()
        {
            using (var sourceStream = new StreamReader(File.Open(_file, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
            {
                string source = sourceStream.ReadLine();

                while (!string.IsNullOrEmpty(source))
                {
                    yield return source;
                    source = sourceStream.ReadLine();
                }
            }
        }
    }
}
