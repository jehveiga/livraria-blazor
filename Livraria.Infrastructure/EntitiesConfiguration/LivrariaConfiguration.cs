using Livraria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livraria.Infrastructure.EntitiesConfiguration
{
    internal class LivrariaConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Titulo).HasMaxLength(150).IsRequired();
            builder.Property(l => l.Autor).HasMaxLength(200).IsRequired();
            builder.Property(l => l.Lancamento).IsRequired();
            builder.Property(l => l.Capa).HasMaxLength(200);
        }
    }
}
