namespace Contract
{
using System.Collections.Generic;

    public interface IURLsValidator
    {
        IEnumerable<string> ValidSource(IEnumerable<string> source);
    }
}