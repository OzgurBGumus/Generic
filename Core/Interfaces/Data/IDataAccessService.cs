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
        public User Login(string userName, string password);
        public User CreateUser(User entity);
    }
}
