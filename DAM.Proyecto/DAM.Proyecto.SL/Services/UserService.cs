using AutoMapper;
using DAM.Proyecto.DAL.Interfaces.IRepositories;
using DAM.Proyecto.Domain.Entities.DB;
using DAM.Proyecto.Domain.Entities.DTO;
using DAM.Proyecto.SL.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.SL.Services
{
    public class UserService : IUserService
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private IUnitOfWork _uow;
        private IMapper _mapper;

        #region Ctor
        public UserService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        #endregion

        #region Public Methods
 
        // Agrega el user si no existe
        public async Task Add(UserDTO user)
        {
            await NoExiste(user);
            var itemT = _mapper.Map<UserTable>(user);
            _uow.UserRepo.Add(itemT);
            _uow.SaveChanges();
        }


        // Elimina el user si existe
        public async Task Remove(UserDTO user)
        {
            await Existe(user);
            var itemT = _mapper.Map<UserTable>(user);
            _uow.UserRepo.Remove(itemT);
            _uow.SaveChanges();
        }

        // Actualiza el user si existe
        public async Task Update(UserDTO user)
        {
            //await Existe(user);
            var itemT = _mapper.Map<UserTable>(user);
            _uow.UserRepo.Update(itemT);
            _uow.SaveChanges();
        }
        #endregion

        #region Private Methods
        private async Task NoExiste(UserDTO user)
        {
            var temp = _uow.UserRepo.Find(x => x.Id == user.Id);
            if (temp != null && temp.Any()) throw new ApplicationException($"{user.Username.ToString()} ya existe");
        }
        private async Task Existe(UserDTO user)
        {
            var temp = _uow.UserRepo.Find(x => x.Id == user.Id);
            if (temp == null) throw new ApplicationException($"{user.Username.ToString()} no existe");
        }
        #endregion
    }
}
