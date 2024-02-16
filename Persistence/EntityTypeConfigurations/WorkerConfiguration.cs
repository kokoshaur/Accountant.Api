using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Persistence.EntityTypeConfigurations
{
    internal class WorkerConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).HasMaxLength(200);
            builder.Property(x => x.Surname).HasMaxLength(200);
            builder.Property(x => x.Patronymic).HasMaxLength(200);

            builder.Property(x => x.StructureUnit).HasMaxLength(400);
        }
    }
}
