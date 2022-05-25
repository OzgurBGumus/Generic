using P_Core.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mock
{
    public class MockPermissionList
    {
        private List<Permission> PermissionList;
        MockStatusList MockStatusList = new MockStatusList();
        private List<Status> statusList;
        public MockPermissionList()
        {
            statusList = MockStatusList.Get();
            PermissionList = new List<Permission>()
            {
                new Permission(){
                    Description = "Can Create User",
                    Key = "User_Register",
                    Status = statusList[0],
                    UserTypes = new List<UserType>()
                },
                new Permission(){
                    Description = "Can View Users",
                    Key = "Users_View",
                    Status = statusList[0],
                    UserTypes = new List<UserType>()
                },

            };
        }

        public List<Permission> Get()
        {
            return PermissionList;
        }
    }
}
