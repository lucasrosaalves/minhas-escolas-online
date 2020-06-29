using MEO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MEO.Infra.Data.Mappings
{
    public class EscolaMapping : IEntityTypeConfiguration<Escola>
    {
        public void Configure(EntityTypeBuilder<Escola> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Codigo)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.ToTable("Escolas");
        }
    }
}
