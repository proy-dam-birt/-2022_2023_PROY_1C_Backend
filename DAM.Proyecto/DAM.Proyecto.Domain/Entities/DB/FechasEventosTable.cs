using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAM.Proyecto.Domain.Entities.API;
using System.Xml.Linq;

namespace DAM.Proyecto.Domain.Entities.DB
{
    public class FechasEventosTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FechaEventosID { get; set; }
        [Required]
        public DateTime FechaEvento { get; set; }
        [Required]
        public int PlazasLibres { get; set; }

        [ForeignKey("EventId")]
        public MaestroEventosTable MaestroEventosTable { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }


    }
}
