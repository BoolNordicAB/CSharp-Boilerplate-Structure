using Boilerplate.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.Models
{
    public abstract class BaseModel : IIdentifiable
    {
        public int Identifier { get; set; }

        public BaseModel()
        {
            this.Identifier = 0;
        }
    }
}