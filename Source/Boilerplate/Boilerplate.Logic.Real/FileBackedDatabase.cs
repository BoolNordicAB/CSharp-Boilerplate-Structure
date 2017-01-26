namespace Boilerplate.Logic.Real
{
    using Boilerplate.Models;
    using Interfaces;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public class FileBackedDatabase : IDatabase
    {
        public FileBackedDatabase()
        {
            this.Foodstuffs = new FileBackedDataset<Foodstuff>(@"Data\foodstuffs.json");
            this.Fridges = new FileBackedDataset<Fridge>(@"Data\fridges.json");
        }

        public IDataset<Foodstuff> Foodstuffs { get; set; }

        public IDataset<Fridge> Fridges { get; set; }
    }
}