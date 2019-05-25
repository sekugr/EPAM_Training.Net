namespace DependencyResolver
{
using Contract;
using Implementations;
using Ninject.Modules;

    public class ConfigModule : NinjectModule
    {
        public override void Load()
        {
            string source = "source.txt";
            string result = "result.xml";
            this.Bind<IURLLogger>().To<URLLogger>();
            
            this.Bind<IUrlFromFileLoader>().To<UrlFromFileLoader>()
                .WithConstructorArgument("sourceFileName", source);
            this.Bind<IURLsValidator>().To<URLsValidator>();
            this.Bind<IUrlToXMLConverter>().To<UrlToXMLConverter>();
            this.Bind<IUrlToXmlService>().To<UrlToXmlService>();
            this.Bind<IXmlToFileSaver>().To<XmlToFileSaver>()
                .WithConstructorArgument("file", result);
        }
    }
}
