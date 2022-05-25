using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Core.Models.Models
{
    public class OGDate
    {
        public virtual int Id { get; set; }
        public virtual string Year { get; set; }
        public virtual string Month { get; set; }
        public virtual string Day { get; set; }
        public virtual string Hour { get; set; }
        public virtual string Minute { get; set; }
        public virtual string Second { get; set; }
    }
}
