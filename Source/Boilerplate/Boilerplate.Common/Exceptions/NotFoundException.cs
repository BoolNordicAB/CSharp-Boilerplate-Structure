﻿namespace Boilerplate.Common.Exceptions
{
    using System;

    public class NotFoundException : Exception
    {
        public NotFoundException(string format, params object[] arguments)
        : base(string.Format(format, arguments))
        {
        }
    }
}