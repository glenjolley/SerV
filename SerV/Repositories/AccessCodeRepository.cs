using Microsoft.EntityFrameworkCore;
using SerV.Data;
using SerV.DBContexts;
using SerV.Repositories.Interfaces;

namespace SerV.Repositories;

public class AccessCodeRepository : IAccessCodeRepository
{
    private readonly AppDBContext _context;

    public AccessCodeRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<AccessCode?> GetAccessCodeByCode(string code)
    {
        return await _context.AccessCodes
            .Include(ac => ac.CV)
            .FirstOrDefaultAsync(ac => ac.Code == code);
    }

    public async Task<AccessCode> UpdateAccessCode(AccessCode accessCode)
    {
        _context.AccessCodes.Update(accessCode);
        await _context.SaveChangesAsync();
        return accessCode;
    }

    public async Task<AccessCode> CreateAccessCode(AccessCode accessCode)
    {
        _context.AccessCodes.Add(accessCode);
        await _context.SaveChangesAsync();
        return accessCode;
    }
}
