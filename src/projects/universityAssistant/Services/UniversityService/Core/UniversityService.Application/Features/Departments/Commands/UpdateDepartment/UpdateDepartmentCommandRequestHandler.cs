using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityService.Application.Services.Repositories;
using UniversityService.Domain.Entities;

namespace UniversityService.Application.Features.Departments.Commands.UpdateDepartment;

public class UpdateDepartmentCommandRequestHandler : IRequestHandler<UpdateDepartmentCommandRequest, UpdateDepartmentResponse>
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IMapper _mapper;

    public UpdateDepartmentCommandRequestHandler(IDepartmentRepository departmentRepository, IMapper mapper)
    {
        _departmentRepository = departmentRepository;
        _mapper = mapper;
    }

    public async Task<UpdateDepartmentResponse> Handle(UpdateDepartmentCommandRequest request, CancellationToken cancellationToken)
    {
        Department department = _mapper.Map<Department>(request);

        _departmentRepository.Update(department);

        await _departmentRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        UpdateDepartmentResponse response = _mapper.Map<UpdateDepartmentResponse>(department);

        return response;
    }
}
