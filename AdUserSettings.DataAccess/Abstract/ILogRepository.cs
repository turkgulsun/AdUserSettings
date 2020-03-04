using AdUserSettings.Entities.Concrete;
using AdUserSettings.EntityFrameworkCore.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdUserSettings.DataAccess.Abstract
{
    public interface ILogRepository:IEntityFrameworkCoreRepository<Logs>
    {
    }
}
