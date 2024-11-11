using Microsoft.AspNetCore.Mvc;

namespace AmmfApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseAmmfController : ControllerBase
    {
        protected IConfiguration? _config = null;
        public BaseAmmfController(IConfiguration config)
        {
            _config = config;
        }
    }
}
