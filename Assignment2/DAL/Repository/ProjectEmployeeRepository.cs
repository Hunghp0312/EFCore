using DAL.Context;
using DAL.Entity;

namespace DAL.Repository;

public class ProjectEmployeeRepository : Repository<ProjectEmployee>, IProjectEmployeeRepository
{
    public ProjectEmployeeRepository(AppDbContext context) : base(context)
    {
    }
}

