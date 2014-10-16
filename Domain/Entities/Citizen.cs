using System;
using System.ComponentModel.DataAnnotations;

namespace ITCR.Domain.Entities
{
    public class Citizen
    {
        [Key]
        public Guid CitizenId { get; set; }
        public string Name { get; set; }
        public virtual Specie Specie { get; set; }
        public virtual Role Role { get; set; }
        public StatusEnum Status { get; set; }

        public Citizen()
        {
            this.CitizenId = Guid.NewGuid();
        }
    }
}
