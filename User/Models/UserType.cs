using P_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_User.Models
{
    public class UserType : UserTypeAbstract
    {

        public UserType(int id = 0, string key="", string description="")
        {
            Id=id;
            Key=key;
            Description=description;
        }
        public override int Id { get; set; }
        public override string Key { get; set; }
        public override string Description { get; set; }
        public override ICollection<PermissionAbstract> Permissions { get; set; }
        public override ICollection<UserTypeAbstract> Users { get; set; }

        public override string toLogString()
        {
            var currentTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            var userTypeString = "UserType: [Key:" + Key + "]";
            var LogString = "[" + currentTime + "]  " + userTypeString + "]";
            return LogString;
        }
    }
    
}
