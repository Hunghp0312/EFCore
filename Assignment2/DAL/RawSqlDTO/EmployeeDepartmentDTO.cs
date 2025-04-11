namespace DAL.RawSqlDTO;

public class EmployeeDepartmentDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public Guid DepartmentId { get; set; }
    public required string DepartmentName { get; set; }
    public DateTime JoinedDate { get; set; }
}
