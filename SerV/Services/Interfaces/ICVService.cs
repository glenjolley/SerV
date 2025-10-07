using SerV.Data;

namespace SerV.Services.Interfaces
{
    public interface ICVService
    {
        Task<CV?> GetCVByAccessCode(AccessCode accessCode);
    }
}