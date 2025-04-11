using DAL.Context;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository;

public class SalaryRepository : Repository<Salaries>, ISalaryRepository
{
    public SalaryRepository(AppDbContext context) : base(context)
    {
    }
    public override async Task<IEnumerable<Salaries>> GetAllAsync()
    {
        return await _dbSet.AsNoTracking().Include(s => s.Employee).ToListAsync();
    }
}
