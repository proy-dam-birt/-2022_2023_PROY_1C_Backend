using DAM.Proyecto.ScheduledJob.Interfaces;
using DAM.Proyecto.SL.Interfaces;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.ScheduledJob.Services
{
    /// <summary>
    /// Class: SyncGastroDataJob
    /// Herencia: ISyncGastroDataJob
    /// 
    /// 
    /// <summary>
    /// <returns></returns>
    public class SyncGastroDataJob : ISyncGastroDataJob
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly ISearchGastroEuskadiService _gEService;


        #region Ctor
        public SyncGastroDataJob(ISearchGastroEuskadiService gEService)
        {
            _gEService = gEService;
        }
        #endregion


        #region Public properties

        public static string JobName { get { return "SyncGastroDataJob"; } }

        #endregion


        #region Public methods
        /// <summary>
        /// Method: Task Execute
        /// Access: public
        /// 
        /// Lanza la peticion a la capa de servicio para que ejecute la
        /// tarea de descarga de datos de a API y su guardado en el sistema
        /// de persistencia que corresponda.
        /// 
        /// @param  
        /// @return 
        /// <summary>
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                _logger.Info($"Do SyncQuotesJob at time ={DateTimeOffset.Now}");
                await _gEService.GetApiGastroEuskadi();
            }
            catch (Exception ex)
            {
                _logger.Error($"Unexpected error ex={ex.Demystify()}");
                throw;
            }
        }
        #endregion


        #region Private methods
        #endregion
    }
}
