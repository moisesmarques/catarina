using Catarina.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catarina.Core.Entities
{
    public class Contato: BaseEntity
    {
        public virtual Pessoa Pessoa { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public virtual Logradouro Logradouro { get; set; }
        public EnumTipoContato Tipo { get; set; }
    }
}
