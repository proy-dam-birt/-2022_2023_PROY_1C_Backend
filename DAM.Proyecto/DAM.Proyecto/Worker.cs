using AutoMapper;
using DAM.Proyecto.Configuration.Model;
using DAM.Proyecto.DAL;
using DAM.Proyecto.DAL.Interfaces.IRepositories;
using DAM.Proyecto.DAL.Interfaces.IServiceProvider;
using DAM.Proyecto.DAL.Repositories;
using DAM.Proyecto.DAL.ServiceProvider;
using DAM.Proyecto.ScheduledJob.Interfaces;
using DAM.Proyecto.ScheduledJob.Services;
using DAM.Proyecto.SL.Automapping;
using DAM.Proyecto.SL.Interfaces;
using DAM.Proyecto.SL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using NLog;
using NLog.Fluent;
using Quartz;
using Quartz.Impl;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection.Metadata;
using System.Timers;
using static Quartz.MisfireInstruction;

namespace DAM.Proyecto
{
    /// <summary>
    /// Class: Worker
    /// Herencia: BackgroundService
    /// 
    /// Esta clase es una clase base que hereda de IHostredService,
    /// y sirve especialmente para realizar rutinas largas de implementacion de IHostedService
    /// 
    /// <summary>
    /// <returns></returns>

    public class Worker : BackgroundService
    {
        private static readonly NLog.ILogger _logger = LogManager.GetCurrentClassLogger();
        public Type IAutoMapper { get; private set; }
        private IScheduler _scheduler;
        private const string DEFAULT_GROUP = "DefaultGroup";
        private static System.Timers.Timer aTimer;
        Dictionary<string, string> jobsHash = new Dictionary<string, string>();


        #region Ctor
        public Worker()
        {

        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Method: ExecuteAsyn()
        /// Access: protected
        /// 
        /// Lanza la Ejecucion de los trabajos programados
        /// 
        /// @param  CancellationToken stoppingToken
        /// @return 
        /// <summary>
        /// <returns></returns> 
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                _logger.Info("Worker started at: {time}", DateTimeOffset.Now);

                StartJobs();

                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.Info("Worker running at: {time}", DateTimeOffset.Now);
                    await Task.Delay(1000, stoppingToken);
                }

                _logger.Info("Worker stopped at: {time}", DateTimeOffset.Now);

                await _scheduler.Shutdown();

                _logger.Info("Worker scheduler stopped at: {time}", DateTimeOffset.Now);
            }
            catch (Exception ex)
            {
                _logger.Error($"Unexpected error ex={ex.Demystify()}");
            }
        }


        /// <summary>
        /// Method: Task StartAsync
        /// Access: public
        /// 
        ///  Lanza las tareas
        /// 
        /// @param 
        /// @return 
        /// <summary>
        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            await base.StartAsync(cancellationToken);

            _logger.Info("Service Started !");
        }

        /// <summary>
        /// Method: Task StopAsync
        /// Access: public
        /// 
        /// Detiene las tareas
        /// 
        /// @param 
        /// @return 
        /// <summary>
        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await base.StopAsync(cancellationToken);

            _logger.Info("Service Stopped !");
        }

        #endregion

        #region Private methods
        /// <summary>
        /// Method: StartJobs()
        /// Access: private
        /// 
        /// Lanza lostrabajos seteados
        /// 
        /// @param  
        /// @return 
        /// <summary>
        private async void StartJobs()
        {
            try
            {
                var serviceProvider = GetConfiguredServiceProvider();

                ISchedulerFactory schedFact = new StdSchedulerFactory();
                _scheduler = await schedFact.GetScheduler();
                _scheduler.JobFactory = new ScheduledJobFactory(serviceProvider);
                await _scheduler.Start();


                // Seteo provisional de trabajos
                var set1 = new JobSettings("SyncEventosDataJob", null, 60000, true);
                await ScheduleSyncEventosDataJob(set1);

                var set2 = new JobSettings("SyncGastroDataJob", null, 60000, true);
                await ScheduleSyncGastroDataJob(set2);

                _logger.Info("OrderService service - all jobs started.....");
            }
            catch (Exception ex)
            {
                _logger.Error($"Unexpected error during starting scheduled jobs ex={ex.Demystify()}");
            }

        }

        /// <summary>
        /// Method: ScheduleSyncEventosDataJob
        /// Access: private
        /// 
        /// Crea la tarea programada para descargar los datos de la API Eventos
        /// 
        /// @param  JobSettings settings
        /// @return 
        /// <summary>
        private async Task ScheduleSyncEventosDataJob(JobSettings settings)
        {

            JobSettings js = settings;
            if (js == null)
                throw new ArgumentNullException("Config.xml does not containg job configuration for SyncEventosDataJob  job ");

            if (js.Enabled)
            {
                IJobDetail job = JobBuilder.Create<ISyncEventosDataJob>()
                                .WithIdentity(SyncEventosDataJob.JobName)
                                .Build();

                await _scheduler.ScheduleJob(job, GetTrigger(js));

                _logger.Info("SyncEventosDataJob job scheduled");
            }
            else
            {
                _logger.Info("SyncEventosDataJob job was not enabled");
            }
        }

        /// <summary>
        /// Method: ScheduleSyncGastroDataJob
        /// Access: private
        /// 
        /// Crea la tarea programada para descargar los datos de servicios gatronomicos de Euskadi
        /// 
        /// @param  JobSettings settings
        /// @return 
        /// <summary>
        private async Task ScheduleSyncGastroDataJob(JobSettings settings)
        {

            JobSettings js = settings;
            if (js == null)
                throw new ArgumentNullException("Config.xml does not containg job configuration for SyncGastroDataJob  job ");

            if (js.Enabled)
            {
                IJobDetail job = JobBuilder.Create<ISyncGastroDataJob>()
                                .WithIdentity(SyncGastroDataJob.JobName)
                                .Build();

                await _scheduler.ScheduleJob(job, GetTrigger(js));

                _logger.Info("SyncGastroDataJob job scheduled");
            }
            else
            {
                _logger.Info("SyncGastroDataJob job was not enabled");
            }
        }

        /// <summary>
        /// Method: GetTrigger
        /// Access: private
        /// 
        /// Metodo que define el disparador para el trabajo pasado por parametro.
        /// El periodo puede ser definido de x segundos <=> SimpleTrigger
        /// El disparador se define para un momento determinado <=> OnTimeTrigger
        /// 
        /// 
        /// @param  JobSettings setting
        /// @return ITrigger
        /// <summary>
        private ITrigger GetTrigger(JobSettings setting)
        {
            ITrigger trigger;
            if (setting.SimpleTriggerTime != null)
            {
                trigger = CreateSimpleTrigger((int)setting.SimpleTriggerTime.Value, setting.Name);
            }
            else if (setting.TriggerTimeValue != null && setting.TriggerTimeValue.Hour.HasValue && setting.TriggerTimeValue.Minute.HasValue)
            {
                trigger = CreateOnTimeTrigger((int)setting.TriggerTimeValue.Hour.Value, (int)setting.TriggerTimeValue.Minute.Value, setting.Name);
            }
            else
                throw new ArgumentException("Wrong job configuration");

            return (trigger);
        }


        /// <summary>
        /// Method: CreateSimpleTrigger
        /// Access: private
        /// 
        /// Crea y devuelve un Trigger definido en segundos
        /// 
        /// @param  int period, string name, string group = DEFAULT_GROUP
        /// @return  ITrigger 
        /// <summary>
        private ITrigger CreateSimpleTrigger(int period, string name, string group = DEFAULT_GROUP)
        {
            ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity(name, group)
            .StartNow()
            .WithSimpleSchedule(x => x
                .WithIntervalInSeconds(period)
                .RepeatForever())
            .Build();

            return trigger;
        }

        
        /// <summary>
        /// Method: CreateOnTimeTrigge
        /// Access: private
        /// 
        /// Crea y devuelve un Trigger definido por hora y minuto
        /// 
        /// @param  int hour, int minute, string name, string group = DEFAULT_GROUP
        /// @return ITrigger 
        /// <summary>
        private ITrigger CreateOnTimeTrigger(int hour, int minute, string name, string group = DEFAULT_GROUP)
        {
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity(name, group)
                .WithCalendarIntervalSchedule()
                .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(hour, minute))
                .Build();
            return trigger;
        }


        /// <summary>
        /// Method: GetConfiguredServiceProvider()
        /// Access: private
        /// 
        /// Contenedor IoCC: Contendor  de Inversion de Control.
        /// Es el componente que se encarga de instanciacion de los objetos, teniendo en cuenta el ciclo de vida de estos.
        ///
        /// Suministra las instancias que se necesitan en la aplicacion, de esta manera, evitamos los "new" cada vez que necesitamos una instancia de alguna clase,
        /// pero teniendo en cuenta que en algunos casos haremos uso de los new.
        /// Los contenedores se apoyan en dos conceptos:
        ///				- Inyeccion de Dependencia(DI) :
        /// 			- Inversion de Control(IoC) :
        ///  Es por ello que debemos indicar como sera el ciclo de vida de nuestro objeto, y lo hacemos con los terminos:
        ///	(https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
        ///     Singleton: Solo habra un objeto de ese tipo al que se puede acceder desde cualquier otro codigo. (se puede asimilar a una variable global), p.E.La configuracion del programa
        ///      Scopped:  En el caso de las aplicaciones web, una duración con ámbito indica que los servicios se crean una vez por solicitud de cliente(conexión). 
        /// 				  En las aplicaciones que procesan solicitudes, los servicios con ámbito se eliminan al final de la solicitud.
        ///		Trasient: Los servicios de duracion transitoria crean cada vez que el contenedor del servicio lo solicita
        /// En las aplicaciones que procesan solicitudes, los servicios transitorios se eliminan al final de la solicitud.
        ///
        /// IServiceProvider proporciona el contenedor de servicios integrado.Una vez que se agregan todos los servicios,
        /// se usa BuildServicePRovider para crear el contenedor de Servicios
        /// 
        /// @param  
        /// @return IServiceProvider
        /// <summary>
        private IServiceProvider GetConfiguredServiceProvider()
        {
            //TODO Configurar base de datos


            var services = new ServiceCollection()

                // Para usar la base de datos real
                //.AddDbContext<DamDbContext>(options => options.UseSqlServer(@"Pruebas"))

                // Configurar la base de datos de prueba en local usando In-Memory
                .AddDbContext<DamDbContext>(options => options.UseInMemoryDatabase("InMemoryConnection"))

                // DAM.Proyecto
                .AddScoped<ISyncEventosDataJob, SyncEventosDataJob>()
                .AddScoped<ISyncGastroDataJob, SyncGastroDataJob>()

                // DAM.Proyecto.DAL
                .AddScoped<IEventosApiProvider, EventosApiProvider>()
                .AddScoped<INotificacionProvider, NotificationProvider>()
                .AddScoped<IGastronomiaApiProvider, GastronomiaApiProvider>()

                // DAM.Proyecto.SL
                .AddScoped<ISearchEventosEuskadiService, SearchEventosEuskadiService>()
                .AddScoped<ISearchGastroEuskadiService, SearchGastroEuskadiService>()
                .AddScoped<IEnviarEmailService, EnviarEmailService>()
                .AddScoped<IUserService, UserService>()

                .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddTransient<IUnitOfWork, UnitOfWork>()
                .AddTransient<DamDbContext>()


                // Agrega el servicio de terceros, NLog, que se utiliza en casi todas las clases y es una 
                // herramienta de registro de codigo de seguimiento (Open-Source), muestra advertencias y errores
                .AddLogging();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            // crea el contenedor de servicios
            return services.BuildServiceProvider();
        }

       
        /// <summary>
        /// Method: SetTimer
        /// Access: private
        /// 
        /// Timer para lanzar el  watcher de deteccion de cambios
        /// 
        /// @param  
        /// @return 
        /// <summary>
        private void SetTimer()
        {
            aTimer = new System.Timers.Timer
            {
                Interval = 60000
            };
            aTimer.Elapsed += DbWatcher;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }


        /// <summary>
        /// Method: DbWatcher
        /// Access: 
        /// 
        /// Wather de cambios en la configuracion de los triggers de trabajos,
        /// Si detecta cambios, carga la cong
        /// figuracion de los triggers
        /// 
        /// @param  
        /// @return 
        /// <summary>
        private void DbWatcher(Object source, ElapsedEventArgs e)
        {
            ITrigger trigger;
            TriggerTime triggerTime;
            int simpleTriggerTime;
            try
            {/*
                _logger.Info($"DbWatcher - Reading DbHash at {e.SignalTime}");
                // Get IDictionary of JobName,DbHash

                var dbHash = new Dictionary<string, string>();
                dbHash.Clear();

                //dbHash = new SearchTriggerConfiguration(_configLoader).GetJobHashs();

                // jobHash first charge
                if (jobsHash.Count() <= 0)
                {
                    jobsHash = dbHash;
                    return;
                }

                // Comparison
                foreach (var job in jobsHash)
                {
                    var internalHash = job.Value;
                    string dbHashValue = dbHash[job.Key];

                    if (internalHash != dbHashValue)
                    {
                        _logger.Info($"DB hash changed - Rescheduling {job.Key} job");

                        //change hashvalue in internal dictionary to value from DB
                        jobsHash[job.Value] = dbHash[job.Value];

                        // Get Values from DB
                        //var sett = new SearchTriggerConfiguration(_configLoader).GetJobTrigger();

                        foreach (var item in sett)
                        {
                            _logger.Info($"--------------Rescheduling {item} job-------------");


                            if (item.SimpleTriggerTime != null)
                            {
                                _logger.Info($"New SimpleTriggerTime {item} job: {item.SimpleTriggerTime.Value}");
                                trigger = CreateSimpleTrigger((int)item.SimpleTriggerTime, item.Name);
                                _scheduler.RescheduleJob(new TriggerKey(job.Key, DEFAULT_GROUP), trigger);
                            }
                            else if (item.TriggerTimeValue != null)
                            {
                                _logger.Info($"New trigger {item} job: {item.TriggerTimeValue.Hour}:{item.TriggerTimeValue.Minute}");
                                trigger = CreateOnTimeTrigger((int)item.TriggerTimeValue.Hour, (int)item.TriggerTimeValue.Minute, item.Name);
                                _scheduler.RescheduleJob(new TriggerKey(job.Key, DEFAULT_GROUP), trigger);
                            }

                            _logger.Info($"--------------Rescheduling {item} job DONE-------------");
                            return;
                        }
                    }

                } */
            }
            catch (Exception ex)
            {
            }
        }
        #endregion
    }
}