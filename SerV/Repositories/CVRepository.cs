using Microsoft.EntityFrameworkCore;
using SerV.Data;
using SerV.DBContexts;
using SerV.Repositories.Interfaces;

namespace SerV.Repositories;

public class CVRepository : ICVRepository
{
    private readonly AppDBContext _context;

    public CVRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<CV?> GetCVByAccessCode(AccessCode accessCode)
    {
        return await _context.CVs
            .Include(
                cv => cv.Experiences
                    .OrderByDescending(ex => ex.DateStarted)
                )
            .Include(
                cv => cv.Educations
                    .OrderBy(ed => ed.YearEnded)
                )
            .Include(cv => cv.Skills)
            .FirstOrDefaultAsync(cv => cv.Id == accessCode.CV.Id);
    }
}
