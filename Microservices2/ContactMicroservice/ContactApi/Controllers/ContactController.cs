using ContactApi.Infrastructure;
using ContactApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        public readonly IContactApi _contactApi;
        public ContactController(IContactApi contactApi)
        {
            _contactApi = contactApi;
        }
        [Authorize]
        [HttpGet("{Id}")]
        public ContactDto GetContactById(int id)
        {
            return _contactApi.GetContactById(id);
        }
    }
}
