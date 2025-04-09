using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Salary
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal SalaryAmount { get; set; }

    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; }
}
