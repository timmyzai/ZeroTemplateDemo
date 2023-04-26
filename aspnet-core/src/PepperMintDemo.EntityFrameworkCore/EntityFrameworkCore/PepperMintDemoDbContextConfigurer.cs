using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace PepperMintDemo.EntityFrameworkCore
{
    public static class PepperMintDemoDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<PepperMintDemoDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public static void Configure(DbContextOptionsBuilder<PepperMintDemoDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection, ServerVersion.AutoDetect(connection.ConnectionString));
        }
    }
}