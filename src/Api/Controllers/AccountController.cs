using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Errors;
using Api.Extensions;
using Application.Identity.Commands;
using Application.Identity.Commands.RegisterUser;
using Application.Identity.Queries;
using Application.Identity.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class AccountController : ApiController
    {
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var email = HttpContext.User.GetEmailFromClaimsPrincipal();

            return await Mediator.Send(new GetCurrentUserQuery { Email = email });
        }

        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync(string email)
        {
            return await Mediator.Send(new CheckEmailExistsQuery { Email = email });
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginUserCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterUserCommand command)
        {
            if (CheckEmailExistsAsync(command.Email).Result.Value)
            {
                var errors = new Dictionary<string, string[]>();
                errors.Add("email", new[] { "Email address is in use" });

                return new BadRequestObjectResult(new ApiValidationErrorResponse(400, errors));
            }

            return await Mediator.Send(command);
        }
    }
}
