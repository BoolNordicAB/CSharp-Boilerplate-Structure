namespace Boilerplate.Logic.Interfaces
{
    using Boilerplate.Common;
    using System;
    using System.Collections.Generic;

    public interface IDataset<T>
        where T : IIdentifiable
    {
        void Create(T model);

        T Read(int id);

        IEnumerable<T> ReadAll();

        void Update(T model);

        void Delete(int id);

        bool Exists(int id);
    }
}