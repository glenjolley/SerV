using SerV.Data;
using SerV.Repositories.Interfaces;
using SerV.Services.Interfaces;

namespace SerV.Services;

public class AccessCodeService : IAccessCodeService
{
    private readonly IAccessCodeRepository _accessCodeRepository;
    private readonly IAccessCodeUsageRepository _accessCodeUsageRepository;

    public AccessCodeService(
        IAccessCodeRepository accessCodeRepository,
        IAccessCodeUsageRepository accessCodeUsageRepository)
    {
        _accessCodeRepository = accessCodeRepository;
        _accessCodeUsageRepository = accessCodeUsageRepository;
    }

    public async Task<AccessCode?> GetAccessCodeByCode(string code)
    {
        var accessCode = await _accessCodeRepository.GetAccessCodeByCode(code);

        if (accessCode is null)
        {
            return null;
        }

        await _accessCodeUsageRepository.LogAccessCodeUsage(accessCode);

        return accessCode;
    }
}
