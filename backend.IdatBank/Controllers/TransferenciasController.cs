using backend.IdatBank.Data;
using backend.IdatBank.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.IdatBank.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferenciasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TransferenciasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> RealizarTransferencia([FromBody] TransferenciaRequest request)
        {
            if (request.CuentaOrigenId == request.CuentaDestinoId)
            {
                return BadRequest("La cuenta origen y destino no pueden ser iguales.");
            }

            var cuentaOrigen = await _context.Cuentas.FindAsync(request.CuentaOrigenId);
            var cuentaDestino = await _context.Cuentas.FindAsync(request.CuentaDestinoId);

            if (cuentaOrigen == null || cuentaDestino == null)
            {
                return NotFound("Una o ambas cuentas no existen.");
            }

            if (cuentaOrigen.Saldo < request.Monto)
            {
                return BadRequest("Saldo insuficiente.");
            }

            // Realizar transferencia
            cuentaOrigen.Saldo -= request.Monto;
            cuentaDestino.Saldo += request.Monto;

            // Registrar transferencia
            var transferencia = new Transferencia
            {
                CuentaOrigenId = request.CuentaOrigenId,
                CuentaDestinoId = request.CuentaDestinoId,
                Monto = request.Monto
            };

            _context.Transferencias.Add(transferencia);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Mensaje = "Transferencia realizada con éxito",
                transferencia.Id,
                transferencia.Fecha
            });
        }
    }
    public class TransferenciaRequest
    {
        public int CuentaOrigenId { get; set; }
        public int CuentaDestinoId { get; set; }
        public decimal Monto { get; set; }
    }
}
