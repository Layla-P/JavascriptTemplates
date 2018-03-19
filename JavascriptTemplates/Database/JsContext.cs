using System.IO;
using JavascriptTemplates.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace JavascriptTemplates.Database
{
    public class JsContext : DbContext, IDesignTimeDbContextFactory<JsContext>
    {
        public DbSet<VideoGame> VideoGames { get; set; }

        public JsContext()
        {

        }

        public JsContext(DbContextOptions<JsContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoGame>(b =>
            {
                // ---- relationships ----
                b.HasKey(c => c.Id);
                
                b.Property(c => c.Id)
                    .IsRequired();

                b.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                b.Property(c => c.Genre)
                    .IsRequired();

                b.Property(c => c.StarRating)
                    .IsRequired();

                // ---- indexes ----
                b.HasIndex(c => c.Id);

            });
        }

        public JsContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<JsContext>();
            var connectionString = configuration.GetConnectionString("JsConnectionString");
            builder.UseSqlServer(connectionString);
            return new JsContext(builder.Options);
        }
    }
}

//dotnet ef migrations add initial
//dotnet ef database update