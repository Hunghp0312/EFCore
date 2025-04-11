using DAL.Entity;
using DAL.Repository;
using BLL.Mapper;
using BLL.CustomException;
using BLL.DTOs.Department;
namespace BLL.Services;

public class DepartmentSevices : IDepartmentSevices
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentSevices(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<DepartmentResponseDTO> AddDepartmentAsync(DepartmentCreateUpdateDTO departmentDto)
    {
        var department = new Department
        {
            Id = Guid.NewGuid(),
            Name = departmentDto.Name,
        };
        var departmentResponse = DepartmentMapper.MapToDepartmentResponseDTO(await _departmentRepository.AddAsync(department));
        await _departmentRepository.SaveChangesAsync();

        return departmentResponse;
    }

    public async Task<IEnumerable<DepartmentResponseDTO>> GetAllDepartmentsAsync()
    {
        var departments =  await _departmentRepository.GetAllAsync();
        var departmentsReponse = DepartmentMapper.MapToDepartmentResponseDTOs(departments);

        return departmentsReponse;
    }

    public async Task<DepartmentResponseDTO> GetDepartmentByIdAsync(Guid id)
    {
        var department = await _departmentRepository.GetByIdAsync(id) ?? throw new NotFoundException($"Department with ID {id} not found.");
        var departmentResponse = new DepartmentResponseDTO
        {
            Id = department.Id,
            Name = department.Name,
        };

        return departmentResponse;
    }

    public async Task RemoveDepartmentAsync(Guid id)
    {
        var department = await _departmentRepository.GetByIdAsync(id) ?? throw new NotFoundException($"Department with ID {id} not found.");
        _departmentRepository.Remove(department);

        await _departmentRepository.SaveChangesAsync();
    }

    public async Task<DepartmentResponseDTO> UpdateDepartmentAsync(Guid id, DepartmentCreateUpdateDTO departmentDto)
    {
        var department = await _departmentRepository.GetByIdAsync(id) ?? throw new NotFoundException($"Department with ID {id} not found.");
        department.Name = departmentDto.Name;
        await _departmentRepository.SaveChangesAsync();
        var departmentResponse = new DepartmentResponseDTO
        {
            Id = department.Id,
            Name = department.Name,
        };

        return departmentResponse;
    }
}
