using AutoMapper;
using DAM.Proyecto.DAL.Interfaces.IServiceProvider;
using DAM.Proyecto.Domain.Entities.API;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.DAL.ServiceProvider
{
    public class GastronomiaApiProvider : IGastronomiaApiProvider
    {
        private static readonly NLog.ILogger _logger = LogManager.GetCurrentClassLogger();
        private IMapper _mapper;

        #region Ctor
        public GastronomiaApiProvider(IMapper mapper)
        {
            _mapper = mapper;

        }
        #endregion

        #region Public methods
        public async Task<IEnumerable<GastronomiaEuskadi>> GetGastroEusData()
        {
            string _urlSetting = "https://www.opendata.euskadi.eus/contenidos/ds_recursos_turisticos/restaurantes_sidrerias_bodegas/opendata/restaurantes.json";
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    string url = $"{_urlSetting}";

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string respText = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<IEnumerable<GastronomiaEuskadi>>(respText);

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
