using AutoMapper;
using MediatR;
using UniversityService.Application.Services.Repositories;
using UniversityService.Domain.Entities;

namespace UniversityService.Application.Features.Universities.Commands.AddUniversity;

public class AddUniversityCommandRequestHandler : IRequestHandler<AddUniversityCommandRequest, AddUniversityResponse>
{
    private readonly IUniversityRepository _universityRepository;
    private readonly IMapper _mapper;

    public AddUniversityCommandRequestHandler(IUniversityRepository universityRepository, IMapper mapper)
    {
        _universityRepository = universityRepository;
        _mapper = mapper;
    }

    public async Task<AddUniversityResponse> Handle(AddUniversityCommandRequest request, CancellationToken cancellationToken)
    {
        University university = _mapper.Map<University>(request);

        university = _universityRepository.Add(university);

        await _universityRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        AddUniversityResponse response = _mapper.Map<AddUniversityResponse>(university);

        return response;
    }
}
