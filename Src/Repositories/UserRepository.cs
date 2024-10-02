using Catedra1IDWM.Src.Data;
using Catedra1IDWM.Src.Interfaces;
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

        public async Task<bool> ExistsById(int id)
        {
            return await _context.Usuarios.AnyAsync(x => x.Id == id);
        }
    }
}