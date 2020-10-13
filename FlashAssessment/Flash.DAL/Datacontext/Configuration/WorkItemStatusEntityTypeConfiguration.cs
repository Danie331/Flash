
using Flash.DAL.Datacontext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flash.DAL.Datacontext.Configuration
{
    class WorkItemStatusEntityTypeConfiguration : IEntityTypeConfiguration<WorkItemStatus>
    {
        public void Configure(EntityTypeBuilder<WorkItemStatus> builder)
        {
            builder.Property(e => e.StatusDescription)
                   .IsRequired()
                   .HasMaxLength(15)
                   .IsUnicode(false);
        }
    }
}