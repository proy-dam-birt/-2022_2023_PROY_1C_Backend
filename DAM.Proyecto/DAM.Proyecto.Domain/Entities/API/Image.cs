using DAM.Proyecto.Domain.Entities.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.Domain.Entities.API
{
    public class Image
    {
        [Key]
        public long Id { get; set; }    
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }

        [ForeignKey("EventoEuskadi")]
        public long EventoEuskadiId {get; set; }  
        public EventoEuskadi EventoEuskadi { get; set; } //
        
    }
}
