using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityService.Domain.Entities;

namespace UniversityService.Persistence.EntityConfigurations;

public class FacultyCultureEntityConfiguration : IEntityTypeConfiguration<FacultyCulture>
{
    public void Configure(EntityTypeBuilder<FacultyCulture> builder)
    {
        builder.HasKey(fc => fc.Id);
        builder.HasOne(fc => fc.Faculty);
    }
}
