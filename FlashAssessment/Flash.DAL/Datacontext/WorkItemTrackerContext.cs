using Flash.DAL.Datacontext.Configuration;
using Flash.DAL.Datacontext.Models;
using Microsoft.EntityFrameworkCore;

namespace Flash.DAL.Datacontext
{
    public partial class WorkItemTrackerContext : DbContext
    {
        public WorkItemTrackerContext()
        {
        }

        public WorkItemTrackerContext(DbContextOptions<WorkItemTrackerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<WorkItem> WorkItem { get; set; }
        public virtual DbSet<WorkItemStatus> WorkItemStatus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=WorkItemTracker;Integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TeamEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WorkItemEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WorkItemStatusEntityTypeConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
