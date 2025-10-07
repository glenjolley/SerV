using SerV.Data;

namespace SerV.Services.Interfaces
{
    public interface IAccessCodeService
    {
        Task<AccessCode?> GetAccessCodeByCode(string code);
    }
}