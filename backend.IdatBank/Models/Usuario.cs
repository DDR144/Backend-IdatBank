namespace backend.IdatBank.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public string NumeroTarjeta { get; set; } = string.Empty;
        public string ClaveInternet { get; set; } = string.Empty;

        public List<Cuenta> Cuentas { get; set; } = new();
    }
}
