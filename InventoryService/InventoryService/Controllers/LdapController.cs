using InventoryService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class LdapController : ControllerBase
    {
        private ILDapService _ldapService;
        public LdapController(ILDapService ldapservice)
        {
            _ldapService = ldapservice;
        }

        [HttpGet("search")]
        public IActionResult Search(string userId)
        {
            var user = _ldapService.SearchUser(userId);
            return Ok(user);
        }
    }
}
