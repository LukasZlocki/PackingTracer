using PackingTracer.Data.PackingDay;

namespace PackingTracer.Data.HourlyTarget
{
    public class DayPicture
    {
        public DateTime WorkingDay { get; set; }
        public List<HourlyOutput> OutputPerHour { get; set; }

        public DayPicture()
        {
            OutputPerHour = new List<HourlyOutput>();
        }

    }
}
