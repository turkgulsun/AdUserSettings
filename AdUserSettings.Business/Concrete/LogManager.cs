using AdUserSettings.Business.Abstract;
using AdUserSettings.Business.DTOs;
using AdUserSettings.DataAccess.Abstract;
using AdUserSettings.Entities.Concrete;
using AdUserSettings.EntityFrameworkCore.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdUserSettings.Business.Concrete
{
    public class LogManager : ILogService
    {

        private readonly IEntityFrameworkCoreUnitOfWork _unitofwork;
        private readonly ILogRepository _logRepository;

        public LogManager(IEntityFrameworkCoreUnitOfWork unitofwork, ILogRepository logRepository)
        {
            _unitofwork = unitofwork;
            _logRepository = logRepository;
        }

        public void Add(LogDTO logDTO)
        {
            Logs logs = new Logs();
            logs.UserName = logDTO.UserName;
            logs.Type = logDTO.Type;
            logs.Message = logDTO.Message;
            logs.CreationDate = logDTO.CreationDate;
            logs.IPAddress = logDTO.IPAddress;

            _unitofwork.BeginTransaction();
            _logRepository.Create(logs);
            _unitofwork.SaveChanges();
            _unitofwork.Commit();
        }
    }
}
