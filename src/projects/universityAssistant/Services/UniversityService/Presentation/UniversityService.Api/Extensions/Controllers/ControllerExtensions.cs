﻿using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using UniversityService.Application.Features.Universities.Queries.GetAllUniversity;
using UniversityService.Application.Features.UniversityComments.Queries.GetAllUniversityComment;
using UniversityService.Application.Features.UniversityDepartments.Queries.GetAllUniversityDepartment;

namespace UniversityService.Api.Extensions.Controllers;

public static class ControllerExtensions
{
    public static IMvcBuilder ConfigureControllers(this IServiceCollection services)
    {
        IMvcBuilder mvcBuilder = services.AddControllers().AddOData(options =>
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<GetAllUniversityDepartmentResponseDto>("UniversityDepartments");
            builder.EntitySet<GetAllUniversityResponseDto>("Universities");
            builder.EntitySet<GetAllUniversityCommentResponseDto>("UniversityComments");

            options.AddRouteComponents("odata", builder.GetEdmModel());

            options.EnableQueryFeatures();
        });

        return mvcBuilder;
    }
}
