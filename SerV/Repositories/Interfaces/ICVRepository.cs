using SerV.Data;

namespace SerV.Repositories.Interfaces
{
    public interface ICVRepository
    {
        Task<CV?> GetCVByAccessCode(AccessCode accessCode);
    }
}