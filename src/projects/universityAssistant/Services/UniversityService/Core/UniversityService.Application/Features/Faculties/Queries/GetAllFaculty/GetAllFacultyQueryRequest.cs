using Core.Persistence.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityService.Application.Features.Faculties.Queries.GetAllFaculty;

public class GetAllFacultyQueryRequest : IRequest<IPaginate<GetAllFacultyResponseDto>>
{
    public int Index { get; set; }
    public int Size { get; set; }
}
