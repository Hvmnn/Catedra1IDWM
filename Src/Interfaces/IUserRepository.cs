namespace Catedra1IDWM.Src.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> ExistsById(int id);
    }
}