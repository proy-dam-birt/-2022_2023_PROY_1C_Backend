using Quartz.Spi;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto
{
    /// <summary>
    /// Class: ScheduledJobFactory
    /// Herencia:  IJobFactory
    /// 
    /// Crea los trabajos con sus disparadores
    /// Libera los recursos cuando ya no son necesarios
    /// 
    /// <summary>
    /// <returns></returns>
    public class ScheduledJobFactory : IJobFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public ScheduledJobFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return _serviceProvider.GetRequiredService(bundle.JobDetail.JobType) as IJob;
        }

        public void ReturnJob(IJob job) => (job as IDisposable)?.Dispose();
    }
}
