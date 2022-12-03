using P_Core.Models.Entities;
using P_Core.Models.Models;

namespace Core.Models.Entities
{
    public abstract class UserAbstract : BaseEntityAbstract
    {
        public abstract string UserName { get; set; }
        public abstract string Password { get; set; }
        public abstract string JwtToken { get; set; }

        public abstract string FirstName { get; set; }
        public abstract string LastName { get; set; }
        public abstract string Email { get; set; }
        public abstract string PhoneNumber { get; set; }
        public abstract string PasswordResetToken { get; set; }

        public abstract bool EmailConfirm { get; set; }
        public abstract bool PhoneConfirm { get; set; }
        public abstract int Status { get; set; }
        public abstract IEnumerable<UserTypeAbstract> UserTypes { get; set; }

        
    }
}
