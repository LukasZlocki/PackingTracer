namespace PackingTracer.Data.PackingDay
{
    public class PackedPerDay
    {
        public DateTime Day { get; set; }
        public List<PackedUnit>? PackedUnits { get; set; }

        public PackedPerDay()
        {
            PackedUnits = new List<PackedUnit>();
        }

    }
}
        