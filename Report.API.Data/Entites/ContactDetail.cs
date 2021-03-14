using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Report.API.Data.Entites
{
    public class ContactDetail : BaseEntity
    {
        public Guid ContactRef { get; set; }
        public string Location { get; set; }
    }
}
