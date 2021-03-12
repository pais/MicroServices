using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Detail : BaseEntity
    {
        public Guid ContactRef { get; set; }
        public int DetailType { get; set; }
        public string Content { get; set; }
    }
}
