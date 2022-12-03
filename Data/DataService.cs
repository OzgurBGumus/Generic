using Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using P_Core;
using P_Core.Interfaces.Data;
using P_Core.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataService : IDataAccessService
    {
        private DataContext _context;
        public DataService(DataContext dbContext)
        {
            _context = dbContext;
        }

        #region User
        public User CreateUser(User entity)
        {
            try
            {
                var response = _context.Add(entity);
                _context.SaveChanges();
                return response.Entity;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        public User? GetUser(int? id)
        {
            try
            {
                if (id == null) return null;
                var response = _context.User.Where(x=>x.Id == id).FirstOrDefault();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public User? GetUser(string? email = null, string? phoneNumber = null)
        {
            try
            {
                if (email == null) return null;

                var response = _context.User.Where(x => 
                    x.Email == (email == null ? x.Email : email) &&
                    x.PhoneNumber == (phoneNumber == null ? x.PhoneNumber : phoneNumber)
                    ).FirstOrDefault();

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<User>? GetUsers(UserType type)
        {
            try
            {
                if (type == null || type.Id == 0 || string.IsNullOrEmpty(type.Key)) return null;

                var response = _context.User.Where(x =>
                    x.UserTypes.Any(x=>x.Key.ToLower().Equals(type.Key.ToLower())));

                return response.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public User? Login(string UserName, string Password)
        {
            var user = _context.User.Where(x => x.UserName == UserName && x.Password == Password).FirstOrDefault();
            return user;
        }
        public User PasswordResetRequest(User entity)
        {
            var user = _context.User.Where(x => x.Id == entity.Id).FirstOrDefault();
            if (user == null) return null;
            string guid = Guid.NewGuid().ToString();

            user.PasswordResetToken = guid;
            _context.SaveChanges();
            return user;
        }
        public User PasswordReset(string token, string userName, string newPassword)
        {
            var user = _context.User.Where(x => x.PasswordResetToken == token && x.UserName == userName).FirstOrDefault();
            if (user == null) return null;
            user.Password = newPassword;
            user.PasswordResetToken = null;
            _context.SaveChanges();
            return user;
        }
        public User? RemoveUserTypeFromUser(int userId, string key)
        {
            try
            {
                if (string.IsNullOrEmpty(key) || userId == 0)
                    throw new ArgumentNullException("Couldn't Remove UserType from User. (key or userId is null)");



                var user = _context.User.SingleOrDefault(u => u.Id == userId);
                if (user == null) throw new ArgumentNullException("user Couldn't found.");

                var userType = user.UserTypes.SingleOrDefault(ut => ut.Key.ToLower().Equals(key.ToLower()));
                if (userType == null) throw new ArgumentNullException("user doesn't have specified userType.");

                user.UserTypes.Remove(userType);
                _context.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region UserType
        public UserType? GetUserType(int id, string key)
        {
            try
            {
                if (id == null && string.IsNullOrEmpty(key)) return null;

                var response = _context.UserType.Where(ut => 
                    ut.Id == (id==0?ut.Id:id) &&
                    ut.Key.ToLower().Equals(key.ToLower())).FirstOrDefault();

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<UserType>? GetUserUserTypes(int? userId)
        {
            try
            {
                if (userId == null) return null;
                var response = _context.UserType.Where(x => x.Users.Any(x=>x.Id==userId));
                return response.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UserType? InsertUserType(string key, string description)
        {
            try
            {
                if( string.IsNullOrEmpty(key) || string.IsNullOrEmpty(description) ) 
                    throw new ArgumentNullException("Couldn't Insert UserType. (key or description is null)");
                UserType userType = new UserType()
                {
                    Key = key,
                    Description = description
                };
                _context.UserType.Add(userType);
                _context.SaveChanges();
                return userType;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public UserType? UpdateUserType(string key, string description)
        {
            try
            {
                if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(description))
                    throw new ArgumentNullException("Couldn't Insert UserType. (key or description is null)");
                var ut = _context.UserType.Where(x => x.Key.ToLower().Equals(key.ToLower())).FirstOrDefault();
                if (ut != null)
                {
                    ut.Description = description;
                }
                _context.SaveChanges();
                return ut;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UserType? RemovePermissionFromUserType(int userTypeId, string key)
        {
            try
            {
                if (string.IsNullOrEmpty(key) || userTypeId == 0)
                    throw new ArgumentNullException("Couldn't Remove Permission from UserType. (key or userTypeId is null)");



                var userType = _context.UserType.SingleOrDefault(u => u.Id == userTypeId);
                if (userTypeId == null) throw new ArgumentNullException("userTypeId Couldn't found.");

                var permission = userType.Permissions.SingleOrDefault(p => p.Key.ToLower().Equals(key.ToLower()));
                if (permission == null) throw new ArgumentNullException("userType doesn't have specified permission.");

                userType.Permissions.Remove(permission);
                _context.SaveChanges();
                return userType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Permission
        public Permission? GetPermission(int id = 0, string key = "")
        {
            try
            {
                if (id == null && string.IsNullOrEmpty(key)) return null;

                var response = _context.Permission.Where(ut =>
                    ut.Id == (id == 0 ? ut.Id : id) &&
                    ut.Key.ToLower().Equals(key.ToLower())).FirstOrDefault();

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Permission>? GetPermissions(UserType userType)
        {
            try
            {
                if (userType?.Id == null || userType?.Id == 0) return null;
                var response = _context.Permission.Where(x => x.UserTypes.Any(x => x.Id == userType.Id));
                return response.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Permission>? GetPermissions(User user)
        {
            try
            {
                if (user?.Id == null || user?.Id == 0) return null;
                var response = _context.Permission.Where(
                    x => x.UserTypes.Any(
                        x => x.Users.Any(
                            u => u.Id==user.Id)));
                return response.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Permission? InsertPermission(string key, string description)
        {
            try
            {
                if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(description))
                    throw new ArgumentNullException("Couldn't Insert Permission. (key or description is null)");
                Permission permission = new Permission()
                {
                    Key = key,
                    Description = description
                };
                _context.Permission.Add(permission);
                _context.SaveChanges();
                return permission;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Permission? UpdatePermission(string key, string description)
        {
            try
            {
                if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(description))
                    throw new ArgumentNullException("Couldn't Insert Permission. (key or description is null)");
                var permission = _context.Permission.Where(x => x.Key.ToLower().Equals(key.ToLower())).FirstOrDefault();
                if (permission != null)
                {
                    permission.Description = description;
                }
                _context.SaveChanges();
                return permission;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GeneralLog
        public GeneralLog InsertGeneralLog(string type, string message, string destination, string obj = "")
        {
            try
            {
                if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(message) || string.IsNullOrEmpty(destination))
                    throw new ArgumentNullException("Couldn't Insert GeneralLog. (type or message or destination is null or empty)");
                GeneralLog log = new GeneralLog()
                {
                    Type = type,
                    Message = message,
                    Destination = destination,
                    Object = obj
                };
                _context.GeneralLog.Add(log);
                _context.SaveChanges();
                return log;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


    }
}
