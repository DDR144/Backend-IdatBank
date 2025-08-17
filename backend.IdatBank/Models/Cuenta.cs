namespace backend.IdatBank.Models
{
    public class Cuenta
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public decimal Saldo { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;
    }
}
