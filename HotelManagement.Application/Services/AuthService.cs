using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HotelManagement.Core.DTOs;
using HotelManagement.Core.Entities;
using HotelManagement.Core.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace HotelManagement.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<Guest> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<Guest> userManager, RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterUserDto registerDto)
        {
            
            var userExists = await _userManager.FindByEmailAsync(registerDto.Email);
            if (userExists != null)
                return new AuthResponseDto { Success = false, Message = "User already exists" };

            
            var user = new Guest
            {
                UserName = registerDto.Email,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                PhoneNumber = registerDto.PhoneNumber,
                PersonalNumber = registerDto.PersonalNumber
            };

            
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
                return new AuthResponseDto { Success = false, Message = "User creation failed" };

            
            var roleExists = await _roleManager.RoleExistsAsync("Guest");
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole("Guest"));
            }

            
            await _userManager.AddToRoleAsync(user.Id, "Guest"); 

            return new AuthResponseDto { Success = true, Message = "User registered successfully" };
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
                return new AuthResponseDto { Success = false, Message = "Invalid credentials" };

            var token = GenerateJwtToken(user);
            return new AuthResponseDto { Success = true, Token = token };
        }

        public async Task<CurrentUserDTO> GetCurrentUserAsync(ClaimsPrincipal user)
        {
            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return null; 

            var appUser = await _userManager.FindByIdAsync(userIdClaim.Value); 

            if (appUser == null) return null; 

            return new CurrentUserDTO
            {
                Id = appUser.Id,
                Email = appUser.Email,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName
            };
        }

        private string GenerateJwtToken(Guest user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Task<AuthResponseDto> RegisterAsync(CreateGuestDTO createGuest)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResponseDto> RefreshTokenAsync(RefreshTokenDto refreshTokenDto)
        {
            throw new NotImplementedException();
        }

        public Task RevokeTokenAsync(RevokeTokenDto revokeTokenDto)
        {
            throw new NotImplementedException();
        }
    }
}