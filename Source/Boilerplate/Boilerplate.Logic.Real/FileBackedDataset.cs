namespace Boilerplate.Logic.Real
{
    using System;
    using Boilerplate.Logic.Interfaces;
    using Boilerplate.Models;
    using Boilerplate.Common;
    using Data;
    using System.Collections.Generic;
    using System.Linq;
    using Common.Exceptions;

    internal class FileBackedDataset<T> : IDataset<T>
        where T : IIdentifiable<int>
    {
        private readonly string relativeFileName;

        private IList<T> data = null;

        public FileBackedDataset(string relativeFileName)
        {
            this.relativeFileName = relativeFileName;
            this.data = DataUtility.Load<T>(this.relativeFileName);
        }

        public void Create(T model)
        {
            if (model.Identifier == 0)
            {
                throw new InvalidIdentifierException("{0} is not a valid Id", model.Identifier);
            }
            else if (this.Exists(model.Identifier))
            {
                throw new AlreadyExistsException("Item already exists, Id={0}", model.Identifier);
            }

            this.data.Add(model);
            this.Persist();
        }

        public void Delete(int id)
        {
            var item = this.Read(id);
            this.data.Remove(item);
            this.Persist();
        }

        public T Read(int id)
        {
            var result = this.data.FirstOrDefault(item => item.Identifier == id);
            if (result == null)
            {
                throw new NotFoundException("Could not find item with Id={0}", id);
            }

            return result;
        }

        public void Update(T model)
        {
            var existing = this.Read(model.Identifier);
            this.Delete(existing.Identifier);
            this.Create(model);
            this.Persist();
        }

        public IEnumerable<T> ReadAll()
        {
            return this.data.ToList() as IEnumerable<T>;
        }

        public bool Exists(int id)
        {
            return this.data.FirstOrDefault(item => item.Identifier == id) != null;
        }

        private void Persist()
        {
            DataUtility.Overwrite(this.relativeFileName, this.data);
        }
    }
}