using Core.Interfaces.Authentication;
using Core.Interfaces.User;
using Core.Models.Entities;
using Data;
using Microsoft.EntityFrameworkCore;
using P_Core.Interfaces.Data;
using P_Core.Models.Entities;

namespace User
{
    public class UserService : IUserService
    {
        private IDataAccessService dataService;
        public UserService()
        {
            
        }
        public UserService(IDataAccessService _dataService )
        {
            dataService = _dataService;
        }
        public UserAbstract? GetUserWithUserNameAndPassword(UserAbstract userModel)
        {
            if(userModel == null) return null;
            return null;
        }
        public UserAbstract? GetUser(int? id)
        {
            return null/*_users.FirstOrDefault(x => x.Id == id)*/;
        }

        public ICollection<UserAbstract> GetUsersWithUserType(UserTypeAbstract userTypeModel)
        {
            throw new NotImplementedException();
        }
    }

}
