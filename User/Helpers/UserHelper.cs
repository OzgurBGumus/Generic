using Core.Models.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Org.BouncyCastle.Crypto.Generators;
using P_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace P_User.Helpers
{
    public class UserHelper
    {
        public UserAbstract toModel(P_Core.Models.Models.User entity) {
            P_User.Models.User model = new P_User.Models.User();
            model.Id = entity.Id;
            model.UserName = entity.UserName;
            //model.Password = entity.Password;
            model.JwtToken = entity.JwtToken;
            model.LastName = entity.LastName;
            model.FirstName = entity.FirstName;
            model.Email = entity.Email;
            model.PhoneNumber = entity.PhoneNumber;
            model.EmailConfirm = entity.EmailConfirm;
            model.PhoneConfirm = entity.PhoneConfirm;
            model.Status = entity.Status;
            if(entity.UserTypes != null) 
            {
                model.UserTypes = toModel(entity.UserTypes.ToList());
            }
            return model;
        }
        public List<UserAbstract> toModel(List<P_Core.Models.Models.User> entity)
        {
            List<UserAbstract> model = new List<UserAbstract>();
            for (int i = 0; i < entity.Count; i++)
                model.Add(toModel(entity[i]));
            return model;
        }

        public UserTypeAbstract toModel(P_Core.Models.Models.UserType entity)
        {
            P_User.Models.UserType model = new P_User.Models.UserType();
            model.Id = entity.Id;
            model.Key = entity.Key;
            model.Description = entity.Description;
            return model;
        }
        public List<UserTypeAbstract> toModel(List<P_Core.Models.Models.UserType> entity)
        {
            List<UserTypeAbstract> model = new List<UserTypeAbstract>();
            for (int i = 0; i < entity.Count; i++)
                model.Add(toModel(entity[i]));
            return model;
        }

        public PermissionAbstract toModel(P_Core.Models.Models.Permission entity)
        {
            P_User.Models.Permission model = new P_User.Models.Permission();
            model.Id = entity.Id;
            model.Key = entity.Key;
            model.Description = entity.Description;
            return model;
        }
        public List<PermissionAbstract> toModel(List<P_Core.Models.Models.Permission> entity)
        {
            List<PermissionAbstract> model = new List<PermissionAbstract>();
            for (int i = 0; i < entity.Count; i++)
                model.Add(toModel(entity[i]));
            return model;
        }


        public P_Core.Models.Models.User toEntity(UserAbstract model)
        {
            P_Core.Models.Models.User entity = new P_Core.Models.Models.User();
            entity.UserName = model.UserName;
            entity.Password = model.Password;
            entity.JwtToken = model.JwtToken;
            entity.LastName = model.LastName;
            entity.FirstName = model.FirstName;
            entity.Email = model.Email;
            entity.PhoneNumber = model.PhoneNumber;
            entity.PasswordResetToken = model.PasswordResetToken;
            entity.EmailConfirm = model.EmailConfirm;
            entity.PhoneConfirm = model.PhoneConfirm;
            entity.Status = model.Status;
            entity.UserTypes = toEntity(model.UserTypes.ToList());
            return entity;
        }
        public List<P_Core.Models.Models.User> toEntity(List<UserAbstract> model)
        {
            List<P_Core.Models.Models.User> entity = new List<P_Core.Models.Models.User>();
            for (int i = 0; i < model.Count; i++)
                entity.Add(toEntity(model[i]));
            return entity;
        }

        public P_Core.Models.Models.UserType toEntity(UserTypeAbstract entity)
        {
            P_Core.Models.Models.UserType model = new P_Core.Models.Models.UserType();
            model.Id = entity.Id;
            model.Key = entity.Key;
            model.Description = entity.Description;
            return model;
        }
        public List<P_Core.Models.Models.UserType> toEntity(List<UserTypeAbstract> entity)
        {
            List<P_Core.Models.Models.UserType> model = new List<P_Core.Models.Models.UserType>();
            for (int i = 0; i < entity.Count; i++)
                model.Add(toEntity(entity[i]));
            return model;
        }



        public P_User.Models.User EmptyUserModel()
        {
            P_User.Models.User model = new P_User.Models.User();
            return model;
        }
        //public bool MatchPassword(string password, string db_password)
        //{
        //    return BCrypt.Equals(password, db_password);
        //}
        //public bool Hash(string password)
        //{
        //    return BCrypt.Generate(password)
        //}
    }
}
