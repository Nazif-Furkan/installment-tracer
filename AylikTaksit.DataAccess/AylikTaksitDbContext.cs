using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace AylikTaksit.DataAccess;

public class AylikTaksitDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = new SqliteConnectionStringBuilder($"Data Source={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"aylik_taksit.db")};")
        {
            Mode = SqliteOpenMode.ReadWriteCreate,
        }.ToString();
        Console.WriteLine("connectionString: " + connectionString);
        optionsBuilder.UseSqlite(connectionString);
    }

    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<PaymentAccount> PaymentAccounts { get; set; }
    
    
}