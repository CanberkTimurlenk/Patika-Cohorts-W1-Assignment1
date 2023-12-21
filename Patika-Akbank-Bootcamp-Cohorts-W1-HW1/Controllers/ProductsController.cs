using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Patika_Akbank_NET_Bootcamp_Cohorts_Week_1_Homework_1.Db;
using Patika_Akbank_NET_Bootcamp_Cohorts_Week_1_Homework_1.Models;

namespace Patika_Akbank_NET_Bootcamp_Cohorts_Week_1_Homework_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // Get product by id 
        [HttpGet("{id}")]
        public IActionResult GetProduct([FromRoute] int id)
        {
            var product = SampleDb.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // create product
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            SampleDb.Products.Add(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // update product
        [HttpPut("{id}")]
        public IActionResult UpdateProduct([FromRoute] int id, [FromBody] Product product)
        {
            if (id != product.Id)
                return BadRequest();

            var productToUpdate = SampleDb.Products.FirstOrDefault(p => p.Id == id);

            if (productToUpdate == null)
                return NotFound();

            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            productToUpdate.CategoryId = product.CategoryId;

            return NoContent();
        }

        // partially update product
        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateProduct([FromRoute] int id, [FromBody] JsonPatchDocument<Product> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest();

            var productToUpdate = SampleDb.Products.FirstOrDefault(p => p.Id == id);

            if (productToUpdate == null)
                return NotFound();

            patchDoc.ApplyTo(productToUpdate);
            return NoContent();
        }

        // bonus 
        [HttpGet]
        public IActionResult GetProducts([FromQuery] string? name, [FromQuery] string? orderby, [FromQuery] string? order)
        {
            var products = SampleDb.Products.Where(p => string.IsNullOrEmpty(name) || p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

            if (!products.Any())
                return NotFound();

            order = order?.ToLower().Trim();

            switch (orderby)
            {
                case "name":
                    products = order == "desc" ? products.OrderByDescending(p => p.Name) : products.OrderBy(p => p.Name);
                    break;
                case "price":
                    products = order == "desc" ? products.OrderByDescending(p => p.Price) : products.OrderBy(p => p.Price);
                    break;

                default:
                    products = products.OrderBy(p => p.Id);
                    break;
            }

            return Ok(products);
        }
    }
}