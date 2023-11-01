using System.IdentityModel.Tokens.Jwt;
using System.Text;
using HealthTracker.Authentication.Configuration;
using HealthTracker.Authentication.Models.DTO.Incoming;
using HealthTracker.Authentication.Models.DTO.Outgoing;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HealthTracker.API.Controllers.V1;

public class AccountsController : BaseContrller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly JwtConfig _jwtConfig;
    public AccountsController(
        IUnitOfWork unitOfWork,
        UserManager<IdentityUser> userManager,
        IOptionsMonitor<JwtConfig> optionsMonitor) : base(unitOfWork)
    {
        _userManager = userManager;
        _jwtConfig = optionsMonitor.CurrentValue;
    }

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register(
        [FromBody] UserRegistrationRequestDto registrationDto)
    {
        if (ModelState.IsValid)
        {
            var userExits = await _userManager
                .FindByEmailAsync(registrationDto.Email);

            if (userExits is not null)
            {
                return BadRequest(new UserRegistrationResponseDto
                {
                    Success = false,
                    Errors = new List<string>{
                        "Email already in use"
                    }
                });
            }

            var user = new IdentityUser
            {
                Email = registrationDto.Email,
                UserName = registrationDto.Email,
                EmailConfirmed = true // Todo here upate that 
            };

            var isCreated = await _userManager.CreateAsync(user, registrationDto.Password);

            if (!isCreated.Succeeded)
            {
                return BadRequest(new UserRegistrationResponseDto
                {
                    Success = isCreated.Succeeded,
                    Errors = isCreated.Errors
                        .Select(error => error.Description)
                        .ToList()
                });
            }

            return Ok();

        }
        else
        {
            return BadRequest(new UserRegistrationResponseDto
            {
                Success = false,
                Errors = new List<string>{
                    "Invalid Payload"
                }
            });
        }
    }

    private string GenerateJwtToken(IdentityUser user)
    {
        var jwtHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {

        };
        return default!;
    }
}