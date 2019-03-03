using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenParcialTotal.Models.Entities
{
    public class Solicitudes
    {

        [Key]
        public int SolicitudID {get;set;}
       

        [Display(Name = "Motivo")]
        public String Motivo { get; set; }


      public virtual ICollection<DetalleSolicitudes> DetalleSolicitude { get; set; }

}
}
