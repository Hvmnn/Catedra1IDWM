using Catedra1IDWM.Src.Data;
using Catedra1IDWM.Src.Interfaces;
using Catedra1IDWM.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace Catedra1IDWM.Src.Repositories
{
    public class UserRepository : IUserRepository 
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User?> ExistsById(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User?> ExistsByRut(string rut)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Rut == rut);
        }
    }
}