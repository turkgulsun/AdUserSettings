using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdUserSettings.EntityFrameworkCore.Abstractions
{
    public interface IEntityFrameworkCoreContextFactory
    {
        DbContext GetDbContext();
    }
}
