using ClubinhoDoBebe.Application.Common.Interface.Services;
using ClubinhoDoBebe.Application.Common.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace ClubinhoDoBebe.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        public readonly ICognitoService _cognitoService;
        public readonly ILogger<AuthController> _logger;

        public AuthController(ICognitoService cognitoService, ILogger<AuthController> logger)
        {
            _cognitoService = cognitoService;
            _logger = logger;
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var response = await _cognitoService.AuthenticateAsync(loginRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[Login] error when try to login ErrorMessage: {ex.Message}");
                return BadRequest(ex);
            }
        }
    }
}
