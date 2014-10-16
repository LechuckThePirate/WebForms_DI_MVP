using System;
using System.ComponentModel.DataAnnotations;

namespace ITCR.Domain.Entities
{
    public class Specie
    {
        [Key]
        public Guid SpecieId { get; set; }
        public string Description { get; set; }

        public Specie()
        {
            this.SpecieId = Guid.NewGuid();
        }

    }
}
