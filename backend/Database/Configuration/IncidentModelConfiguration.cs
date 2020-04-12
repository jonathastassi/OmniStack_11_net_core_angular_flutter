using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Database.Configuration
{
    public class IncidentModelConfiguration : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
            builder.Property(t => t.Description)
                    .IsRequired();
            builder.Property(t => t.Value)
                    .IsRequired();

            builder.HasOne(t => t.Ong)
                .WithMany(t => t.Incidents)
                .HasForeignKey(t => t.OngId)
                .HasConstraintName("FK_INCIDENT_ONG_ID");
        }
    }
}