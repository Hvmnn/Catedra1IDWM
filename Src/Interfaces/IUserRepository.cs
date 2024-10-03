using Catedra1IDWM.Src.Models;

namespace Catedra1IDWM.Src.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> ExistsById(int id);
        Task<User?> ExistsByRut(string rut);
    }
}