using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.SL.Interfaces
{
    /// <summary>
    /// Interface: 
    /// Herencia: 
    /// 
    /// Define la tarea de obtener los datos de la API 
    /// Se implementara en el servicio correspondiente
    /// 
    /// <summary>
    /// <returns></returns>
    public interface ISearchGastroEuskadiService
    {
        Task GetApiGastroEuskadi();
    }
}
