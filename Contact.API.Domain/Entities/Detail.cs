using Domain.Entites;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contact.API.Domain.Entities
{
    public class Detail : BaseEntity
    {
        [ForeignKey("Contact")]
        public Guid ContactId { get; set; }
        public string Content { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
    }
}
