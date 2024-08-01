using HomeTaskFirstApiApp.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeTaskFirstApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        public List<Product> list = new()
        {
            new(){Id=1, Name="Product1", Description="Salam"},
            new(){Id=2, Name="Product2", Description="Salam"},
            new(){Id=3, Name="Product3", Description="Salam"},
            new(){Id=4, Name="Product4", Description="Salam"}
        };
        [HttpGet]
        public ActionResult<Product> Get()
        {
            return StatusCode(200, list);
        }
        [HttpGet("{id}")]

        public ActionResult<List<Product>> Get(int id) {

            var existProduct = list.FirstOrDefault(x => x.Id == id);
            if (existProduct == null) return StatusCode(StatusCodes.Status404NotFound);
            return StatusCode(StatusCodes.Status200OK, existProduct);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            list.Add(product);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
