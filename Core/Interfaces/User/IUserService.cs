using Core.Models.Entities;
using P_Core.Models.Entities;

namespace Core.Interfaces.User
{
    public interface IUserService
    {
        UserAbstract? GetUser(int? id);
        UserAbstract? GetUserWithUserNameAndPassword(UserAbstract userModel);
        ICollection<UserAbstract> GetUsersWithUserType(UserTypeAbstract userTypeModel);
    }
}
