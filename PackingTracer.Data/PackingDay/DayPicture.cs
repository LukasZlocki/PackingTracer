using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingTracer.Data.HourlyTarget
{
    public class DayPicture
    {
        DateTime WorkingDay { get; set; }
        List<int> PcsPackedPerHour { get; set; }
    }
}
