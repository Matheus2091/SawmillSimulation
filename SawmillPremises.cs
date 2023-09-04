namespace SawmillSimulation
{
    public class SawmillPremises
    {
        public Range BendAngleRange { get; set; }
        public Range GroupingCycleTimeRange { get; set; }
        public Range TransportCycleTimeRange { get; set; }
        public Range StorageCycleTimeRange { get; set; }
        public int MaximumGroupSize { get; set; }
    }
}
