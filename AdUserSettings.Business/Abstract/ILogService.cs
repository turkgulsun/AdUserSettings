using AdUserSettings.Business.DTOs;
using AdUserSettings.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdUserSettings.Business.Abstract
{
    public interface ILogService
    {
        void Add(LogDTO logDTO);
    }
}
