using DevCodeChallenge.Data;
using DevCodeChallenge.DTO;
using DevCodeChallenge.Entities;
using DevCodeChallenge.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DevCodeChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeShopController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly NasaService _nasaService;
        public CoffeeShopController(DataContext context, NasaService nasaService)
        {
            _context = context;
            _nasaService = nasaService;
        }


        //Get all the coffees in the DB and return a Json with 200 status Code, if its empty it will give me a out of range exception.
        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<List<CoffeeProduct>>> GetAllCoffees()
        {
            var products = await _context.coffeeProducts.ToListAsync();

            return Ok(products);
        }

        [HttpGet("GetOneCoffee/{id}")]
        public async Task<ActionResult<CoffeeProduct>> GetById(Guid id)
        {
            

            
            var coffeeProducts = await _context.coffeeProducts.FindAsync(id);
            if (coffeeProducts == null)
                return NotFound("Could not find the ID");

            return Ok(coffeeProducts);
        }

      
        [HttpPost("CoffeePurchase")]
        public async Task<ActionResult<CoffeeProduct>> CreatePurchase(CoffeeProductDto dto)
        {
            var coffee = new CoffeeProduct
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                CoffeePrice = dto.Price,
                PurchaseDate = dto.date, // sempre o backend define
            };

            // Busca APOD da data da compra
            var apod = await _nasaService.GetApodByDateAsync(coffee.PurchaseDate);

            coffee.NasaTitle = apod.Title;
            coffee.NasaUrl = apod.Url;
            coffee.NasaExplanation = apod.Explanation;

            _context.coffeeProducts.Add(coffee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = coffee.Id }, coffee);
        }

        [HttpPut("UpdateProduct/{id}")]
        public async Task<ActionResult<CoffeeProduct>> UpdateProduct(Guid id,CoffeeProductDto dto)
        {
            var product = await _context.coffeeProducts.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return BadRequest();
            }

            product.Name = dto.Name;
            product.CoffeePrice = dto.Price;

            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpDelete("DeleteProduct/{id}")]
        public async Task<ActionResult<CoffeeProduct>> DeleteProduct(Guid id) 
        {
            var product = await _context.coffeeProducts.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null) 
            {
                return NotFound("  Product not found ");
            }
            _context.coffeeProducts.Remove(product); 
            
            await _context.SaveChangesAsync();


            return Ok("Product was deleted successfully");
        }
    }
}
