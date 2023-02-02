using AutoMapper;
using DAM.Proyecto.DAL.Interfaces.IRepositories;
using DAM.Proyecto.DAL.Interfaces.IServiceProvider;
using DAM.Proyecto.Domain.Entities.DB;
using DAM.Proyecto.SL.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.SL.Services
{
    public class SearchEventosEuskadiService : ISearchEventosEuskadiService
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private IEventosApiProvider _eventosApi;
        private IUnitOfWork _uow;
        private IMapper _mapper;

        #region Ctor
        public SearchEventosEuskadiService(IEventosApiProvider eventosApi, IUnitOfWork uow, IMapper mapper)
        {
            _eventosApi = eventosApi;
            _uow = uow;
            _mapper = mapper;
        }

        #endregion


        #region Public methods
        public async Task GetApiEventosEuskadi()
        {

            try
            {
                _logger.Info("GetEventosEus started");

                var eventos = await _eventosApi.GetEventosEusData();
                if (eventos != null && eventos.Any())
                {
                    // Mapping of the APi Eventos Euskadi incoming data
                    var result = eventos.Select(x => _mapper.Map<EventoEuskadiTable>(x));

                    foreach (var evento in result)
                    {
                        var temp = _uow.EventosEuskadiRepo.Find(x => x.EventoEuskadiId == evento.EventoEuskadiId);

                        if (temp != null && temp.Any())
                        {
                            _logger.Info("{0} update", evento);
                            var t = temp.FirstOrDefault();
                            t.CompanyEs = evento.CompanyEs;
                            t.CompanyEu = evento.CompanyEu;
                            t.DescriptionEs = evento.DescriptionEs;
                            t.DescriptionEu = evento.DescriptionEu;
                            t.EndDate = evento.EndDate;
                            t.EstablishmentEu = evento.EstablishmentEu;
                            t.Language = evento.Language;
                            t.MunicipalityEs = evento.MunicipalityEs;
                            t.MunicipalityEu = evento.MunicipalityEu;
                            t.MunicipalityNoraCode = evento.MunicipalityNoraCode;
                            t.NameEs = evento.NameEs;
                            t.NameEu = evento.NameEu;
                            t.Online = evento.Online;
                            t.OpeningHours = evento.OpeningHours;
                            t.OpeningHoursEu = evento.OpeningHoursEu;
                            t.PlaceEs = evento.PlaceEs;
                            t.PlaceEu = evento.PlaceEu;
                            t.ProvinceNoraCode = evento.ProvinceNoraCode;
                            t.PublicationDate = evento.PublicationDate;
                            t.PurchaseUrlEs = evento.PurchaseUrlEs;
                            t.PurchaseUrlEu = evento.PurchaseUrlEu;
                            t.SourceNameEs = evento.SourceNameEs;
                            t.SourceNameEu = evento.SourceNameEu;
                            t.SourceUrlEu = evento.SourceUrlEu;
                            t.StartDate = evento.StartDate;
                            t.Type = evento.Type;
                            t.TypeEs = evento.TypeEs;
                            t.TypeEu = evento.TypeEu;
                            t.UrlEventEs = evento.UrlEventEs;
                            t.UrlEventEu = evento.UrlEventEu;
                            t.UrlNameEs = evento.UrlNameEs;
                            t.UrlNameEu = evento.UrlNameEu;
                            t.UrlOnline = evento.UrlOnline;
                            t.UrlOnlineEu = evento.UrlOnlineEu;
                            t.UpdatedDateTime = DateTime.Now;
                            _uow.EventosEuskadiRepo.Update(t);
                        }
                        else
                        {
                            _logger.Info("{0} create", evento);
                            _uow.EventosEuskadiRepo.Add(evento);
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
