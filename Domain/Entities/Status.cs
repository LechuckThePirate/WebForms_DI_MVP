using System;

namespace ITCR.Domain.Entities
{
    public class Status
    {
        public StatusEnum statusId { get; set; }
        public string Description { get { return Enum.GetName(typeof (StatusEnum), this.statusId); } }
    }
}
