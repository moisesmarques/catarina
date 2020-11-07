using System;
using System.Collections.Generic;
using System.Text;

namespace Catarina.Core.Entities
{
    public class ImovelImagem
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Tamanho { get; set; }
        public int Largura { get; set; }
        public int Altura { get; set; }
        public string Descricao { get; set; }
        public string DescricaoLonga { get; set; }
        public string Conteudo { get; set; }
        public virtual Imovel Imovel { get; set; }
    }
}
