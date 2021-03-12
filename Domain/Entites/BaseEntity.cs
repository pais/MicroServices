using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entites
{
    public abstract class BaseEntity
    {
        public Guid UUID { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }
}
