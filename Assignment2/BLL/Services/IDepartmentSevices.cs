using BLL.DTOs.Department;
using DAL.Entity;
namespace BLL.Services;

public interface IDepartmentSevices
{
    Task<IEnumerable<DepartmentResponseDTO>> GetAllDepartmentsAsync();
    Task<DepartmentResponseDTO> GetDepartmentByIdAsync(Guid id);
    Task<DepartmentResponseDTO> AddDepartmentAsync(DepartmentCreateUpdateDTO departmentDto);
    Task<DepartmentResponseDTO> UpdateDepartmentAsync(Guid id, DepartmentCreateUpdateDTO departmentDto);
    Task RemoveDepartmentAsync(Guid id);
}
