using System.Reflection.Metadata;
using HealthTracker.Entities.Dtos.Incoming;
using HealthTracker.Entities.DbSet;
using Microsoft.AspNetCore.Mvc;
using HealthTracker.Data.Configuration;

namespace HealthTracker.API.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/{version:apiVersion}/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public UsersController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ??
            throw new ArgumentNullException(nameof(unitOfWork));
    }

    [HttpGet]
    [Route("GetUser", Name = "GetUser")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);
        return Ok(user);
    }

    [HttpGet]
    [Route("GetUsersNumber")]
    public async Task<IActionResult> GetUsersNumber()
    {
        var users = await _unitOfWork.Users.GetAllAsync();
        return Ok(users.Count());
    }

    [HttpGet]
    [Route("GetUsers")]
    public async Task<IActionResult> GetUsersAsync()
    {
        var users = await _unitOfWork.Users.GetAllAsync();
        return Ok(users);
    }

    [HttpPost]
    [Route("AddUser")]
    public async Task<IActionResult> AddUser(UserDto userDto)
    {
        var user = new User
        {
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            DateOfBirth = userDto.DateOfBirth,
            Country = userDto.Country,
            Phone = userDto.Phone,
            Email = userDto.Email,
        };

        await _unitOfWork.Users.AddAsync(user);
        await _unitOfWork.CompleteAsync();

        return CreatedAtRoute("GetUser", new { id = user.Id }, userDto);
    }
}
