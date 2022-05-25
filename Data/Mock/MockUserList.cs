using P_Core.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mock
{
    public class MockUserList
    {
        private List<User> UserList;
        MockUserTypeList MockUserTypeList = new MockUserTypeList();
        private List<UserType> userTypeList;
        public MockUserList()
        {
            userTypeList = MockUserTypeList.Get();
            UserList = new List<User>()
            {
                new User(){ 
                    UserName = "UsernameOzgur",
                    Password = "123456",
                    Email = "b.ozgurgumus@gmail.com",
                    EmailConfirm = true,
                    PhoneNumber = "+1 234 432 2222",
                    PhoneConfirm = true,
                    FirstName = "Ozgur",
                    LastName = "Gumus",
                    UserTypes = new List<UserType>(),
                    BirthDate = new OGDate(){Id = 1, Year = "1999", Month = "05", Day = "03"},
                    CreateDate = new OGDate(){Id = 2, Year = "2022", Month = "01", Day = "15"}
                },
                new User(){
                    UserName = "UsernameTaylan",
                    Password = "123456",
                    Email = "h.taylan@gmail.com",
                    EmailConfirm = true,
                    PhoneNumber = "+1 432 245 2122",
                    PhoneConfirm = true,
                    FirstName = "Taylan",
                    LastName = "Gumus",
                    UserTypes = new List<UserType>(),
                    BirthDate = new OGDate(){Id = 1, Year = "1996", Month = "05", Day = "23"},
                    CreateDate = new OGDate(){Id = 2, Year = "2022", Month = "01", Day = "12"}
                },
                new User(){
                    UserName = "UsernameNoMail",
                    Password = "123456",
                    Email = "noMail@OGMock.com",
                    EmailConfirm = true,
                    PhoneNumber = "+1 111 222 3344",
                    PhoneConfirm = true,
                    FirstName = "No Mail Confirmation",
                    LastName = "Mock",
                    UserTypes = new List<UserType>(),
                    BirthDate = new OGDate(){Year = "2021", Month = "02", Day = "05"},
                    CreateDate = new OGDate(){Year = "2022", Month = "01", Day = "10"}
                },

            };
        }

        public List<User> Get()
        {
            return UserList;
        }
    }
}
