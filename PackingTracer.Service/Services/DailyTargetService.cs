﻿using PackingTracer.Data.HourlyTarget;
using PackingTracer.Data.PackingDay;
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
            DateTime day = Convert.ToDateTime("08/22/2022 09:50:00"); // <-- delete this to gather data on user date request
            DayPicture dayPicture = new DayPicture();
            WorkDaySheet workDaySheet = new WorkDaySheet(); 

            workDaySheet = db.GetQuantityOfPackedSmc2MotorsByWholeDay3Shifts(day);

            return dayPicture;
        }




    }
}
