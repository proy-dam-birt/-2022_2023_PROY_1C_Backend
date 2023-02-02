using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.Domain.Entities.DTO
{
    public class QueryEventoDetalle
    {
        public long Id { get; set; }
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Precio { get; set; }
    }
}
