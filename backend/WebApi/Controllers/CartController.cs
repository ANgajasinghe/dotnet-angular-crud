using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Reservation.API.Controllers;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartController : ApiControllerBase
{
    
    [HttpGet]
    public async Task<IActionResult> Get()
        => Ok(await UnitOfWork.CartRepository.FindAllAsync());

    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Cart obj)
    {
        await UnitOfWork.CartRepository.CreateAsync(obj);
        await UnitOfWork.SaveAsync();
        return CreatedAtAction(nameof(Get),await UnitOfWork.CartRepository.FindAllAsync());
    }
    
    [HttpPost("all")]
    public async Task<IActionResult> Post([FromBody] List<Cart> obj)
    {
        await UnitOfWork.CartRepository.CreateAllAsync(obj);
        await UnitOfWork.SaveAsync();
        return CreatedAtAction(nameof(Get),await UnitOfWork.CartRepository.FindAllAsync());
    }
    

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ret = await UnitOfWork.CartRepository
            .FindSingleAsync(x => x.Id == id);

        if (ret is null)
            throw new ApplicationException("Cannot find requested data, Invalid Id");

        UnitOfWork.CartRepository.Delete(ret);
        await UnitOfWork.SaveAsync();
        return Ok(await UnitOfWork.CartRepository.FindAllAsync());
    }



    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Cart obj)
    {
        if(obj.Id is 0)
            throw new ApplicationException("Invalid Id");
        UnitOfWork.CartRepository.Update(obj);
        await UnitOfWork.SaveAsync();
        return Ok(await UnitOfWork.CartRepository.FindAllAsync());
    }
}