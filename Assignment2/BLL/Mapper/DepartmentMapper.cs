using BLL.DTOs.Department;
using DAL.Entity;

namespace BLL.Mapper;

public class DepartmentMapper
{
    public static DepartmentResponseDTO MapToDepartmentResponseDTO(Department department)
    {
        return new DepartmentResponseDTO
        {
            Id = department.Id,
            Name = department.Name
        };
    }
    public static IEnumerable<DepartmentResponseDTO> MapToDepartmentResponseDTOs(IEnumerable<Department> departments)
    {
        return departments.Select(d => new DepartmentResponseDTO
        {
            Id = d.Id,
            Name = d.Name
        });
    }
}
