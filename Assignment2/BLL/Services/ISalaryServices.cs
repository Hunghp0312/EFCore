using BLL.DTOs.Salary;
using DAL.Entity;

namespace BLL.Services;

public interface ISalaryServices
{
    Task<IEnumerable<SalaryResponseDTO>> GetAllSalaryAsync();
    Task<SalaryResponseDTO> GetSalaryByIdAsync(Guid id);
    Task<SalaryResponseDTO> AddSalaryAsync(SalaryRequestDTO salary);
    Task<SalaryResponseDTO> UpdateSalaryAsync(Guid id, SalaryRequestDTO salary);
    Task RemoveSalaryAsync(Guid id);
}
