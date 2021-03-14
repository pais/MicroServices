using Contact.Api.Service.Interfaces;
using Contact.API.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<List<ContactDto>> Get()
        {
            return await _contactService.GetAllContacts();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDetailDto>> Get(Guid id)
        {
            return await _contactService.GetContactDetail(id);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ContactDto contact)
        {
            var response = await _contactService.AddContact(contact);
            return Ok(response);
        }

        [HttpPost, Route("add-detail")]
        public async Task<ActionResult> PostDetail([FromBody] DetailDto detail, Guid contactId)
        {
            var response = await _contactService.AddDetail(detail, contactId);
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _contactService.DeleteContact(id);
        }

        [HttpDelete("delete-detail/{id}")]
        public async Task DeleteDetail(Guid id)
        {
            await _contactService.DeleteDetail(id);
        }
    }
}
