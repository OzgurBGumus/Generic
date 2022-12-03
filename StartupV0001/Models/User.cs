using Core.Models.Entities;
using P_Core.Models.Entities;

namespace StartupV0001.Models
{
    public class User : UserAbstract
    {
        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
        public override int Id { get; set; }
        public override int Status { get; set; }
        public override string UserName { get; set; }
        public override string Password { get; set; }
        public override string JwtToken { get; set; }
        public override string FirstName { get; set; }
        public override string LastName { get; set; }
        public override string Email { get; set; }
        public override string PhoneNumber { get; set; }
        public override string PasswordResetToken { get; set; }
        public override bool EmailConfirm { get; set; }
        public override bool PhoneConfirm { get; set; }
        public override IEnumerable<UserTypeAbstract> UserTypes { get; set; }
        public override string toLogString()
        {
            var currentTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            var userString = "User: [Id:" + Id + ", UserName:" + UserName + ", FullName:" + FirstName + " " + LastName + ", Email:" + Email + ", PhoneNumber:" + PhoneNumber + "]";
            var LogString = "[" + currentTime + "]  " + userString + "]";
            return LogString;
        }
    }
}
