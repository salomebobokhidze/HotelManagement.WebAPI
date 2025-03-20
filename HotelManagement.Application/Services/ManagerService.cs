using HotelManagement.Application.Services;
using HotelManagement.Core.DTOs;
using HotelManagement.Core.Entities;
using HotelManagement.Core.Interfaces;
using HotelManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelManagement.Core.Services
{
    public class ManagerService : IManagerService
    {
        private readonly AppDbContext _context;

        public ManagerService(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ManagerDTO> RegisterManagerAsync(CreateManagerDTO managerDto)
        {
            if (managerDto == null)
                throw new ArgumentNullException(nameof(managerDto));

            var manager = new Manager
            {
                FirstName = managerDto.FirstName,
                LastName = managerDto.LastName,
                Email = managerDto.Email,
                PersonalNumber = managerDto.PersonalNumber,
                PhoneNumber = managerDto.PhoneNumber
            };

            await _context.Managers.AddAsync(manager);
            await _context.SaveChangesAsync();

            return new ManagerDTO(manager);
        }

        public async Task UpdateManagerAsync(int id, UpdateManagerDTO managerDto)
        {
            if (managerDto == null)
                throw new ArgumentNullException(nameof(managerDto));

            var manager = await _context.Managers.FindAsync(id);
            if (manager == null)
                throw new KeyNotFoundException("Manager not found");

            manager.FirstName = managerDto.FirstName;
            manager.LastName = managerDto.LastName;
            manager.Email = managerDto.Email;
            manager.PhoneNumber = managerDto.PhoneNumber;

            _context.Managers.Update(manager);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteManagerAsync(int id)
        {
            var manager = await _context.Managers.FindAsync(id);
            if (manager == null)
                throw new KeyNotFoundException("Manager not found");

            _context.Managers.Remove(manager);
            await _context.SaveChangesAsync();
        }

        public async Task<ManagerDTO> GetManagerByIdAsync(int id)
        {
            var manager = await _context.Managers.FindAsync(id);
            if (manager == null)
                throw new KeyNotFoundException("Manager not found");

            return new ManagerDTO(manager);
        }

        public Task<ManagerDTO> CreateManagerAsync(CreateManagerDTO dto)
        {
            throw new NotImplementedException();
        }

        Task<bool> IManagerService.UpdateManagerAsync(int id, UpdateManagerDTO dto)
        {
            throw new NotImplementedException();
        }

        Task<bool> IManagerService.DeleteManagerAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}