using backend.IdatBank.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.IdatBank.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.Cuentas)
                .FirstOrDefaultAsync(u =>
                    u.NumeroTarjeta == request.NumeroTarjeta &&
                    u.ClaveInternet == request.ClaveInternet);

            if (usuario == null)
            {
                return Unauthorized("Número de tarjeta o clave incorrecta.");
            }

            return Ok(new
            {
                usuario.Id,
                usuario.Nombre,
                usuario.NumeroTarjeta,
                Cuentas = usuario.Cuentas.Select(c => new
                {
                    c.Id,
                    c.Tipo,
                    c.Saldo
                })
            });
        }
    }
    public class LoginRequest
    {
        public string NumeroTarjeta { get; set; } = string.Empty;
        public string ClaveInternet { get; set; } = string.Empty;
    }
}
