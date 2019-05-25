namespace Implementations
{
    using System;
    using System.Collections.Generic;
    using Contract;

    public class URLsValidator : IURLsValidator
    {
        private IURLLogger _logger;

        public URLsValidator()
        {
            _logger = new URLLogger();
        }

        public IEnumerable<string> ValidSource(IEnumerable<string> source)
        {
            foreach (string item in source)
            {
                if (IsValid(item))
                {
                    yield return item;
                }
                else
                {
                    _logger.Log(item);
                }
            }
        }

        public void NewLogger(IURLLogger logger)
        {
            this._logger = logger;
        }

        private bool IsValid(string source)
        {
            return Uri.IsWellFormedUriString(source, UriKind.Absolute);
        }
    }
}
