using DAM.Proyecto.Domain.Entities.DB;
using DAM.Proyecto.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.SL.Interfaces
{
    public interface IUserService
    {  
        Task Add(UserDTO user);
        Task Update(UserDTO user);
        Task Remove(UserDTO user);
    } 
   
}
