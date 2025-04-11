using DAL.Context;
using DAL.Entity;

namespace DAL.Repository;

public class ProjectRepository : Repository<Project>, IProjectRepository
{
    public ProjectRepository(AppDbContext context) : base(context)
    {
    }
}
