using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityService.Domain.Entities;

namespace UniversityService.Persistence.EntityConfigurations
{
    public class DepartmentCultureEntityConfiguration : IEntityTypeConfiguration<DepartmentCulture>
    {
        public void Configure(EntityTypeBuilder<DepartmentCulture> builder)
        {
            builder.HasKey(dc => dc.Id);
            builder.HasOne(dc => dc.Department);
        }
    }
}
