using AutoMapper;
using DAM.Proyecto.DAL.Interfaces.IRepositories;
using DAM.Proyecto.DAL.Interfaces.IServiceProvider;
using DAM.Proyecto.DAL.ServiceProvider;
using DAM.Proyecto.Domain.Entities.DB;
using DAM.Proyecto.SL.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.SL.Services
{
    public class SearchGastroEuskadiService : ISearchGastroEuskadiService
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private IGastronomiaApiProvider _gastroApi;
        private IUnitOfWork _uow;
        private IMapper _mapper;

        #region Ctor
        public SearchGastroEuskadiService(IGastronomiaApiProvider gastroApi, IUnitOfWork uow, IMapper mapper)
        {
            _gastroApi = gastroApi;
            _uow = uow;
            _mapper = mapper;
        }

        #endregion


        #region Public methods
        public async Task GetApiGastroEuskadi()
        {

            try
            {
                _logger.Info("GetEventosEus started");

                var gastro = await _gastroApi.GetGastroEusData();
                if (gastro != null && gastro.Any())
                {
                    // Mapping of the APi Eventos Euskadi incoming data
                    var result = gastro.Select(x => _mapper.Map<GastronomiaEuskadiTable>(x));

                    foreach (var g in result)
                    {
                        var temp = _uow.GastronomiaEuskadiRepo.Find(x => x.Id == g.Id);

                        if (temp != null && temp.Any())
                        {
                            _logger.Info("{0} update", g);
                            var t = temp.FirstOrDefault();
                            t.DocumentName = g.DocumentName;
                            t.DocumentDescription = g.DocumentDescription;
                            t.TemplateType = g.TemplateType;
                            t.Locality = g.Locality;
                            t.QualityQ = g.QualityQ;
                            t.QualityIconDescription = g.QualityIconDescription;
                            t.Phone = g.Phone;
                            t.Address = g.Address;
                            t.Marks = g.Marks;
                            t.Physical = g.Physical;
                            t.Visual = g.Visual;
                            t.Auditive = g.Auditive;
                            t.Intellectual = g.Intellectual;
                            t.Organic = g.Organic;
                            t.QualityAssurance = g.QualityAssurance;
                            t.TourismEmail = g.TourismEmail;
                            t.Web = g.Web;
                            t.Room = g.Room;
                            t.ProductClub = g.ProductClub;
                            t.Visit = g.Visit;
                            t.Capacity = g.Capacity;
                            t.Store = g.Store;
                            t.PostalCode = g.PostalCode;
                            t.RestorationType = g.RestorationType;
                            t.Recomended = g.Recomended;
                            t.RecomendedURLIcon = g.RecomendedURLIcon;
                            t.RecomendedIconDescription = g.RecomendedIconDescription;
                            t.Restaurant = g.Restaurant;
                            t.MichelinStar = g.MichelinStar;
                            t.RepsolSun = g.RepsolSun;
                            t.Latitudelongitude = g.Latitudelongitude;
                            t.Latwgs84 = g.Latwgs84;
                            t.Lonwgs84 = g.Lonwgs84;
                            t.Municipality = g.Municipality;
                            t.Municipalitycode = g.Municipalitycode;
                            t.Territory = g.Territory;
                            t.Territorycode = g.Territorycode;
                            t.Country = g.Country;
                            t.Countrycode = g.Countrycode;
                            t.FriendlyUrl = g.FriendlyUrl;
                            t.PhysicalUrl = g.PhysicalUrl;
                            t.DataXML = g.DataXML;
                            t.MetadataXML = g.MetadataXML;
                            t.ZipFile = g.ZipFile;
                            t.UpdatedDateTime = DateTime.Now;
                            _uow.GastronomiaEuskadiRepo.Update(t);
                        }
                        else
                        {
                            _logger.Info($"{g} create");
                            _uow.GastronomiaEuskadiRepo.Add(g);
                        }
                    }
                    await _uow.SaveChanges();
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
