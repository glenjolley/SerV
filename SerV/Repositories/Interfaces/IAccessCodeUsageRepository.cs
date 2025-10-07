using SerV.Data;

namespace SerV.Repositories.Interfaces
{
    public interface IAccessCodeUsageRepository
    {
        Task<AccessCodeUsage> LogAccessCodeUsage(AccessCode accessCode);
    }
}