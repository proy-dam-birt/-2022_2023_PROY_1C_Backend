using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.Domain.Entities.DTO
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }  
        public string Apellido_1 { get; set; }
        public string? Apellido_2 { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public bool consumidor { get; set; }
        public bool servuctor { get; set; }
        public string email { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UltimaModificacion { get; set; }
    }
}
