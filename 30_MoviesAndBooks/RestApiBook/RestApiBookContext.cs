using Microsoft.EntityFrameworkCore;

public class RestApiBookContext(DbContextOptions<RestApiBookContext> options) : DbContext(options)
{
    public DbSet<RestApiBook.Book> Book { get; set; } = default!;
}
