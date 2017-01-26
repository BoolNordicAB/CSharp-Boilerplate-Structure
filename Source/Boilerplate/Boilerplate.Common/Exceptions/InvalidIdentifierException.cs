namespace Boilerplate.Common.Exceptions
{
    using System;

    public class InvalidIdentifierException : Exception
    {
        public InvalidIdentifierException(string format, params object[] arguments)
        : base(string.Format(format, arguments))
        {
        }
    }
}