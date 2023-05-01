using AutoMapper;
using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityService.Application.Services.Repositories;
using UniversityService.Domain.Entities;
using UniversityService.Persistence.Contexts;

namespace UniversityService.Persistence.Repositories;

public class DepartmentRepository : EfRepositoryBase<Department, UniversityServiceContext>, IDepartmentRepository
{
    public DepartmentRepository(UniversityServiceContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
