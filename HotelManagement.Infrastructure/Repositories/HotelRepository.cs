using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Core.Entities;
using HotelManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Infrastructure.Repositories
{
    public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        private readonly AppDbContext _context;

        public HotelRepository(AppDbContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        
        public async Task<IEnumerable<Hotel>> GetFilteredHotelsAsync(string filter)
        {
            if (string.IsNullOrEmpty(filter))
                throw new ArgumentException("Filter cannot be null or empty", nameof(filter));

            return await _context.Hotels
                .Where(h => h.Name.Contains(filter) || h.City.Contains(filter))
                .ToListAsync();
        }
    }
}