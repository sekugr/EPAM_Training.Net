namespace Implementations
{
    using Contract;

    public class UrlToXmlService : IUrlToXmlService
    {
        private IUrlFromFileLoader _loader;
        private IURLsValidator _validator;
        private IUrlToXMLConverter _converter;
        private IXmlToFileSaver _saver;

        public UrlToXmlService(IUrlFromFileLoader loader, IURLsValidator validator, IUrlToXMLConverter converter, IXmlToFileSaver saver)
        {
            _loader = loader;
            _validator = validator;
            _converter = converter;
            _saver = saver;
        }

        public void Run()
        {
            // XDocument xd = _converter.Convert(_validator.ValidSource(_loader.Load()));
            // _saver.Save(xd);
            _saver.Save(_converter.Convert(_validator.ValidSource(_loader.Load())));
        }
    }
}
