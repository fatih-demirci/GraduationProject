using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityService.Application.Services.Repositories;
using UniversityService.Domain.Entities;

namespace UniversityService.Application.Features.Faculties.Commands.AddFaculty;

public class AddFacultyCommandRequestHandler : IRequestHandler<AddFacultyCommandRequest, AddFacultyResponse>
{
    private readonly IFacultyRepository _facultyRepository;
    private readonly IMapper _mapper;

    public AddFacultyCommandRequestHandler(IFacultyRepository facultyRepository, IMapper mapper)
    {
        _facultyRepository = facultyRepository;
        _mapper = mapper;
    }

    public async Task<AddFacultyResponse> Handle(AddFacultyCommandRequest request, CancellationToken cancellationToken)
    {
        List<Faculty> faculties = _mapper.Map<List<Faculty>>(request.AddFacultyCommandRequestFaculties);

        _facultyRepository.AddRange(faculties);

        await _facultyRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        AddFacultyResponse response = _mapper.Map<AddFacultyResponse>(faculties);

        return response;
    }
}
