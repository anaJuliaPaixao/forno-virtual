using Forno_OttoHx.Dominio.Modelos.Enums;

namespace Forno_OttoHx.DTO
{
    public class FornoModeloEntrada
    {
        public int SegundosAquecimento { get; set; }
        public int Potencia { get; set; }
        public TipoAquecimento TipoAquecimento { get; set; }
        public string AquecimentoPersonalizado { get; set; }

    }
}
