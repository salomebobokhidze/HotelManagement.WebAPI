using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelManagement.Core.Entities;
using HotelManagement.Infrastructure.Data;

namespace HotelManagement.Infrastructure.Repositories
{
    public class ManagerRepository : GenericRepository<Manager>, IManagerRepository
    {
        public ManagerRepository(AppDbContext context) : base(context)
        {
        }
    }
}
