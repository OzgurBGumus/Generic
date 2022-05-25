using P_Core.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mock
{
    public class MockStatusList
    {
        private List<Status> StatusList;
        public MockStatusList()
        {
            StatusList = new List<Status>()
            {
                new Status(){
                    Description = "Enable",
                    Key = "true"
                },
                new Status(){
                    Description = "Disable",
                    Key = "false"
                }
            };
        }

        public List<Status> Get()
        {
            return StatusList;
        }
    }
}
