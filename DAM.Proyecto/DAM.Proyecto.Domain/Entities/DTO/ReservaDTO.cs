using DAM.Proyecto.Domain.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.Domain.Entities.DTO
{
    public class ReservaDTO
    {
        public int ReservaId { get; set; }
        public UserTable UserTable { get; set; }
        public FechasEventosTable FechasEventosTable { get; set; }
        public int PlazasReservadas { get; set; }
    }
}
