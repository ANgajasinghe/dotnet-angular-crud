using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Reservation.API.Controllers;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ApiControllerBase
{
    
    [HttpGet]
    public async Task<IActionResult> Get()
        => Ok(await UnitOfWork.ProductRepository.FindAllAsync());

    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Product obj)
    {
        await UnitOfWork.ProductRepository.CreateAsync(obj);
        await UnitOfWork.SaveAsync();
        return CreatedAtAction(nameof(Get),await UnitOfWork.ProductRepository.FindAllAsync());
    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ret = await UnitOfWork.ProductRepository
            .FindSingleAsync(x => x.Id == id);

        if (ret is null)
            throw new ApplicationException("Cannot find requested data, Invalid Id");

        UnitOfWork.ProductRepository.Delete(ret);
        await UnitOfWork.SaveAsync();
        return Ok(await UnitOfWork.ProductRepository.FindAllAsync());
    }



    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Product obj)
    {
        if(obj.Id is 0)
            throw new ApplicationException("Invalid Id");
        UnitOfWork.ProductRepository.Update(obj);
        await UnitOfWork.SaveAsync();
        return Ok(await UnitOfWork.ProductRepository.FindAllAsync());
    }
}