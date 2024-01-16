using Microsoft.EntityFrameworkCore;
using se4458_final.Models;

namespace se4458_final.Context
{
    public class PharmacyDbContext : DbContext
    {


        public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options)
            : base(options)
        {

        }



        public DbSet<User> Users { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

        public DbSet<Medicine> Medicines_New { get; set; }

        public DbSet<Pharmacie> Pharmacies { get; set; }
    }
}
