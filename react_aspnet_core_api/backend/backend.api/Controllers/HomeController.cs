using Microsoft.AspNetCore.Mvc;

namespace backend.api.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetHome()
        {
            await Task.CompletedTask;
            return Ok("Welcome to the home page");
        }
    }
}