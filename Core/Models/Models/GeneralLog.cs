using P_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Core.Models.Models
{
    public class GeneralLog
    {
        public virtual int Id { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string Type { get; set; }
        public virtual string Message { get; set; }
        public virtual string Object { get; set; }
        public virtual string Destination { get; set; }
    }
}
