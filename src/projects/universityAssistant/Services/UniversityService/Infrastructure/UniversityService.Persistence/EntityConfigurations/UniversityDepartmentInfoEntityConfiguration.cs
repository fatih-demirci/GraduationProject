using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityService.Domain.Entities;

namespace UniversityService.Persistence.EntityConfigurations;

public class UniversityDepartmentInfoEntityConfiguration : IEntityTypeConfiguration<UniversityDepartmentInfo>
{
    public void Configure(EntityTypeBuilder<UniversityDepartmentInfo> builder)
    {
        builder.HasKey(udi => udi.Id);
        builder.HasOne(udi => udi.UniversityDepartment);
    }
}
