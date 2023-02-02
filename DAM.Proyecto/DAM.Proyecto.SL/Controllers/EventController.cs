using AutoMapper;
using DAM.Proyecto.DAL.Interfaces.IRepositories;
using DAM.Proyecto.Domain.Entities.DB;
using DAM.Proyecto.Domain.Entities.DTO;
using DAM.Proyecto.SL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.SL.Controllers
{
    [ApiController]
    [Route("[reserva]")]
    public class EventController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IReservaService reservaService;
        private IUnitOfWork _uow;

        public EventController(IMapper mapper, IReservaService reservaService)
        {
            this.mapper = mapper;
            this.reservaService = reservaService;
                
        }

        [HttpPost]
        public ReservaDTO CreateReserva(ReservaDTO reservaViewModel)
        {
            var mapped = mapper.Map<ReservaTable>(reservaViewModel);
            
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");
            
            var entityDTO = reservaService.CreateReserve(reservaViewModel);
            var mappedViewModel = mapper.Map<ReservaDTO>(entityDTO);
            
            return mappedViewModel;
        }
    }
    
}
