using AutoMapper;
using DAM.Proyecto.DAL.Interfaces.IRepositories;
using DAM.Proyecto.DAL.Interfaces.IServiceProvider;
using DAM.Proyecto.Domain.Entities.DB;
using DAM.Proyecto.Domain.Entities.DTO;
using DAM.Proyecto.SL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.SL.Services
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository reservaRepository;
        private IUnitOfWork _uow;
        private IMapper _mapper;
        public ReservaService(IReservaRepository reservaRepository)
        {
            this.reservaRepository = reservaRepository;
        }

        public Task CreateReserve(ReservaDTO Reserva)
        {
            //Comprobar si hay plazas libres

            var temp = _uow.ReservaRepo.Find(x => x.PlazasReservadas == Reserva.PlazasReservadas);
            var t = temp.FirstOrDefault();
            var plazasReservadas = t.PlazasReservadas;
            var plazasLibres = 100; // es temporal sustituir por la otra tabla
            if (plazasLibres >= plazasReservadas)
            {
                //crear reserva
                _uow.ReservaRepo.Add(t);
                _uow.SaveChanges();

                //return Task.CompletedTask;
            }

            //Task newReserva = (Task)reservaRepository.Add(Reserva);
            
            throw new Exception("No hay suficientes plazas libres");
        }       
    }
}
