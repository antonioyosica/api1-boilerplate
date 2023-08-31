using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreAPI.UI.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    public class BaseController : ControllerBase
    {

    }
}