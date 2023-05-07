using AutoMapper;
using MediatR;
using UniversityService.Application.Services.Repositories;
using UniversityService.Domain.Entities;

namespace UniversityService.Application.Features.Departments.Commands.AddDepartment;

public class AddDepartmentCommandRequestHandler : IRequestHandler<AddDepartmentCommandRequest, AddDepartmentResponse>
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IMapper _mapper;

    public AddDepartmentCommandRequestHandler(IDepartmentRepository departmentRepository, IMapper mapper)
    {
        _departmentRepository = departmentRepository;
        _mapper = mapper;
    }

    public async Task<AddDepartmentResponse> Handle(AddDepartmentCommandRequest request, CancellationToken cancellationToken)
    {
        List<Department> departments = _mapper.Map<List<Department>>(request.AddDepartmentCommandRequestDepartments);

        _departmentRepository.AddRange(departments);

        await _departmentRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        AddDepartmentResponse response = _mapper.Map<AddDepartmentResponse>(departments);

        return response;
    }
}
