using HealthTracker.Data.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace HealthTracker.API.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public abstract class BaseContrller : ControllerBase
{
    protected readonly IUnitOfWork unitOfWork;

    public BaseContrller(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
}