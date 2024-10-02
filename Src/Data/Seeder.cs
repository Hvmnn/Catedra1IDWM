using Catedra1IDWM.Src.Models;

namespace Catedra1IDWM.Src.Data
{
    public static class Seeder
    {
        public static async Task Seed(DataContext context)
        {
            if(context.Usuarios.Any())
            {
                return;
            }

            var usuarios = new List<User>
            {
                new User
                {
                    Rut = "12345678-5",
                    Nombre = "Juan Perez",
                    Correo = "juan.perez@example.com",
                    Genero = "Masculino",
                    FechaNacimiento = new DateTime(1990, 5, 10)
                },
                new User
                {
                    Rut = "23456789-6",
                    Nombre = "Ana Gonzalez",
                    Correo = "ana.gonzalez@example.com",
                    Genero = "Femenino",
                    FechaNacimiento = new DateTime(1985, 8, 20)
                },
                new User
                {
                    Rut = "34567890-7",
                    Nombre = "Carlos Morales",
                    Correo = "carlos.morales@example.com",
                    Genero = "Masculino",
                    FechaNacimiento = new DateTime(1978, 2, 15)
                },
                new User
                {
                    Rut = "45678901-8",
                    Nombre = "Marta Reyes",
                    Correo = "marta.reyes@example.com",
                    Genero = "Femenino",
                    FechaNacimiento = new DateTime(1995, 12, 25)
                },
                new User
                {
                    Rut = "56789012-9",
                    Nombre = "Luis Castro",
                    Correo = "luis.castro@example.com",
                    Genero = "Masculino",
                    FechaNacimiento = new DateTime(2000, 1, 5)
                },
                new User
                {
                    Rut = "67890123-4",
                    Nombre = "Camila Vargas",
                    Correo = "camila.vargas@example.com",
                    Genero = "Femenino",
                    FechaNacimiento = new DateTime(1992, 6, 10)
                },
                new User
                {
                    Rut = "78901234-5",
                    Nombre = "Pedro Silva",
                    Correo = "pedro.silva@example.com",
                    Genero = "Masculino",
                    FechaNacimiento = new DateTime(1980, 9, 30)
                },
                new User
                {
                    Rut = "89012345-6",
                    Nombre = "Lucia Ramirez",
                    Correo = "lucia.ramirez@example.com",
                    Genero = "Femenino",
                    FechaNacimiento = new DateTime(1998, 4, 18)
                },
                new User
                {
                    Rut = "90123456-7",
                    Nombre = "Javier Diaz",
                    Correo = "javier.diaz@example.com",
                    Genero = "Masculino",
                    FechaNacimiento = new DateTime(1975, 7, 22)
                },
                new User
                {
                    Rut = "01234567-8",
                    Nombre = "Paula Rojas",
                    Correo = "paula.rojas@example.com",
                    Genero = "Femenino",
                    FechaNacimiento = new DateTime(1987, 3, 12)
                }
            };

            await context.Usuarios.AddRangeAsync(usuarios);
            await context.SaveChangesAsync();
        }
    }
}