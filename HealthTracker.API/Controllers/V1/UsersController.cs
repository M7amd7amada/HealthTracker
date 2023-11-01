using HealthTracker.Entities.Dtos.Incoming;
using HealthTracker.Entities.DbSet;
using Microsoft.AspNetCore.Mvc;

namespace HealthTracker.API.Controllers.V1;

public class UsersController : BaseContrller
{
    public UsersController(IUnitOfWork unitOfWork)
        : base(unitOfWork) { }

    [HttpGet]
    [Route("GetUser", Name = "GetUser")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        var user = await unitOfWork.Users.GetByIdAsync(id);
        return Ok(user);
    }

    [HttpGet]
    [Route("GetUsersNumber")]
    public async Task<IActionResult> GetUsersNumber()
    {
        var users = await unitOfWork.Users.GetAllAsync();
        return Ok(users.Count());
    }

    [HttpGet]
    [Route("GetUsers")]
    public async Task<IActionResult> GetUsersAsync()
    {
        var users = await unitOfWork.Users.GetAllAsync();
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

        await unitOfWork.Users.AddAsync(user);
        await unitOfWork.CompleteAsync();

        return CreatedAtRoute("GetUser", new { id = user.Id }, userDto);
    }
}
