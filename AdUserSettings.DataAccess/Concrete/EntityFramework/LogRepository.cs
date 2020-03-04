using AdUserSettings.DataAccess.Abstract;
using AdUserSettings.Entities.Concrete;
using AdUserSettings.EntityFrameworkCore;
using AdUserSettings.EntityFrameworkCore.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdUserSettings.DataAccess.Concrete.EntityFramework
{
    public class LogRepository: EntityFrameworkCoreRepository<Logs>, ILogRepository
    {
        public LogRepository(IEntityFrameworkCoreContextFactory dbContextFactory):base(dbContextFactory)
        {

        }
    }
}
