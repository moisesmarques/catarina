using System;
using System.Collections.Generic;
using System.Text;

namespace Catarina.Core.Entities
{
    public class Logradouro: BaseLookup
    {
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public TipoLogradouro Tipo { get; set; }
        public virtual Estado Estado { get; set; }
    }
}
