using PackingTracer.Data.HourlyTarget;
using PackingTracer.Service.DbEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingTracer.Service.Services
{
    public class DailyTargetService : IDailyTargetService
    {
        private readonly dbEngine dbEngine = new dbEngine();

        

        public DayPicture GetDayResult(DateTime day)
        {
            var result = dbEngine.GetQuantityOfPackedSmc2MotorsByDay(day);
            return result;
        }
    }
}
