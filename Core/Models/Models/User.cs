using Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Core.Models.Models
{
    public class User
    {
        public  int Id { get; set; }
        public  int Status { get; set; }
        public  string UserName { get; set; }
        public  string Password { get; set; }
        public  string? JwtToken { get; set; }
        public  string? FirstName { get; set; }
        public  string? LastName { get; set; }
        public  string? Email { get; set; }
        public  string? PhoneNumber { get; set; }
        public string? PasswordResetToken { get; set; }
        public  bool EmailConfirm { get; set; }
        public  bool PhoneConfirm { get; set; }
        public  virtual List<UserType>? UserTypes { get; set; }
        public  OGDate? BirthDate { get; set; }
        public  OGDate? CreateDate { get; set; }
        


        public virtual string toLogString()
        {
            var currentTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            var userString = "User: [Id:" + Id + ", UserName:" + UserName + ", FullName:" + FirstName + " " + LastName + ", Email:" + Email + ", PhoneNumber:" + PhoneNumber + "]";
            var LogString = "[" + currentTime + "]  " + userString + "]";
            return LogString;
        }
    }
}
