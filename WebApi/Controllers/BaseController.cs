using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IConfiguration? _config = null;
        protected BaseController(IConfiguration config)
        {
            _config = config;
        }
    }
}
