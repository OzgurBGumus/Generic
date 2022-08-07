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

        public User? Login(string UserName, string Password)
        {
            var user = _context.User.Where(x => x.UserName == UserName && x.Password == Password).FirstOrDefault();
            return user;
        }
    }
}
