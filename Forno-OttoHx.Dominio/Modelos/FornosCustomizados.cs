using Forno_OttoHx.Dominio.Modelos.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forno_OttoHx.Dominio.Modelos
{
    public class FornosCustomizados
    {
        [Key]
        public int Id { get; set; }
        public string NomeAlimento { get; set; }
        public int Potencia { get; set; }
        public string Abreviacao { get; set; }
        public int SegundosAquecimento { get; set; }

     
    }
}
