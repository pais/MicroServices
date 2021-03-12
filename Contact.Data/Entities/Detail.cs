using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contact.Data.Entities
{
    public class Detail : BaseEntity
    {
        [ForeignKey("Contact")]
        public Guid ContactRef { get; set; }
        public int DetailType { get; set; }
        public string Content { get; set; }
    }
}
