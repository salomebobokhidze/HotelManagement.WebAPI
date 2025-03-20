using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelManagement.Core.DTOs;

namespace HotelManagement.Application.Services;

public interface IManagerService
{
    Task<ManagerDTO> CreateManagerAsync(CreateManagerDTO dto);
    Task<bool> UpdateManagerAsync(int id, UpdateManagerDTO dto);
    Task<bool> DeleteManagerAsync(int id);
    Task<ManagerDTO> GetManagerByIdAsync(int id);
    
}
