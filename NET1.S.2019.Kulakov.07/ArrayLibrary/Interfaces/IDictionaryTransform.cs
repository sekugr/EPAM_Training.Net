namespace ArrayLibrary.Interfaces
{
    using System.Collections.Generic;

    public interface IDictionaryTransform
    {
        Dictionary<double, string> GetSpeсialDoubles();

        Dictionary<char, string> GetWords();
    }
}
