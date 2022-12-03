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


        #region User
        public UserAbstract? GetUserWithUserNameAndPassword(UserAbstract userModel)
        {
            try
            {
                if (userModel == null) throw new ArgumentNullException("user is null.");

                var userEntity = dataService.Login(userModel.UserName, userModel.Password);
                userEntity.UserTypes = dataService.GetUserUserTypes(userEntity.Id);
                var user = helper.toModel(userEntity);
                return user;
            }
            catch (Exception ex)
            {
                dataService.InsertGeneralLog("error", ex.Message, "GetUserWithUserNameAndPassword", userModel.toLogString());
                throw ex;
            }
        }
        public UserAbstract? GetUser(int? id)
        {
            try
            {
                if (id == null) throw new ArgumentNullException("id is null.");
                var userEntity = dataService.GetUser(id);
                var user = helper.toModel(userEntity);
                return user;
            }
            catch (Exception ex)
            {
                dataService.InsertGeneralLog("error", ex.Message, "GetUser", id==null?"0":id.ToString());
                throw ex;
            }
            
        }
        public UserAbstract CreateUser(UserAbstract userModel)
        {
            try
            {
                var userEntity = helper.toEntity(userModel);
                var response = dataService.CreateUser(userEntity);
                userModel = helper.toModel(response);
                return userModel;
            }
            catch(Exception ex)
            {
                dataService.InsertGeneralLog("error", ex.Message, "CreateUser", userModel.toLogString());
                throw ex;
            }
        }
        public UserAbstract? ResetPasswordRequest(string email)
        {
            try
            {
                var user = dataService.GetUser(email);
                if (user == null) throw new ArgumentNullException("user is null");

                var response = dataService.PasswordResetRequest(user);
                return helper.toModel(response);
            }
            catch(Exception ex)
            {
                dataService.InsertGeneralLog("error", ex.Message, "ResetPasswordRequest", email);
                throw ex;
            }
        }
        public UserAbstract? ResetPassword(string token, string userName, string newPassword)
        {
            try
            {
                if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(newPassword))
                    throw new ArgumentNullException("at least one of the parameter is null. (token, userName, newPassword)");

                var response = dataService.PasswordReset(token, userName, newPassword);
                return helper.toModel(response);
            }
            catch (Exception ex)
            {
                dataService.InsertGeneralLog("error", ex.Message, "ResetPassword", "userName:"+userName);
                throw ex;
            }
            
            
        }
        public ICollection<UserAbstract> GetUsersWithUserType(UserTypeAbstract userTypeModel)
        {
            try
            {
                if (userTypeModel?.Id == null) throw new ArgumentNullException("userType or it's ID is null.");
                var users = dataService.GetUsers(helper.toEntity(userTypeModel));
                return helper.toModel(users);
            }
            catch (Exception ex)
            {
                dataService.InsertGeneralLog("error", ex.Message, "GetUsersWithUserType", userTypeModel.toLogString());
                throw ex;
            }

        }
        #endregion
        #region UserType
        public UserTypeAbstract GetUserType(int id=0, string key = "")
        {
            try
            {
                if (id == 0 && string.IsNullOrEmpty(key)) throw new ArgumentNullException("id or key is invalid.");

                var userType = dataService.GetUserType(id, key);
                return helper.toModel(userType);
            }
            catch (Exception ex)
            {
                dataService.InsertGeneralLog("error", ex.Message, "GetUserType", id+", "+key);
                throw ex;
            }
        }
        public ICollection<UserTypeAbstract> GetUserUserTypes(int userId)
        {
            try
            {
                if (userId == 0) throw new ArgumentNullException("id is invalid.");

                var userTypes = dataService.GetUserUserTypes(userId);
                if (userTypes == null) throw new ArgumentNullException("Couldn't Get UserType.");

                return helper.toModel(userTypes);
            }
            catch(Exception ex)
            {
                dataService.InsertGeneralLog("error", ex.Message, "GetUserUserTypes", userId.ToString());
                throw ex;
            }
            
        }
        public UserTypeAbstract InsertUserType(string key, string description)
        {
            try
            {
                if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("key is null");
                if (string.IsNullOrEmpty(description)) throw new ArgumentNullException("Description is null");

                var userType = dataService.InsertUserType(key, description);
                if (userType == null) throw new ArgumentNullException("Couldn't Insert UserType.");

                return helper.toModel(userType);
            }
            catch(Exception ex)
            {
                dataService.InsertGeneralLog("error", ex.Message, "InsertUserType", key+", "+description);
                throw ex;
            }
        }
        public UserTypeAbstract UpdateUserType(string key, string description)
        {
            try
            {
                if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("key is null");
                if (string.IsNullOrEmpty(description)) throw new ArgumentNullException("Description is null");

                var userType = dataService.UpdateUserType(key, description);
                if (userType == null) throw new ArgumentNullException("Couldn't Update UserType.");

                return helper.toModel(userType);
            }
            catch (Exception ex)
            {
                dataService.InsertGeneralLog("error", ex.Message, "UpdateUserType", key + ", " + description);
                throw ex;
            }
        }
        #endregion

        #region Permission
        public PermissionAbstract GetPermission(int id = 0, string key ="")
        {
            try
            {
                if (id == 0 && string.IsNullOrEmpty(key)) throw new ArgumentNullException("id or key is invalid.");

                var permission = dataService.GetPermission(id, key);
                return helper.toModel(permission);
            }
            catch(Exception ex)
            {
                dataService.InsertGeneralLog("error", ex.Message, "GetPermission", id + ", " + key);
                throw ex;
            }
        }
        public List<PermissionAbstract> GetPermissions(UserTypeAbstract userType)
        {
            try
            {
                if (userType?.Id == null || userType?.Id == 0) throw new ArgumentNullException("userType is invalid.");

                var permission = dataService.GetPermissions(helper.toEntity(userType));
                return helper.toModel(permission);
            }
            catch(Exception ex)
            {
                dataService.InsertGeneralLog("error", ex.Message, "GetPermissions", userType.toLogString());
                throw ex;
            }
            
        }
        public List<PermissionAbstract> GetPermissions(UserAbstract user)
        {
            try
            {
                if (user?.Id == null || user?.Id == 0) throw new ArgumentNullException("user is invalid.");

                var permission = dataService.GetPermissions(helper.toEntity(user));
                return helper.toModel(permission);
            }
            catch (Exception ex)
            {
                dataService.InsertGeneralLog("error", ex.Message, "GetPermissions", user.toLogString());
                throw ex;
            }
        }
        public PermissionAbstract InsertPermission(string key, string description)
        {
            try
            {
                if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("key is null");
                if (string.IsNullOrEmpty(description)) throw new ArgumentNullException("Description is null");

                var permission = dataService.InsertPermission(key, description);
                if (permission == null) throw new ArgumentNullException("Couldn't Insert Permission.");

                return helper.toModel(permission);
            }
            catch (Exception ex)
            {
                dataService.InsertGeneralLog("error", ex.Message, "InsertPermission", key + ", " + description);
                throw ex;
            }
        }
        public PermissionAbstract UpdatePermission(string key, string description)
        {
            try
            {
                if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("key is null");
                if (string.IsNullOrEmpty(description)) throw new ArgumentNullException("Description is null");

                var permission = dataService.UpdatePermission(key, description);
                if (permission == null) throw new ArgumentNullException("Couldn't Update Permission.");

                return helper.toModel(permission);
            }
            catch(Exception ex)
            {
                dataService.InsertGeneralLog("error", ex.Message, "UpdatePermission", key + ", " + description);
                throw ex;
            }
        }
        
        #endregion
    }

}
