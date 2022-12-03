using P_Core.Models.Entities;
using P_Core.Models.Models;

namespace P_StartupV0001.Models
{
    public class Permission : PermissionAbstract
    {
        public override string Key { get; set; }
        public override string Description { get; set; }
        public override Status Status { get; set; }
        public override int Id { get; set; }
        public override ICollection<UserTypeAbstract> UserTypes { get; set; }

        public override string toLogString()
        {
            var currentTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            var permissionString = "permission: [Key:" + Key + "]";
            var LogString = "[" + currentTime + "]  " + permissionString + "]";
            return LogString;
        }
    }
}
