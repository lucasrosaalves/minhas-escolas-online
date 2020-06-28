using Microsoft.AspNetCore.Mvc;

namespace MEO.API.Controllers
{
    public class HomeController : BaseController
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("API is running");
        }
    }
}
