using P_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Core.Models.Models
{
    public class Permission
    {
        public virtual string Key { get; set; }
        public virtual string Description { get; set; }
        public virtual Status Status { get; set; }
        public virtual int Id { get; set; }
        public virtual ICollection<UserType> UserTypes { get; set; }

        public virtual string toLogString()
        {
            throw new NotImplementedException();
        }
    }
}
