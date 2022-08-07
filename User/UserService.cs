using Core.Interfaces.Authentication;
using Core.Interfaces.User;
using Core.Models.Entities;
using Data;
using Microsoft.EntityFrameworkCore;
using P_Core.Interfaces.Data;
using P_Core.Models.Entities;
using P_User.Helpers;

namespace User
{
    public class UserService : IUserService
    {
        private IDataAccessService dataService;
        private UserHelper helper;
        public UserService()
        {
            
        }
        public UserService(IDataAccessService _dataService )
        {
            dataService = _dataService;
            helper = new UserHelper();
        }


        public UserAbstract? GetUserWithUserNameAndPassword(UserAbstract userModel)
        {
            
            if(userModel == null) return null;

            var userEntity = dataService.Login(userModel.UserName, userModel.Password);
            var user = helper.toModel(userEntity);
            return user;
        }
        public UserAbstract? GetUser(int? id)
        {
            return null/*_users.FirstOrDefault(x => x.Id == id)*/;
        }
        public UserAbstract CreateUser(UserAbstract userModel)
        {
            var userEntity = helper.toEntity(userModel);
            var response = dataService.CreateUser(userEntity);
            userModel = helper.toModel(response);
            return userModel;
        }
        public ICollection<UserAbstract> GetUsersWithUserType(UserTypeAbstract userTypeModel)
        {
            throw new NotImplementedException();
        }
    }

}
