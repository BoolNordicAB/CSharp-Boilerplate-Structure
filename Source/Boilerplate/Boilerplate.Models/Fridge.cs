using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.Models
{
    public class Fridge : BaseModel
    {
        public string Location { get; set; }

        public List<int> FoodstuffIdentifiers { get; set; }
    }
}