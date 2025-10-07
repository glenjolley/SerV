using SerV.Data;
using SerV.DBContexts;
using SerV.Repositories.Interfaces;

namespace SerV.Repositories;

public class AccessCodeUsageRepository : IAccessCodeUsageRepository
{
    private readonly AppDBContext _context;

    public AccessCodeUsageRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<AccessCodeUsage> LogAccessCodeUsage(AccessCode accessCode)
    {
        var usage = new AccessCodeUsage
        {
            AccessCode = accessCode,
            UsedAt = DateTime.UtcNow
        };
        _context.AccessCodeUsageLog.Add(usage);
        await _context.SaveChangesAsync();
        return usage;
    }
}
