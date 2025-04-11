namespace BLL.DTOs;

public class EmployeeProjectDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public DateTime JoinedDate { get; set; }
    public bool Enable { get; set; }
    public required string ProjectName { get; set; }
}
