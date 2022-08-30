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
        private readonly DbEng db = new DbEng();

        public DayPicture GetDayResult()
        {
            DayPicture dayPicture = new DayPicture();

            var dailyPacked = db.GetQuantityOfPackedSmc2MotorsByWholeDay();


            return dayPicture;
        }
    }
}
