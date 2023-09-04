namespace SawmillSimulation
{
    public class SawmillProcess
    {
        public SawmillState State { get; private set; }
        public SawmillPremises Premises { get; private set; }

        public SawmillProcess(SawmillState initialState, SawmillPremises premises)
        {
            State = initialState;
            Premises = premises;
        }

        public void Supply()
        {
            (Premises.BendAngleRange.End - Premises.BendAngleRange.Start + 1)
        }

        public void Process()
        {

        }

        public void Group()
        {

        }

        public void Transport()
        {
            State.GroupSize = 0;
        }

        public void Store()
        {

        }
    }
}
