

using Flash.DAL.Datacontext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flash.DAL.Datacontext.Configuration
{
    class TeamEntityTypeConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.Property(e => e.Description)
                  .IsRequired()
                  .HasMaxLength(255)
                  .IsUnicode(false);
        }
    }
}
