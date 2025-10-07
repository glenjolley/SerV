using SerV.Data;
using SerV.Repositories.Interfaces;
using SerV.Services.Interfaces;

namespace SerV.Services;

public class CVService : ICVService
{
    private readonly ICVRepository _cvRepository;

    public CVService(
        ICVRepository cvRepository)
    {
        _cvRepository = cvRepository;
    }

    public async Task<CV?> GetCVByAccessCode(AccessCode accessCode)
    {
        return await _cvRepository.GetCVByAccessCode(accessCode);
    }
}
