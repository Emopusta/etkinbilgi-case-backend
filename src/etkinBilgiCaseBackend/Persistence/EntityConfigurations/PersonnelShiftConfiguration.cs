using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PersonnelShiftConfiguration : IEntityTypeConfiguration<PersonnelShift>
{
    public void Configure(EntityTypeBuilder<PersonnelShift> builder)
    {
        builder.ToTable("PersonnelShifts").HasKey(ps => ps.Id);

        builder.Property(ps => ps.Id).HasColumnName("Id").IsRequired();
        builder.Property(ps => ps.PersonnelId).HasColumnName("PersonnelId");
        builder.Property(ps => ps.StartShift).HasColumnName("StartShift");
        builder.Property(ps => ps.EndShift).HasColumnName("EndShift");
        builder.Property(ps => ps.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ps => ps.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ps => ps.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ps => !ps.DeletedDate.HasValue);
    }
}