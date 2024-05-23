using Microsoft.EntityFrameworkCore;

namespace InsightDDD.Models
{
    public class InsightDbContext : DbContext
    {
        public DbSet<MediaDetail> MediaDetail { get; set; }

        public string DbPath { get; }

        public InsightDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "insight.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
