using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StorageApi.DbContexts;
using StorageApi.Dtos;
using StorageApi.Models;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly StorageDbContext _context;

    public ProductsController(StorageDbContext context)
    {
        _context = context;
    }

    // GET: api/Product
    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var products = await _context.Products.ToListAsync();

        return Ok(products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Category = p.Category,
            Shelf = p.Shelf,
            Count = p.Count,
            Description = p.Description
        }));
    }

    // GET: api/Product/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return Ok(new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Category = product.Category,
            Shelf = product.Shelf,
            Count = product.Count,
            Description = product.Description
        });
    }

    //  GET: /api/products/stats
    [HttpGet]
    [Route("Stats")]
    public async Task<ActionResult<StatsDto>> GetStats()
    {
        var totalProductCount = await _context.Products.SumAsync(p => p.Count);
        var totalStoragePrice = await _context.Products.SumAsync(p => p.Count * p.Price);
        var averagePrice = await _context.Products.AverageAsync(p => p.Price);

        return Ok(new StatsDto
        {
            TotalProductCount = totalProductCount,
            TotalStoragePrice = totalStoragePrice,
            AveragePrice = averagePrice
        });
    }

    // GET: /api/products/?category=KategoriNamn
    [HttpGet]
    [Route("GetByCategory")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts([FromQuery] string category)
    {
        var products = await _context.Products.Where(p => p.Category.Equals(category)).ToListAsync();

        return Ok(products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Category = p.Category,
            Shelf = p.Shelf,
            Count = p.Count,
            Description = p.Description
        }));
    }

    // PUT: api/Product/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(int? id, UpdateProductDto updateProductDto)
    {
        if (id != updateProductDto.Id)
        {
            return BadRequest();
        }

        var product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        product.Name = updateProductDto.Name;
        product.Price = updateProductDto.Price;
        product.Category = updateProductDto.Category;
        product.Shelf = updateProductDto.Shelf;
        product.Count = updateProductDto.Count;
        product.Description = updateProductDto.Description;

        _context.Entry(product).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductExists(id))
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

    // POST: api/Product
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Product>> PostProduct(CreateProductDto createProductDto)
    {
        var product = new Product
        {
            Name = createProductDto.Name,
            Price = createProductDto.Price,
            Category = createProductDto.Category,
            Shelf = createProductDto.Shelf,
            Count = createProductDto.Count,
            Description = createProductDto.Description
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProduct", new { id = product.Id }, createProductDto);
    }

    // DELETE: api/Product/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int? id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductExists(int? id)
    {
        return _context.Products.Any(e => e.Id == id);
    }
}
