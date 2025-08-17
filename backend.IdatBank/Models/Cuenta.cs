namespace backend.IdatBank.Models
{
    public class Cuenta
    {
        public int Id { get; set; }
        public int CuentaOrigenId { get; set; }
        public int CuentaDestinoId { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
