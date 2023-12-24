namespace Suhdo.StateMachineCore
{
    public class StateMachine
    {
        public CoreState CurrentCoreState { get; private set; }
    
        public virtual void Initiallize(CoreState startingCoreState)
        {
            CurrentCoreState = startingCoreState;
            CurrentCoreState.Enter();
        }

        public virtual void ChangeState(CoreState newCoreState)
        {
            if (newCoreState == CurrentCoreState) return;
            CurrentCoreState.Exit();
            CurrentCoreState = newCoreState;
            CurrentCoreState.Enter();
        }
    }
}
