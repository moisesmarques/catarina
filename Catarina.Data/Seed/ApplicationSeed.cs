using Catarina.Core.Entities;
using Catarina.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catarina.Data.Seed
{
    public static class ApplicationSeed
    {
        public static void Seed( ModelBuilder modelBuilder )
        {
           modelBuilder.Entity<TipoLogradouro>().HasData(
                new TipoLogradouro { Id = (int)EnumTipoLogradouro.Acesso, Descricao = "Acesso" },
                new TipoLogradouro { Id = (int)EnumTipoLogradouro.Alameda, Descricao = "Alameda" },
                new TipoLogradouro { Id = (int)EnumTipoLogradouro.Avenida, Descricao = "Avenida" },
                new TipoLogradouro { Id = (int)EnumTipoLogradouro.Beco, Descricao = "Beco" },
                new TipoLogradouro { Id = (int)EnumTipoLogradouro.Bosque, Descricao = "Bosque" },
                new TipoLogradouro { Id = (int)EnumTipoLogradouro.Condominio, Descricao = "Condomínio" },
                new TipoLogradouro { Id = (int)EnumTipoLogradouro.Conjunto, Descricao = "Conjunto" },
                new TipoLogradouro { Id = (int)EnumTipoLogradouro.Estrada, Descricao = "Estrada" },
                new TipoLogradouro { Id = (int)EnumTipoLogradouro.Jardim, Descricao = "Jardim" },
                new TipoLogradouro { Id = (int)EnumTipoLogradouro.Largo, Descricao = "Largo" },
                new TipoLogradouro { Id = (int)EnumTipoLogradouro.Loteamento, Descricao = "Loteamento" },
                new TipoLogradouro { Id = (int)EnumTipoLogradouro.Parque, Descricao = "Parque" },
                new TipoLogradouro { Id = (int)EnumTipoLogradouro.Passagem, Descricao = "Passagem" },
                new TipoLogradouro { Id = (int)EnumTipoLogradouro.Passeio, Descricao = "Passeio" },
                new TipoLogradouro { Id = (int)EnumTipoLogradouro.Praca, Descricao = "Praça" },
                new TipoLogradouro { Id = (int)EnumTipoLogradouro.Praia, Descricao = "Praia" },
                new TipoLogradouro { Id = (int)EnumTipoLogradouro.Recanto, Descricao = "Recanto" },
                new TipoLogradouro { Id = (int)EnumTipoLogradouro.Rodovia, Descricao = "Rodovia" },
                new TipoLogradouro { Id = (int)EnumTipoLogradouro.Rua, Descricao = "Rua" },
                new TipoLogradouro { Id = (int)EnumTipoLogradouro.Servidao, Descricao = "Servidão" },
                new TipoLogradouro { Id = (int)EnumTipoLogradouro.Travessa, Descricao = "Travessa" },
                new TipoLogradouro { Id = (int)EnumTipoLogradouro.Trevo, Descricao = "Trevo" },
                new TipoLogradouro { Id = (int)EnumTipoLogradouro.Via, Descricao = "Via" },
                new TipoLogradouro { Id = (int)EnumTipoLogradouro.ViaExpressa, Descricao = "Via Expressa" },
                new TipoLogradouro { Id = (int)EnumTipoLogradouro.Vila, Descricao = "Vila" }
                );
        }
    }
}
