using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Personnel : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public string Image { get; set; }
        public virtual User? User{ get; set; }


        public Personnel()
        {

        }
        public Personnel(Guid id, string image, Guid userId)
        {
            Id = id;
            Image = image;
            UserId = userId;
        }
    }
}
