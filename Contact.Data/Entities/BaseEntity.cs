using System;
using System.ComponentModel.DataAnnotations;

namespace Contact.Data.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid UUID { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }
}
