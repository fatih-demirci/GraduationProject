using Core.Persistence.Repositories;
using UniversityService.Domain.Entities;

namespace UniversityService.Application.Services.Repositories;

public interface IUniversityCommentFileRepository : IReadRepository<UniversityCommentFile>, IWriteRepository<UniversityCommentFile>
{
}
