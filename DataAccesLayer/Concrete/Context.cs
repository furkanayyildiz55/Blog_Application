using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;


namespace DataAccesLayer.Concrete
{
    public class Context : DbContext
    {
        //Veritabanı adresini veriyoruz
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=DESKTOP-7CEF0R1;initial catalog=blog_db2;trusted_connection=true;TrustServerCertificate=True");
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
    }
}
