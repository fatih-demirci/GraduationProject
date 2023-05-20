using Core.Persistence.Repositories;
using UniversityService.Domain.Entities;

namespace UniversityService.Application.Services.Repositories;

public interface IUniversityCommentRepository : IReadRepository<UniversityComment>, IWriteRepository<UniversityComment>
{
}