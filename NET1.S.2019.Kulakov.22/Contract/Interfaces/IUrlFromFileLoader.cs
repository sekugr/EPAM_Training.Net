namespace Contract
{
    using System.Collections.Generic;

    public interface IUrlFromFileLoader
    {
        IEnumerable<string> Load();
    }
}