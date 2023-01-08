using System.Collections.Generic;

namespace Contact.API.Domain.Dto
{
    public class ContactDetailDto : ContactDto
    {
        public List<DetailDto> Details { get; set; }
    }
}