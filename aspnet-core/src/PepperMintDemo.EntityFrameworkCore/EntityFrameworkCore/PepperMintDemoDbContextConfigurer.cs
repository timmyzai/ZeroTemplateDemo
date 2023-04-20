using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace PepperMintDemo.EntityFrameworkCore
{
    public static class PepperMintDemoDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<PepperMintDemoDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<PepperMintDemoDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}