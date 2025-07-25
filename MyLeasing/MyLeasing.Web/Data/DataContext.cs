using Microsoft.EntityFrameworkCore;
using MyLeasing.Web.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MyLeasing.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Owners> Owners { get; set; }

        // Método para alimentar a base de dados com 10 registros
        public void SeedOwners()
        {
            if (!Owners.Any())
            {
                Owners.AddRange(new List<Owners>
                {
                    new Owners { Document = "00000001", FirstName = "João", LastName = "Silva", OwnerName = "João Silva", FixedPhone = "213456789", CellPhone = "912345678", Address = "Rua das Flores, 123, Lisboa" },
                    new Owners { Document = "00000002", FirstName = "Pedro", LastName = "Ferreira", OwnerName = "Pedro Ferreira", FixedPhone = "214567890", CellPhone = "914567890", Address = "Rua do Carmo, 67, Coimbra" },
                    new Owners { Document = "00000003", FirstName = "Maria", LastName = "Santos", OwnerName = "Maria Santos", FixedPhone = "213987654", CellPhone = "913987654", Address = "Avenida da Liberdade, 45, Porto" },
                    new Owners { Document = "00000004", FirstName = "Ana", LastName = "Costa", OwnerName = "Ana Costa", FixedPhone = "215678901", CellPhone = "915678901", Address = "Praça do Comércio, 10, Faro" },
                    new Owners { Document = "00000005", FirstName = "Carlos", LastName = "Mendes", OwnerName = "Carlos Mendes", FixedPhone = "216789012", CellPhone = "916789012", Address = "Rua Augusta, 55, Lisboa" },
                    new Owners { Document = "00000006", FirstName = "Sofia", LastName = "Almeida", OwnerName = "Sofia Almeida", FixedPhone = "217890123", CellPhone = "917890123", Address = "Rua Santa Catarina, 20, Porto" },
                    new Owners { Document = "00000007", FirstName = "Miguel", LastName = "Pereira", OwnerName = "Miguel Pereira", FixedPhone = "218901234", CellPhone = "918901234", Address = "Rua da Alegria, 10, Braga" },
                    new Owners { Document = "00000008", FirstName = "Isabela", LastName = "Lopes", OwnerName = "Isabela Lopes", FixedPhone = "219012345", CellPhone = "919012345", Address = "Rua do Comércio, 12, Coimbra" },
                    new Owners { Document = "00000009", FirstName = "Rui", LastName = "Gomes", OwnerName = "Rui Gomes", FixedPhone = "210123456", CellPhone = "910123456", Address = "Avenida Central, 33, Faro" },
                    new Owners { Document = "00000010", FirstName = "Helena", LastName = "Nunes", OwnerName = "Helena Nunes", FixedPhone = "211234567", CellPhone = "911234567", Address = "Rua Nova, 77, Lisboa" }
                });

                SaveChanges();
            }
        }
    }
}