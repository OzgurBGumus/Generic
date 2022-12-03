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
        public virtual List<Permission> Permissions { get; set; }
        public virtual List<User> Users { get; set; }
        

        public virtual string toLogString()
        {
            var currentTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            var userTypeString = "UserType: [Key:" + Key + "]";
            var LogString = "[" + currentTime + "]  " + userTypeString + "]";
            return LogString;
        }
    }
}
