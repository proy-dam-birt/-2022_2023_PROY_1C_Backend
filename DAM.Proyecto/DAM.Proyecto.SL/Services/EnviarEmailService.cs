using DAM.Proyecto.DAL.Interfaces.IRepositories;
using DAM.Proyecto.SL.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.SL.Services
{
    public class EnviarEmailService : IEnviarEmailService
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private IUnitOfWork _uow;

        #region Ctor
        public EnviarEmailService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        #endregion

        #region Public methods
        //TODO
        public async Task EnviarEmail()
        {

        }
        #endregion
    }
}

