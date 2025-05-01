using BackendLibreria.Data;
using BackendLibreria.DTOs;
using BackendLibreria.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Security.Cryptography;
using BackendLibreria.Interface;


namespace BackendLibreria.Services
{
    public class UserService : IUserService 
    {
        private readonly ApplicationDBContext _context;
        private readonly ITokenService _tokenService;

        public UserService(ApplicationDBContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<string?> CreateUserAsync(UserDTO dto)
        {
            if (await _context.Users.AnyAsync(u => u.Name == dto.Username))
                return null; // ya existe

            var user = new User
            {
                Name = dto.Username,
                Password = HashPassword(dto.Password),
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Devuelve el token generado usando username y contraseña hasheada
            return await _tokenService.AuthenticateAsync(user.Name, dto.Password);  // Enviar la contraseña sin hashear
        }



        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

    }
}
