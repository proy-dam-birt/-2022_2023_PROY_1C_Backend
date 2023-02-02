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
    public class SyncEventosDataJob : ISyncEventosDataJob
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly ISearchEventosEuskadiService _eEService;


        #region Ctor
        public SyncEventosDataJob(ISearchEventosEuskadiService eEService)
        {
            _eEService = eEService;
        }
        #endregion


        #region Public properties

        public static string JobName { get { return "SyncEventosDataJob"; } }

        #endregion


        #region Public methods
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                _logger.Info($"Do SyncQuotesJob at time ={DateTimeOffset.Now}");
                await _eEService.GetApiEventosEuskadi();

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

