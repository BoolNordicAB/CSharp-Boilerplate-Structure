namespace Boilerplate.Common
{
    using System;

    public interface IIdentifiable<T>
        where T : IEquatable<T>
    {
        T Identifier { get; }
    }
}