namespace PackingTracer.Data.PackingDay
{
    public class WorkDaySheet
    {
        public int Day { get; set; }
        public List<PackedUnit> Packed { get; set; }

        // Constructor
        public WorkDaySheet()
        {
            Packed = new List<PackedUnit>();
        }

    }
}
