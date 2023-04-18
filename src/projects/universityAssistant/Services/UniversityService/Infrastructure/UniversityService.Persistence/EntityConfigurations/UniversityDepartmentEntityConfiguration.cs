using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityService.Domain.Entities;

namespace UniversityService.Persistence.EntityConfigurations;

public class UniversityDepartmentEntityConfiguration : IEntityTypeConfiguration<UniversityDepartment>
{
    public void Configure(EntityTypeBuilder<UniversityDepartment> builder)
    {
        builder.HasKey(ud => ud.Id);
        builder.HasOne(ud => ud.University);
        builder.HasOne(ud => ud.Department);
        builder.HasOne(ud => ud.Faculty);
    }
}
