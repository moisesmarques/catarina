using System;
using System.Collections.Generic;
using System.Text;

namespace Catarina.Core.Entities
{
    public class Imovel
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal ValorAluguel { get; set; }
        public virtual Pessoa Proprietario { get; set; }
        public virtual Pessoa Locador { get; set; }
        public virtual Logradouro Logradouro { get; set; }
        public int Dormitorios { get; set; }
        public int Camas { get; set; }
        public bool LavadouraRoupa { get; set; }
        public bool SecadouraRoupa { get; set; }
        public bool LavadouraLouca { get; set; }
        public bool Geladeira { get; set; }
        public bool Televisao { get; set; }
        public bool Fogao { get; set; }
        public bool Forno { get; set; }
        public bool Microondas { get; set; }
        public bool Elevador { get; set; }
        public bool AceitaCrianca { get; set; }
        public bool AceitaAnimal { get; set; }
        public int Garagens { get; set; }
        public int Lotacao { get; set; }
        public int Piso { get; set; }
        public bool AguaIncluida { get; set; }
        public bool EletricidadeIncluida { get; set; }
        public decimal MediaAgua { get; set; }
        public decimal MediaEletricidade { get; set; }
        public DateTime DisponivelEm { get; set; }
        public bool Academia { get; set; }
        public bool PiscinaCondominio { get; set; }
        public bool Piscina { get; set; }
        public bool Playground { get; set; }
        public bool QuadraEsportiva { get; set; }
        public bool Sauna { get; set; }
        public bool SalaoFesta { get; set; }
        public bool SalaConferencia { get; set; }
        public bool ChurrasqueiraCondominio { get; set; }
        public bool Churrasqueira { get; set; }
        public bool Sacada { get; set; }
        public bool Cobertura { get; set; }
        public bool Portaria24 { get; set; }
        public bool AlarmeIncendio { get; set; }
        public bool SensorFumaca { get; set; }
        public bool ChuveiroGas { get; set; }
        public bool TorneirasAquecidas { get; set; }
        public bool Internet { get; set; }
        public bool Wifi { get; set; }
        public int Metros { get; set; }
        public int Banheiros { get; set; }
        public bool EspacoGourmet { get; set; }
        public bool BanheiraHidromassagem { get; set; }
    }
}
