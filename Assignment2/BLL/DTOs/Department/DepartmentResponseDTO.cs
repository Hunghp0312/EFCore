using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.Department;

public class DepartmentResponseDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}
