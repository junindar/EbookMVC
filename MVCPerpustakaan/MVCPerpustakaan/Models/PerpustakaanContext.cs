
using System.Data.Entity;


namespace MVCPerpustakaan.Models
{
    public class PerpustakaanContext : DbContext
    {
    
        public PerpustakaanContext() : base("name=PerpustakaanContext")
        {
        }

        public DbSet<Kategori> Kategoris { get; set; }

        public DbSet<Buku> Bukus { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }


    }
}
