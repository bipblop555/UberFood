using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UberFood.Core.Context;

namespace UberFood.Api.Controllers;

[Controller]
[Route("/api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly DataContext _dataContext;

    public ProductController(DataContext ctx)
    {
        _dataContext = ctx;
    }

    [HttpGet]
    public async Task<IResult> GetProducts()
    {
        try
        {
            var products = await _dataContext.Products.ToListAsync();
            return Results.Ok(products);
        } catch (Exception ex)
        {
            return Results.InternalServerError(ex.Message);
        }
    }
}
