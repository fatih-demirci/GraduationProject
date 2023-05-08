using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityService.Application.Services.Repositories;
using UniversityService.Domain.Entities;

namespace UniversityService.Application.Features.Faculties.Commands.UpdateFaculty;

public class UpdateFacultyCommandRequestHandler : IRequestHandler<UpdateFacultyCommandRequest, UpdateFacultyResponse>
{
    private readonly IFacultyRepository _facultyRepository;
    private readonly IMapper _mapper;

    public UpdateFacultyCommandRequestHandler(IFacultyRepository facultyRepository, IMapper mapper)
    {
        _facultyRepository = facultyRepository;
        _mapper = mapper;
    }

    public async Task<UpdateFacultyResponse> Handle(UpdateFacultyCommandRequest request, CancellationToken cancellationToken)
    {
        Faculty faculty = _mapper.Map<Faculty>(request);

        _facultyRepository.Update(faculty);

        await _facultyRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        UpdateFacultyResponse response = _mapper.Map<UpdateFacultyResponse>(faculty);

        return response;
    }
}
