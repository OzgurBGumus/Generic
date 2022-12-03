using Core.Models.Entities;
using P_Core.Models.Entities;

namespace Core.Interfaces.User
{
    public interface IUserService
    {
        UserAbstract? GetUser(int? id);
        UserAbstract? GetUserWithUserNameAndPassword(UserAbstract userModel);
        ICollection<UserAbstract> GetUsersWithUserType(UserTypeAbstract userTypeModel);
        UserAbstract? CreateUser(UserAbstract userModel);
        UserAbstract? ResetPasswordRequest(string email);
        UserAbstract? ResetPassword(string token, string userName, string newPassword);
    }
}
