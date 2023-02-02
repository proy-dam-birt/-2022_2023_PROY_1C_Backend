using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.Domain.Entities.API
{
    public class Events
    {
        [Key]
        public long Id { get; set; }    // Primary key
        public long TotalItems { get; set; }
        public long TotalPages { get; set; }
        public long CurrentPage { get; set; }
        public EventoEuskadi[] Items { get; set; }
    }
}
