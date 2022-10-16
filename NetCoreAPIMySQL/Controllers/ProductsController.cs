using Microsoft.AspNetCore.Mvc;
using NetCoreAPIMySQL.Core.Entities;
using NetCoreAPIMySQL.Core.Repositories;

namespace NetCoreAPIMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository) {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts() {
            return Ok(await _productRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id) {
            return Ok(await _productRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product) {
            if (product == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _productRepository.Insert(product);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product) {
            if (product == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _productRepository.Update(product);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id) {
            var result = await _productRepository.Delete(id);

            return NoContent();
        }
    }
}
