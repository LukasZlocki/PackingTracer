using PackingTracer.Data.HourlyTarget;

namespace PackingTracer.Service.Services
{
    internal interface IDailyTargetService
    {
        public DayPicture GetDayResult(DateTime data);
    }
}
