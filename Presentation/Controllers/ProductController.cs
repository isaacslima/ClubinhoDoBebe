using ClubinhoDoBebe.Application.Common.Models.Request;
using ClubinhoDoBebe.Domain.Entities.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClubinhoDoBebe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly ILogger<AuthController> _logger;

        public ProductController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = new List<Product>
                {
                    new Product("jumperoo", (decimal)120.00, "123123"),
                    new Product("jumperoo", (decimal)80.00, "123123"),
                };

                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[GetAll] Erro ao buscar produtos Erro: {ex.Message}");
                return BadRequest(ex);
            }
        }
    }
}
