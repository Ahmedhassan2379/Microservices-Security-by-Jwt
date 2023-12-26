using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReversationApi.Infrastructure;
using ReversationApi.Models;

namespace ReversationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReversationController : ControllerBase
    {
        public readonly IReversation _reversation;
        public ReversationController(IReversation reversation)
        {
            _reversation = reversation;
        }
        [Authorize(Roles ="Admin")]
        [HttpGet("{Id}")]
        public ReversationModels GetReversationById(int BkgNumber)
        {
            return _reversation.GetReversationById(BkgNumber);
        }
    }
}
