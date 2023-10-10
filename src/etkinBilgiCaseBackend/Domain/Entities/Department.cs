using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Department : Entity<Guid>
{
    public string Name { get; set; }

    public Department()
    {

    }
    public Department(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}
