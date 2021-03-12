﻿using System.Collections.Generic;

namespace Contact.Data.Entities
{
    public class Contact : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public ICollection<Detail> Details { get; set; }
    }
}
