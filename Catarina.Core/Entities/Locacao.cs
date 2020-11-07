using System;
using System.Collections.Generic;
using System.Text;

namespace Catarina.Core.Entities
{
    public class Locacao

    {
        public virtual Pessoa Locador { get; set; }
        public virtual Pessoa Locatario { get; set; }
        public virtual Imovel Imovel { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }

    }
}
