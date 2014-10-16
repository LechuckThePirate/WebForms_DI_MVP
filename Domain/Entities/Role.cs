using System;
using System.ComponentModel.DataAnnotations;

namespace ITCR.Domain.Entities
{
    public class Role 
    {
        [Key]
        public Guid RoleId { get; set; }
        public string Description { get; set; }

        public Role()
        {
            this.RoleId = Guid.NewGuid();
        }
    }
}
