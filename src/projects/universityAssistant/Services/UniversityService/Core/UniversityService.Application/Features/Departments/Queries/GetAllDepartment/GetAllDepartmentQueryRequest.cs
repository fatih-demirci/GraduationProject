using Core.Persistence.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityService.Application.Features.Departments.Queries.GetAllDepartment;

public class GetAllDepartmentQueryRequest : IRequest<IPaginate<GetAllDepartmentResponseDto>>
{
    public int Index { get; set; }
    public int Size { get; set; }
}
