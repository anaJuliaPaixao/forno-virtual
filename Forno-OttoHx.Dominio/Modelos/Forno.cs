using System.ComponentModel.DataAnnotations;

namespace Forno_OttoHx.Dominio.Modelos
{
    public class Forno
    {
        [Key]
        public int Id { get; set; }
        public DateTime HoraInicio { get; set; }
        public int SegundosAquecimento { get; set; }
        public int Potencia { get; set; } 
    }
}
