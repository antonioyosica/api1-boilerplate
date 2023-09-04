using CoreAPI.Domain.Commands.Account;
using CoreAPI.Domain.Extensions;
using CoreAPI.Domain.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreAPI.UI.Controllers
{
    [Route("v{version:apiVersion}/account")]
    public class AccountController : BaseController
    {
        private readonly ICqrsService _cqrs;

        public AccountController(ICqrsService cqrs)
        {
            _cqrs = cqrs;
        }

        [AllowAnonymous]
        [MapToApiVersion("1.0")]
        [HttpPost("")]
        // [Authorize(Roles = "admin,rh,avaliator")]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountCommand command)
        {
            var account = await _cqrs.SendAsync<Response, CreateAccountCommand>(new CreateAccountCommand
            {
                Name = command.Name,
                Phone = command.Phone,
                Email = command.Email
            });

            return Ok(account);
        }
    }
}