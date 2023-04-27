using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityService.Domain.Entities;

namespace UniversityService.Application.Services.Repositories;

public interface IProvienceRepository : IReadRepository<Provience>, IWriteRepository<Provience>
{
}
