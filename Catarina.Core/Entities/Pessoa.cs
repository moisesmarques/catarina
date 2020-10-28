using System;
using System.Collections.Generic;
using System.Text;

namespace Catarina.Core.Entities
{
    public class Pessoa : BaseEntity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int DiaNascimento { get; set; }
        public int MesNascimento { get; set; }
        public int AnoNascimento { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public virtual ICollection<Contato> Contatos { get; set; }
        public virtual ICollection<Imovel> Imoveis { get; set; }
    }
}
