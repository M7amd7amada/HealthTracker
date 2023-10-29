using HealthTracker.Entities.Dtos.Incoming;
using HealthTracker.Entities.DbSet;
using Microsoft.AspNetCore.Mvc;

namespace HealthTracker.API;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    [HttpGet]
    [Route("GetUser")]
    public IActionResult GetUser(Guid id)
    {
        ArgumentNullException.ThrowIfNull(_context.Users);

        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        return Ok(user);
    }

    [HttpGet]
    [Route("GetUsers")]
    public IActionResult GetUsers()
    {
        ArgumentNullException.ThrowIfNull(_context.Users);

        var users = _context.Users.Where(u => u.Status == Status.Active);
        if (users is null) return NotFound();
        return Ok(users.ToList());
    }

    [HttpPost]
    [Route("AddUser")]
    public IActionResult AddUser(UserDto userDto)
    {
        var user = new User
        {
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Phone = userDto.Phone,
            DateOfBirth = userDto.DateOfBirth,
            Country = userDto.Country,
            Email = userDto.Email
        };

        ArgumentNullException.ThrowIfNull(_context.Users);
        _context.Users.Add(user);
        _context.SaveChanges();
        return Ok();
    }
}
