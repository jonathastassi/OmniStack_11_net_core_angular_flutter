using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Database.Configuration
{
    public class OngModelConfiguration : IEntityTypeConfiguration<Ong>
    {
        public void Configure(EntityTypeBuilder<Ong> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
            builder.Property(t => t.Email)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
            builder.Property(t => t.Password)
                    .IsRequired()
                    .HasColumnType("varchar(30)");
            builder.Property(t => t.Whatsapp)
                    .IsRequired()
                    .HasColumnType("varchar(30)");
            builder.Property(t => t.City)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
            builder.Property(t => t.Uf)
                    .IsRequired()
                    .HasColumnType("varchar(2)");

            builder.HasIndex(t => t.Email)
                .IsUnique();
        }
    }
}