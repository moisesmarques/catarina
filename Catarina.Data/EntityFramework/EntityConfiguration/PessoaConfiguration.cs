using Catarina.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catarina.Data.EntityFramework.EntityConfiguration
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure( EntityTypeBuilder<Pessoa> builder )
        {
            builder.HasMany( a => a.Propriedades )
                .WithOne( a => a.Proprietario );

            builder.HasMany( a => a.Locacoes )
                .WithOne( a => a.Locador );
        }
    }
}
