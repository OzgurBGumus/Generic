using P_Core.Models.Entities;

namespace P_StartupV0001.Models
{
    public class UserType : UserTypeAbstract
    {
        public override string Key { get; set; }
        public override string Description { get; set; }
        public override ICollection<PermissionAbstract> Permissions { get; set; }
        public override int Id { get; set; }
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
