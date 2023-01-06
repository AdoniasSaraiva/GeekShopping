using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.model.Context
{
    public class ContextDb : DbContext
    {
        public ContextDb() { }
        public ContextDb(DbContextOptions<ContextDb> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
