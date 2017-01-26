namespace Boilerplate.Common.Exceptions
{
    using System;

    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string format, params object[] arguments)
        : base(string.Format(format, arguments))
        {
        }
    }
}