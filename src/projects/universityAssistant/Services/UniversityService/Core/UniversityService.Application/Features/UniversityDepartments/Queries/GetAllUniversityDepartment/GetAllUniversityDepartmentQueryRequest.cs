﻿using MediatR;
using Microsoft.AspNetCore.OData.Query;

namespace UniversityService.Application.Features.UniversityDepartments.Queries.GetAllUniversityDepartment;

public class GetAllUniversityDepartmentQueryRequest : IRequest<List<GetAllUniversityDepartmentResponseDto>>
{
    public ODataQueryOptions<GetAllUniversityDepartmentResponseDto>? Options { get; set; }
}
