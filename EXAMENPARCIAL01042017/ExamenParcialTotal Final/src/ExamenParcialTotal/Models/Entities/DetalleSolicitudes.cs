using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenParcialTotal.Models.Entities
{
    public class DetalleSolicitudes
    {
        [Key]
        public int DetalleSolicitudID { get; set; }
        [Display(Name = "Solicitante")]
        public string NombreSolicitante { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime FechaViaje { get; set; }
        [Display(Name = "Motivo de Viaje")]
        public string MotivoViaje { get; set; }
        [Display(Name = "Descripciòn de viaje")]
        public string Descripcion { get; set; }
        [Display(Name = "Duraciòn (en dias)")]
        public int Duracion { get; set; }
        [Display(Name = "Monto a gastar (Alimentaciòn)")]
        public Decimal MontoGastar { get; set; }
        [Display(Name = "Gastos por Movilidad")]
        public Decimal GastoMovilidad { get; set; }

        [Display(Name = "Gastos por hotel")]
        public Decimal GastoHotel { get; set; }

        [Display(Name = "Sustento de aprobaciòn o rechazo")]
        public String SustentoAprobacion { get; set; }

        public int estado { get; set; }
        public int? SolicitudID { get; set; }

        public virtual Solicitudes Solicitudes { get; set; }
    }
}
