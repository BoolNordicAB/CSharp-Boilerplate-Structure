using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.Models
{
    public class Foodstuff : BaseModel
    {
        public string Name { get; set; }

        public DateTime BestBeforeDate { get; set; }
    }
}