using System;
using System.Collections.Generic;
using Boilerplate.Logic.Interfaces;
using Boilerplate.Models;
using Boilerplate.Common;
using System.Linq;

namespace Boilerplate.Logic.Simulated
{
    public class MockDataset<T> : IDataset<T>
        where T : IIdentifiable<int>
    {
        private readonly IList<T> data;

        public MockDataset(IList<T> initialData = null)
        {
            if (initialData != null)
            {
                this.data = initialData;
            }
            else
            {
                this.data = new List<T>();
            }
        }

        public void Create(T model)
        {
            this.data.Add(model);
        }

        public void Delete(int id)
        {
            var item = this.Read(id);
            this.data.Remove(item);
        }

        public bool Exists(int id)
        {
            return this.data.FirstOrDefault(a => a.Identifier == id) != null;
        }

        public T Read(int id)
        {
            return this.data.First(a => a.Identifier == id);
        }

        public IEnumerable<T> ReadAll()
        {
            return this.data.ToList() as IEnumerable<T>;
        }

        public void Update(T model)
        {
            this.Delete(model.Identifier);
            this.Create(model);
        }
    }
}