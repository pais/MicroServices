using System;
using System.Collections.Generic;
using System.Text;

namespace Contact.API.Domain.Dto
{
    public class ContactDetailDto : ContactDto
    {
        public List<DetailDto> Details { get; set; }
    }
}
