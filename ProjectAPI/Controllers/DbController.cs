using CoreLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbController : ControllerBase
    {
        private readonly IService _services;

        public DbController(IService services)
        {
            _services = services;
        }
        [HttpPost]
        public async Task<IActionResult> İnsertData(int musteriAdet, int sepetAdet)
        {
            await _services.CreateTestData(musteriAdet,sepetAdet);
            return Ok();
        }
    }
}
