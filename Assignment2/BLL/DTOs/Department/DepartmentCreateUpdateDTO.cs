using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.Department;

public class DepartmentCreateUpdateDTO
{
    [MaxLength(100,ErrorMessage ="Department name length can not have more than 100 character")]
    public required string Name { get; set; }
}
