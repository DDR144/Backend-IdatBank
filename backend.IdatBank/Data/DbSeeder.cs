using backend.IdatBank.Models;


namespace backend.IdatBank.Data
{
    public class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Usuarios.Any()) return;

            var usuario = new Usuario
            {
                Nombre = "Pepito",
                NumeroTarjeta = "1234567890123456",
                ClaveInternet = "1234",
                Cuentas = new List<Cuenta>
        {
            new Cuenta { Tipo = "Sueldo", Saldo = 999999.00m },
            new Cuenta { Tipo = "Ahorros", Saldo = 999999.00m }
        }
            };

            context.Usuarios.Add(usuario);
            context.SaveChanges();
        }
    }
}
