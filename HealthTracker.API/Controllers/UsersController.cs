using HealthTracker.Entities.Dtos.Incoming;
using HealthTracker.Entities.DbSet;
using Microsoft.AspNetCore.Mvc;
using HealthTracker.Data.Configuration;

namespace HealthTracker.API;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public UsersController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ??
            throw new ArgumentNullException(nameof(unitOfWork));
    }

    [HttpGet]
    [Route("GetUser")]
    public IActionResult GetUser(Guid id)
    {
        throw new NotImplementedException();
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
    public IActionResult AddUser(UserDto userDto)
    {
        throw new NotImplementedException();
    }
}
