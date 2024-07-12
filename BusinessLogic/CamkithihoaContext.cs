using BusinessLogic.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CamkithihoaContext : DbContext
    {
        public CamkithihoaContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("FPTWeb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FeedBacks>()
                .HasOne(f => f.User)
                .WithMany(u => u.FeedBack)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.NoAction); // Hoặc DeleteBehavior.Restrict

            modelBuilder.Entity<FeedBacks>()
                .HasOne(f => f.Blog)
                .WithMany(b => b.FeedBack)
                .HasForeignKey(f => f.BlogId)
                .OnDelete(DeleteBehavior.NoAction); // Hoặc DeleteBehavior.Restrict
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Message> Messages { get; set; }

        public virtual DbSet<TopicCategory> TopicCategories { get; set; }

        public virtual DbSet<Topic> Topics { get; set; }

        public virtual DbSet<Achievement> Achievements { get; set; }

        public virtual DbSet<FeedBacks> FeedBacks { get; set; }

        public virtual DbSet<FPTHistory> FPTHistories { get; set; }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<News> News { get; set; }
    }
}
