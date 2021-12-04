using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Reservation.API.Controllers;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductCategoryController : ApiControllerBase
{
    
    [HttpGet]
    public async Task<IActionResult> Get()
        => Ok(await UnitOfWork.ProductCategoryRepository.FindAllAsync());

    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProductCategory obj)
    {
        await UnitOfWork.ProductCategoryRepository.CreateAsync(obj);
        await UnitOfWork.SaveAsync();
        return CreatedAtAction(nameof(Get),await UnitOfWork.ProductCategoryRepository.FindAllAsync());
    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ret = await UnitOfWork.ProductCategoryRepository
            .FindSingleAsync(x => x.Id == id);

        if (ret is null)
            throw new ApplicationException("Cannot find requested data, Invalid Id");

        UnitOfWork.ProductCategoryRepository.Delete(ret);
        await UnitOfWork.SaveAsync();
        return Ok(await UnitOfWork.ProductCategoryRepository.FindAllAsync());
    }



    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ProductCategory obj)
    {
        if(obj.Id is 0)
            throw new ApplicationException("Invalid Id");
        UnitOfWork.ProductCategoryRepository.Update(obj);
        await UnitOfWork.SaveAsync();
        return Ok(await UnitOfWork.ProductCategoryRepository.FindAllAsync());
    }
}