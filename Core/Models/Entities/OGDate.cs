using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Core.Models.Entities
{
    public abstract class OGDate : BaseEntityAbstract
    {
        public abstract string Year { get; set; }
        public abstract string Month { get; set; }
        public abstract string Day { get; set; }
        public abstract string Hour { get; set; }
        public abstract string Minute { get; set; }
        public abstract string Second { get; set; }
    }
}
