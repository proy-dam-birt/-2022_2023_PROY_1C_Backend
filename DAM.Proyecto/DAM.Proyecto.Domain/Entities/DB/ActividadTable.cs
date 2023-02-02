using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.Domain.Entities.DB
{
    public class ActividadTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public string TipoActividad { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        public void Update(ActividadTable src)
        {
            if (src == null)
                throw new ArgumentNullException("Source orderline is null");

            this.Name = Name;
            this.TipoActividad = TipoActividad;
            this.UpdatedDateTime = DateTime.Now;
        }
    }
}
