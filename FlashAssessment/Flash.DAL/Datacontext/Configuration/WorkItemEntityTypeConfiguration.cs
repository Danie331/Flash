
using Flash.DAL.Datacontext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flash.DAL.Datacontext.Configuration
{
    public class WorkItemEntityTypeConfiguration : IEntityTypeConfiguration<WorkItem>
    {
        public void Configure(EntityTypeBuilder<WorkItem> builder)
        {
            builder.Property(e => e.ItemDescription)
                  .IsRequired()
                  .HasMaxLength(255)
                  .IsUnicode(false);

            builder.HasOne(d => d.Status)
                .WithMany(p => p.WorkItem)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkItem_WorkItemStatus");

            builder.HasOne(d => d.User)
                .WithMany(p => p.WorkItem)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_WorkItem_User");
        }
    }
}
