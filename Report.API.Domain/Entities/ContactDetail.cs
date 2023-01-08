using Domain.Entities;
using System;

namespace Report.API.Domain.Entities
{
    public class ContactDetail : BaseEntity
    {
        public Guid ContactRef { get; set; }
        public Guid DetailRef { get; set; }
        public string Location { get; set; }
    }
}
