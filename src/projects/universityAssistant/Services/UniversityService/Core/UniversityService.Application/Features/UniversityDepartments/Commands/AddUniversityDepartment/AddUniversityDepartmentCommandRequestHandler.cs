using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityService.Application.Services.Repositories;
using UniversityService.Domain.Entities;

namespace UniversityService.Application.Features.UniversityDepartments.Commands.AddUniversityDepartment;

public class AddUniversityDepartmentCommandRequestHandler : IRequestHandler<AddUniversityDepartmentCommandRequest, AddUniversityDepartmentResponse>
{
    private readonly IUniversityDepartmentRepository _universityDepartmentRepository;
    private readonly IMapper _mapper;

    public AddUniversityDepartmentCommandRequestHandler(IUniversityDepartmentRepository universityDepartmentRepository, IMapper mapper)
    {
        _universityDepartmentRepository = universityDepartmentRepository;
        _mapper = mapper;
    }

    public async Task<AddUniversityDepartmentResponse> Handle(AddUniversityDepartmentCommandRequest request, CancellationToken cancellationToken)
    {
        List<UniversityDepartment> universityDepartments = new();

        request.Universities.ForEach(university => university.Faculties.ForEach(facult => facult.Departments.ForEach(department =>
        {
            universityDepartments.Add(new UniversityDepartment()
            {
                UniversityId = university.UniversityId,
                FacultyId = facult.FacultyId,
                DepartmentId = department.DepartmentId
            });
        })));

        List<UniversityDepartment> universityDepartmentsResponse = new();

        foreach (var universityDepartment in universityDepartments)
        {
            if (!await _universityDepartmentRepository.AnyAsync(i =>
            i.UniversityId == universityDepartment.UniversityId &&
            i.FacultyId == universityDepartment.FacultyId &&
            i.DepartmentId == universityDepartment.DepartmentId
            ))
            {
                universityDepartmentsResponse.Add(universityDepartment);
            }
        }

        if (universityDepartmentsResponse.Count > 0)
        {
            _universityDepartmentRepository.AddRange(universityDepartmentsResponse);

            await _universityDepartmentRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }

        return _mapper.Map<AddUniversityDepartmentResponse>(universityDepartmentsResponse);
    }
}
