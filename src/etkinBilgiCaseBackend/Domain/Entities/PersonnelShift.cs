using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class PersonnelShift : Entity<Guid>
{
    public Guid PersonnelId { get; set; }
    public string StartShift { get; set; }
    public string EndShift { get; set; }

    public PersonnelShift()
    {
    }

    public PersonnelShift(Guid id, Guid personnelId, string startShift, string endShift)
    {
        Id = id;
        PersonnelId = personnelId;
        StartShift = startShift;
        EndShift = endShift;
    }
}
