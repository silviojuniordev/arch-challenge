using Financial.Entries.Domain.Entities.Entries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financial.Entries.Data.Mappings
{
    public class EntrieMapping : IEntityTypeConfiguration<Entrie>
    {
        public void Configure(EntityTypeBuilder<Entrie> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.EffectiveDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(x => x.EntrieType)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.Value)
                .IsRequired()
                .HasColumnType("decimal");

            builder.Property(x => x.Active)
                .IsRequired()
                .HasColumnType("bit");

            builder.ToTable("Entries");
        }
    }
}
