using P_Core.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mock
{
    public class MockUserTypeList
    {
        private List<UserType> UserTypeList;
        MockPermissionList MockPermissionList = new MockPermissionList();
        private List<Permission> permissionList;
        public MockUserTypeList()
        {
            permissionList = MockPermissionList.Get();
            UserTypeList = new List<UserType>()
            {
                new UserType(){
                    Description = "OGOwner Type For Mock",
                    Key = "OGOwner",
                    Permissions = new List<Permission>(){ permissionList[0], permissionList[1] },
                    User = new List<User>()
                },
                new UserType(){
                    Description = "BisunessOwner Type For Mock",
                    Key = "BisunessOwner",
                    Permissions = new List<Permission>(){ permissionList[1] },
                    User = new List<User>()
                },

            };
        }

        public List<UserType> Get()
        {
            return UserTypeList;
        }
    }
}
