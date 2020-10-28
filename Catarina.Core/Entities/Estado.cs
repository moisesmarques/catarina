using System;
using System.Collections.Generic;
using System.Text;

namespace Catarina.Core.Entities
{
    public class Estado: BaseLookup
    {
        public string UF { get; set; }
        public string CEP { get; set; }
        public string CEP2 { get; set; }
        public virtual ICollection<Logradouro> Logradouros { get; set; }
    }
}
