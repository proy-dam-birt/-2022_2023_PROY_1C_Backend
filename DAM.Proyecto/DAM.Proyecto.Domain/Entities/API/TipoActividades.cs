using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.Domain.Entities.API
{
    public class TipoActividades
    {
        [Key]
        public long Id { get; set; }    // Primary key
        public string? nameEs { get; set; }
        public string? nameEu { get; set; }

    }
}
