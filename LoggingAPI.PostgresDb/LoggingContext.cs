using LoggingAPI.PostgresDb.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace LoggingAPI.PostgresDb;

public class LoggingContext : DbContext
{
    public LoggingContext(DbContextOptions options) : base(options)
    {
        NpgsqlConnection.GlobalTypeMapper.MapEnum<LoggingAPI.Models.LogLevel>("loglevel");
    }

    public DbSet<LogMessage> LogMessages { get; set; } = null!;

    public DbSet<Application> Applications { get; set; } = null!;
}
