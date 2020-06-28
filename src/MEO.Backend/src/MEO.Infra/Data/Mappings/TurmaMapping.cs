using MEO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MEO.Infra.Data.Mappings
{
    public class TurmaMapping : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.TipoTurnoId)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(c => c.QuantidadeAlunos)
                .IsRequired()
                .HasColumnType("int");

            builder.HasOne(c => c.Escola)
                .WithMany(c => c.Turmas);

            builder.ToTable("Turmas");
        }
    }
}
