using MEO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MEO.Infra.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(c => c.Numero)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(c => c.Complemento)
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Bairro)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Cep)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(c => c.TipoLocalizacaoId)
                .IsRequired()
                .HasColumnType("int");

            builder.HasOne(c => c.Escola)
                .WithOne(c => c.Endereco);

            builder.ToTable("Enderecos");
        }
    }
}
