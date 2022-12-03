using Core.Models.Entities;
using P_Core.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Core.Interfaces.Data
{
    public interface IDataAccessService
    {
        #region User
        public User Login(string userName, string password);
        public User CreateUser(User entity);
        public User? GetUser(int? Id);
        public User? GetUser(string? email = null, string? phoneNumber = null);
        public List<User>? GetUsers(UserType type);
        public User? PasswordResetRequest(User entity);
        public User? PasswordReset(string token, string userName, string newPassword);
        public User? RemoveUserTypeFromUser(int userId, string key);
        #endregion


        #region UserType
        public UserType? GetUserType(int id, string key);
        public List<UserType>? GetUserUserTypes(int? userId);
        public UserType? InsertUserType(string key, string description);
        public UserType? UpdateUserType(string key, string description);
        public UserType? RemovePermissionFromUserType(int userTypeId, string key);
        #endregion

        #region Permission
        public Permission? GetPermission(int id=0, string key="");
        public List<Permission>? GetPermissions(UserType userType);
        public List<Permission>? GetPermissions(User user);
        public Permission? InsertPermission(string key, string description);
        public Permission? UpdatePermission(string key, string description);
        #endregion

        #region GeneralLog
        public GeneralLog InsertGeneralLog(string type, string message, string destination, string obj = "");
        #endregion
    }
}
