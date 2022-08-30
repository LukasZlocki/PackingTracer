using PackingTracer.Data.HourlyTarget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingTracer.Service.Services
{
    internal interface IDailyTargetService
    {
        public DayPicture GetDayResult();
    }
}
