using Application.Features.OperationClaims.Constants;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasMany(oc => oc.UserOperationClaims);

        builder.HasData(getSeeds());
    }

    private HashSet<OperationClaim> getSeeds()
    {
        
        HashSet<OperationClaim> seeds =
            new()
            {
                new OperationClaim { Id = Guid.NewGuid(), Name = GeneralOperationClaims.Admin }
            };

        
        #region Personnels
        
        seeds.Add(new OperationClaim { Id = Guid.NewGuid(), Name = "Personnels.Admin" });
        
        seeds.Add(new OperationClaim { Id = Guid.NewGuid(), Name = "Personnels.Read" });
        seeds.Add(new OperationClaim { Id = Guid.NewGuid(), Name = "Personnels.Write" });
        
        seeds.Add(new OperationClaim { Id = Guid.NewGuid(), Name = "Personnels.Add" });
        seeds.Add(new OperationClaim { Id = Guid.NewGuid(), Name = "Personnels.Update" });
        seeds.Add(new OperationClaim { Id = Guid.NewGuid(), Name = "Personnels.Delete" });
        
        #endregion
        
        
        #region Departments
        
        seeds.Add(new OperationClaim { Id = Guid.NewGuid(), Name = "Departments.Admin" });
        
        seeds.Add(new OperationClaim { Id = Guid.NewGuid(), Name = "Departments.Read" });
        seeds.Add(new OperationClaim { Id = Guid.NewGuid(), Name = "Departments.Write" });
        
        seeds.Add(new OperationClaim { Id = Guid.NewGuid(), Name = "Departments.Add" });
        seeds.Add(new OperationClaim { Id = Guid.NewGuid(), Name = "Departments.Update" });
        seeds.Add(new OperationClaim { Id = Guid.NewGuid(), Name = "Departments.Delete" });
        
        #endregion
        
        
        #region PersonnelShifts
        
        seeds.Add(new OperationClaim { Id = Guid.NewGuid(), Name = "PersonnelShifts.Admin" });
        
        seeds.Add(new OperationClaim { Id = Guid.NewGuid(), Name = "PersonnelShifts.Read" });
        seeds.Add(new OperationClaim { Id = Guid.NewGuid(), Name = "PersonnelShifts.Write" });
        
        seeds.Add(new OperationClaim { Id = Guid.NewGuid(), Name = "PersonnelShifts.Add" });
        seeds.Add(new OperationClaim { Id = Guid.NewGuid(), Name = "PersonnelShifts.Update" });
        seeds.Add(new OperationClaim { Id = Guid.NewGuid(), Name = "PersonnelShifts.Delete" });
        
        #endregion
        
        
        #region PersonnelDepartments
        
        seeds.Add(new OperationClaim { Id = Guid.NewGuid(), Name = "PersonnelDepartments.Admin" });
        
        seeds.Add(new OperationClaim { Id = Guid.NewGuid(), Name = "PersonnelDepartments.Read" });
        seeds.Add(new OperationClaim { Id = Guid.NewGuid(), Name = "PersonnelDepartments.Write" });
        
        seeds.Add(new OperationClaim { Id = Guid.NewGuid(), Name = "PersonnelDepartments.Add" });
        seeds.Add(new OperationClaim { Id = Guid.NewGuid(), Name = "PersonnelDepartments.Update" });
        seeds.Add(new OperationClaim { Id = Guid.NewGuid(), Name = "PersonnelDepartments.Delete" });
        
        #endregion
        
        return seeds;
    }
}
