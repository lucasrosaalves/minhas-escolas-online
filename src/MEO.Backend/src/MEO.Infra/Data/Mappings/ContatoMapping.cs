using MEO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MEO.Infra.Data.Mappings
{
    public class ContatoMapping : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Telefone)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Site)
                .HasColumnType("varchar(100)");

            builder.HasOne(c => c.Escola)
                .WithOne(c => c.Contato);

            builder.ToTable("Contatos");
        }
    }
}
