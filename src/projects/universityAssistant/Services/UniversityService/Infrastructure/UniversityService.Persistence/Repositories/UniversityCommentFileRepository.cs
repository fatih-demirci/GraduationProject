using AutoMapper;
using Core.Persistence.Repositories;
using UniversityService.Application.Services.Repositories;
using UniversityService.Domain.Entities;
using UniversityService.Persistence.Contexts;

namespace UniversityService.Persistence.Repositories;

public class UniversityCommentFileRepository : EfRepositoryBase<UniversityCommentFile, UniversityServiceContext>, IUniversityCommentFileRepository
{
    public UniversityCommentFileRepository(UniversityServiceContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
