using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using SteckPointTestSetData.Domain.Entities;

namespace SteckPointTestSeTData.Infrastructure.Data
{
    public class UsersContex : DbContext
    {
        private readonly IConfiguration configuration;
        public DbSet<UsersDTO> Users { get; set; }
        public DbSet<OrganizationsDTO> Organizations { get; set; }
        public UsersContex(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connectionStr = configuration.GetSection("ConnectionString").Value;

            optionsBuilder.UseSqlServer(connectionStr, x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "dbo"));
        }
    }
}
