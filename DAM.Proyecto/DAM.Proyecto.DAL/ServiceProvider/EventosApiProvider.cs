using AutoMapper;
using DAM.Proyecto.DAL.Interfaces.IServiceProvider;
using DAM.Proyecto.Domain.Entities.API;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.DAL.ServiceProvider
{
    public class EventosApiProvider : IEventosApiProvider
    {
        private static readonly NLog.ILogger _logger = LogManager.GetCurrentClassLogger();
        private IMapper _mapper;

        #region Ctor
        public EventosApiProvider(IMapper mapper)
        {
            _mapper = mapper;

        }
        #endregion

        #region Public methods
        public async Task<IEnumerable<EventoEuskadi>> GetEventosEusData()
        {
            string _urlSetting = "https://api.euskadi.eus/culture/events/v1.0/events";
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    string url = $"{_urlSetting}";

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string respText = await response.Content.ReadAsStringAsync();
                        var data = Newtonsoft.Json.JsonConvert.DeserializeObject<Events>(respText);
                        var result = data.Items;

                        return (result);
                    }
                    else
                        return (null);
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Unexpected error ex={ex.Demystify()}");
                throw;
            }
        }
        #endregion
    }
}
