using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        [HttpPost]
        public void Post([FromBody] DetailNotificationDto detailNotification)
        {
        }

        //[HttpPost, Route("add-detail")]
        //public async Task<ActionResult> AddDetail([FromBody] Detail detail, Guid contactId)
        //{
        //    var response = await _contactService.AddDetail(detail, contactId);
        //    return Ok(response);
        //}


        [HttpDelete("delete-detail/{id}")]
        public async Task DeleteDetail(Guid id)
        {
            //await _contactService.DeleteDetail(id);
        }

    }
}
