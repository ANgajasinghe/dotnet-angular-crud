using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Reservation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        private IUnitOfWork _unitOfWork = null!;

        protected IUnitOfWork UnitOfWork => _unitOfWork ??= HttpContext.RequestServices.GetRequiredService<IUnitOfWork>();

       
    }
}