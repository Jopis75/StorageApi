using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StorageApi.DbContexts;
using StorageApi.Dtos;
using StorageApi.Models;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(StorageDbContext context, IMapper mapper, IValidator<CreateProductDto> createProductDtoValidator, IValidator<UpdateProductDto> updateProductDtoValidator) : ControllerBase
{
    // POST: api/Product/CreateAsync
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    [Route("CreateAsync")]
    [ProducesResponseType(typeof(ProductDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProductDto>> CreateAsync([FromBody] CreateProductDto createProductDto)
    {
        var validationResult = await createProductDtoValidator.ValidateAsync(createProductDto, CancellationToken.None);

        if (!validationResult.IsValid)
        {
            var ex = new ValidationException(validationResult.Errors);
            return BadRequest(ex.Message);
        }

        var product = mapper.Map<Product>(createProductDto);

        context.Products.Add(product);

        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(ReadByIdAsync), new { id = product.Id }, createProductDto);
    }

    // DELETE: api/Product/DeleteAsync/5
    [HttpDelete]
    [Route("DeleteAsync/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProduct(int? id)
    {
        var product = await context.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        context.Products.Remove(product);

        await context.SaveChangesAsync();

        return NoContent();
    }

    // GET: api/Product/ReadAllAsync
    [HttpGet]
    [Route("ReadAllAsync")]
    [ProducesResponseType(typeof(IEnumerable<ProductDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ProductDto>>> ReadAllAsync()
    {
        var products = await context.Products.ToListAsync();

        var productDtos = products.Select(mapper.Map<ProductDto>);

        return Ok(productDtos);
    }

    // GET: /api/Product/ReadByCategoryAsync?category=category
    [HttpGet]
    [Route("ReadByCategoryAsync")]
    [ProducesResponseType(typeof(IEnumerable<ProductDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ProductDto>>> ReadByCategoryAsync([FromQuery] string category)
    {
        var products = await context.Products.Where(p => p.Category.Equals(category)).ToListAsync();

        var productDtos = products.Select(mapper.Map<ProductDto>);

        return Ok(productDtos);
    }

    // GET: api/Product/ReadByIdAsync/5
    [HttpGet]
    [Route("ReadByIdAsync/{id}")]
    [ActionName(nameof(ReadByIdAsync))]
    [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductDto>> ReadByIdAsync(int id)
    {
        var product = await context.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        var productDto = mapper.Map<ProductDto>(product);
        
        return Ok(productDto);
    }

    //  GET: /api/Product/ReadStatsAsync
    [HttpGet]
    [Route("ReadStatsAsync")]
    [ProducesResponseType(typeof(StatsDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<StatsDto>> ReadStatsAsync()
    {
        var totalProductCount = await context.Products.SumAsync(p => p.Count);
        var totalStoragePrice = await context.Products.SumAsync(p => p.Count * p.Price);
        var averagePrice = await context.Products.AverageAsync(p => p.Price);

        var statsDto = new StatsDto(totalProductCount, totalStoragePrice, averagePrice);

        return Ok(statsDto);
    }

    // PUT: api/Product/UpdateAsync
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut]
    [Route("UpdateAsync")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateProductDto updateProductDto)
    {
        var validationResult = await updateProductDtoValidator.ValidateAsync(updateProductDto, CancellationToken.None);

        if (!validationResult.IsValid)
        {
            var ex = new ValidationException(validationResult.Errors);
            return BadRequest(ex.Message);
        }
        
        var product = await context.Products.FindAsync(updateProductDto.Id);

        if (product == null)
        {
            return NotFound();
        }

        product = mapper.Map<Product>(updateProductDto);

        context.Entry(product).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductExists(product.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    private bool ProductExists(int? id) => context.Products.Any(e => e.Id == id);
}
