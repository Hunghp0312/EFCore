using BLL.DTOs.Project;

namespace BLL.DTOs.Employee;

public class EmployeeProjectResponseDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public IEnumerable<string> ProjectName { get; set; } = [];
    public DateTime JoinedDate { get; set; }
}
