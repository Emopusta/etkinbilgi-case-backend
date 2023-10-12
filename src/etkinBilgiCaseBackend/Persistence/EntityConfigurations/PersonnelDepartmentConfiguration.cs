using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PersonnelDepartmentConfiguration : IEntityTypeConfiguration<PersonnelDepartment>
{
    public void Configure(EntityTypeBuilder<PersonnelDepartment> builder)
    {
        builder.ToTable("PersonnelDepartments").HasKey(pd => pd.Id);

        builder.Property(pd => pd.Id).HasColumnName("Id").IsRequired();
        builder.Property(pd => pd.PersonnelId).HasColumnName("PersonnelId");
        builder.Property(pd => pd.DepartmentId).HasColumnName("DepartmentId");
        builder.Property(pd => pd.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pd => pd.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pd => pd.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(pd => !pd.DeletedDate.HasValue);
    }
}