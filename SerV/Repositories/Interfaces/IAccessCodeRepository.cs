using SerV.Data;

namespace SerV.Repositories.Interfaces
{
    public interface IAccessCodeRepository
    {
        Task<AccessCode> CreateAccessCode(AccessCode accessCode);
        Task<AccessCode?> GetAccessCodeByCode(string code);
        Task<AccessCode> UpdateAccessCode(AccessCode accessCode);
    }
}