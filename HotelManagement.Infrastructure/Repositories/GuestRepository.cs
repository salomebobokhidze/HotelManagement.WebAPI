using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelManagement.Core.Entities;
using HotelManagement.Infrastructure.Data;

namespace HotelManagement.Infrastructure.Repositories
{
    public class GuestRepository : GenericRepository<Guest>, IGuestRepository
    {
        public GuestRepository(AppDbContext context) : base(context)
        {
        }
    }
}
