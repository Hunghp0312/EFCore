using DAL.Context;
using DAL.Entity;
using System;
namespace DAL.Repository;

public class DepartmentRepository : Repository<Department>, IDepartmentRepository
{
    public DepartmentRepository(AppDbContext context) : base(context)
    {
    }
}