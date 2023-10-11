using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class PersonnelDepartment : Entity<Guid>
{
    public Guid PersonnelId { get; set; }
    public Guid DepartmentId { get; set; }
    public virtual Personnel Personnel { get; set; }
    public virtual Department Department { get; set; }

    public PersonnelDepartment()
    {
    }

    public PersonnelDepartment(Guid id, Guid personnelId, Guid departmentId)
    {
        Id = id;
        PersonnelId = personnelId;
        DepartmentId = departmentId;
    }
}
