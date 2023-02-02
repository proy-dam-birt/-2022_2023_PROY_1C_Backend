using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.Domain.Entities.DB
{
    public class TipoActividadTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string? NameEs { get; set; }
        public string? NameEu { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        public void Update(TipoActividadTable src)
        {
            if (src == null)
                throw new ArgumentNullException("Source orderline is null");

            Id = Id;
            NameEs = NameEs;
            NameEu = NameEu;
            UpdatedDateTime = DateTime.Now;
        }
    }
}
