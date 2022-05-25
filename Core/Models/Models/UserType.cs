using P_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Core.Models.Models
{
    public class UserType
    {
        public virtual int Id { get; set; }
        public virtual string Key { get; set; }
        public virtual string Description { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
        public virtual ICollection<User> User { get; set; }
        

        public virtual string toLogString()
        {
            throw new NotImplementedException();
        }
    }
}
