using Lab5.Entities;
using Lab5.ValueConverters;
using Microsoft.EntityFrameworkCore;

namespace Lab5
{
    public class BookDatabaseContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public DbSet<Book> Books { get; set; } = null!;

        public BookDatabaseContext(IConfiguration configuration, DbContextOptions<BookDatabaseContext> options) : base(options) 
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entityBuilder =>
            {
                entityBuilder.HasKey(bookEntity => bookEntity.BookID);
                entityBuilder.Property(bookEntity => bookEntity.Title).IsRequired();
                entityBuilder.Property(bookEntity => bookEntity.Genre).IsRequired();
                entityBuilder.Property(bookEntity => bookEntity.AuthorFirstName).IsRequired();
                entityBuilder.Property(bookEntity => bookEntity.AuthorLastName).IsRequired();
                entityBuilder.Property(bookEntity => bookEntity.Publisher).IsRequired();
                entityBuilder.Property(bookEntity => bookEntity.DateOfPublication).IsRequired();
                entityBuilder.Property(bookEntity => bookEntity.PaperFormat).IsRequired();
                entityBuilder.Property(bookEntity => bookEntity.NumberOfPages).IsRequired();
            });
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<Enum>().HaveConversion<string>();
            configurationBuilder.Properties<DateOnly>().HaveConversion<DateOnlyToStringConverter>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("BookDatabase"));
        }

    }
}
