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
    public DateTime StartShift { get; set; }
    public DateTime EndShift { get; set; }

    public PersonnelShift()
    {
    }

    public PersonnelShift(Guid id, Guid personnelId, DateTime startShift, DateTime endShift)
    {
        Id = id;
        PersonnelId = personnelId;
        StartShift = startShift;
        EndShift = endShift;
    }
}
