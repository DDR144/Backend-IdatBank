using backend.IdatBank.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.IdatBank.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CuentasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> ObtenerCuentas(int usuarioId)
        {
            var cuentas = await _context.Cuentas
                .Where(c => c.UsuarioId == usuarioId)
                .Select(c => new
                {
                    c.Id,
                    c.Tipo,
                    c.Saldo
                })
                .ToListAsync();

            if (!cuentas.Any())
            {
                return NotFound("No se encontraron cuentas para este usuario.");
            }

            return Ok(cuentas);
        }
    }
}
