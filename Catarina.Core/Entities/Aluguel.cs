using System;
using System.Collections.Generic;
using System.Text;

namespace Catarina.Core.Entities
{
    public class Aluguel
    {
        public virtual Pessoa Locador { get; set; }
        public virtual Pessoa Locatario { get; set; }

    }
}
