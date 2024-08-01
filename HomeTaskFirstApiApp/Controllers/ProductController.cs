using HomeTaskFirstApiApp.Dtos;
using HomeTaskFirstApiApp.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeTaskFirstApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<Product> list = new()
        {
            new(){Id=1, Name="Product1", Description="Salam", Price=10, Count=5},
            new(){Id=2, Name="Product2", Description="Salam", Price=20, Count=10},
            new(){Id=3, Name="Product3", Description="Salam", Price=30, Count=15},
            new(){Id=4, Name="Product4", Description="Salam", Price=40, Count=20}
        };

        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            return StatusCode(200, list);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var existProduct = list.FirstOrDefault(x => x.Id == id);
            if (existProduct == null) return StatusCode(StatusCodes.Status404NotFound);
            return StatusCode(StatusCodes.Status200OK, existProduct);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateProductDto productDto)
        {
            var newProduct = new Product
            {
                Id = list.Count > 0 ? list.Max(x => x.Id) + 1 : 1, 
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Count = productDto.Count
            };
            list.Add(newProduct);
            return StatusCode(StatusCodes.Status201Created, newProduct);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CreateProductDto productDto)
        {
            var existProduct = list.FirstOrDefault(y => y.Id == id);
            if (existProduct == null) return NotFound();
            existProduct.Name = productDto.Name;
            existProduct.Description = productDto.Description;
            existProduct.Price = productDto.Price;
            existProduct.Count = productDto.Count;
            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existProduct = list.FirstOrDefault(x => x.Id == id);
            if (existProduct == null) return NotFound();
            list.Remove(existProduct);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
