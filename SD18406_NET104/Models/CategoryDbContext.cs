using Microsoft.EntityFrameworkCore;

namespace SD18406_NET104.Models
{
    public class CategoryDbContext :DbContext
    {
        public CategoryDbContext(DbContextOptions<CategoryDbContext> options) : base(options) 
        { 
        }

        public DbSet<Category> Categories { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server =DESKTOP-DII2Q16\\SQLEXPRESS ; Database= SD18406_demo1 ; Trusted_Connection= True;TrustServerCertificate=True")
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID=1, Name= "Hung", DisplayOrder= 1},
                new Category { CategoryID = 2, Name = "Banh", DisplayOrder = 9 },
                new Category { CategoryID = 3, Name = "Keo", DisplayOrder = 5 },
                new Category { CategoryID = 4, Name = "Khoai", DisplayOrder = 8 },
                new Category { CategoryID = 5, Name = "Dua hau", DisplayOrder = 5 }
                );
        }
    }
}
