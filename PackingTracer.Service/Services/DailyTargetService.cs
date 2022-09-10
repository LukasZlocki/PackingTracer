using PackingTracer.Data.HourlyTarget;
using PackingTracer.Data.PackingDay;
using PackingTracer.Service.DbEngine;

namespace PackingTracer.Service.Services
{
    public class DailyTargetService : IDailyTargetService
    {
        private readonly DbEng db = new DbEng();

        public DayPicture GetDayResult(DateTime data)
        {
            // DateTime day = Convert.ToDateTime("08/22/2022 09:50:00"); // <-- delete this to gather data on user date request
            DayPicture dayPicture = new DayPicture();
            WorkDaySheet workDaySheet = new WorkDaySheet(); 

            workDaySheet = db.GetQuantityOfPackedSmc2MotorsByWholeDay3Shifts(data);

            // calculating: *hourly output per proper hour / 3x shifts , data is store in dayPicture object
            HourlyOutput hourlyOutput = new HourlyOutput();
            for (int hour = 0; hour < 24; hour++)
            {
                int _hourlyCount = workDaySheet.Packed.Where(x => x.Hour == hour).Count();
                dayPicture.OutputPerHour.Add(new HourlyOutput { Hour = hour, Output = _hourlyCount });
            }
            return dayPicture;
        }




    }
}
