using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Core.Models.Entities
{
    public abstract class GeneralLogAbstract : BaseEntityAbstract
    {
        public abstract DateTime Date  { get; set; }
        public abstract string Type { get; set; }
        public abstract string Message { get; set; }
        public abstract string Object { get; set; }
        public abstract string Destination { get; set; }
    }
}
