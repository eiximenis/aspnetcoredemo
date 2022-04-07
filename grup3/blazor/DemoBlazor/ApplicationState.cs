namespace DemoBlazor
{
    public class ApplicationState
    {
        public IntHolder CounterState { get; set; }
        public ApplicationState()
        {
            CounterState = new IntHolder();
        }
    }
}
