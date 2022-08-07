using Core.Models.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Org.BouncyCastle.Crypto.Generators;
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
        public P_User.Models.User toModel(P_Core.Models.Models.User entity) {
            P_User.Models.User model = new P_User.Models.User();
            model.UserName = entity.UserName;
            model.Password = entity.Password;
            model.JwtToken = entity.JwtToken;
            model.LastName = entity.LastName;
            model.FirstName = entity.FirstName;
            model.Email = entity.Email;
            model.PhoneNumber = entity.PhoneNumber;
            model.EmailConfirm = entity.EmailConfirm;
            model.PhoneConfirm = entity.PhoneConfirm;
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
            entity.EmailConfirm = model.EmailConfirm;
            entity.PhoneConfirm = model.PhoneConfirm;
            return entity;
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
