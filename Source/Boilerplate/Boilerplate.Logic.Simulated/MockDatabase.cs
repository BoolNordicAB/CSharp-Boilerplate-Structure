using Boilerplate.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boilerplate.Models;

namespace Boilerplate.Logic.Simulated
{
    public class MockDatabase : IDatabase
    {
        public MockDatabase()
        {
            this.Foodstuffs = new MockDataset<Foodstuff>();
            this.Fridges = new MockDataset<Fridge>();
        }

        public IDataset<Foodstuff> Foodstuffs { get; set; }

        public IDataset<Fridge> Fridges { get; set; }
    }
}