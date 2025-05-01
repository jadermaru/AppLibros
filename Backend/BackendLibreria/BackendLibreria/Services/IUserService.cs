using BackendLibreria.DTOs;

namespace BackendLibreria.Services
{
    public interface IUserService
    {
        Task<string?> CreateUserAsync(UserDTO dto);
    }
}
