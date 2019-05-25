namespace ToXMLConverterUI
{
    using System;
    using Contract;
    using DependencyResolver;
    using Ninject;

    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new ConfigModule());
            IUrlToXmlService service = kernel.Get<IUrlToXmlService>();
            service.Run();

            Console.WriteLine("XML создан.");
            Console.ReadKey();
        }
    }
}
