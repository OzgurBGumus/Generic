using Microsoft.EntityFrameworkCore;
using P_Core.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataService : IDataAccessService
    {
        private DbContext _context;
        public DataService(DbContext dbContext)
        {
            _context = dbContext;
        }
    }
}
