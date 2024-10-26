using RSG;

namespace Code.Infrastructure.States.StateInfrastructure
{
   public class EndOfFrameExitState  : IState, IUpdateable
   {
      private Promise _exitPromise;

      private bool ExitWasRequested => _exitPromise != null;

      IPromise IExitableState.BeginExit()
      {
         _exitPromise = new Promise();
         return _exitPromise;
      }

      public virtual void Enter() {}

      public void Update()
      {
         if (_exitPromise == null)
            OnUpdate();

         if (ExitWasRequested)
            ResolveExitPromise();
      }

      void IExitableState.EndExit()
      {
         ExitOnEndOfFrame();
         ClearExitPromise();
      }

      private void ClearExitPromise() =>
         _exitPromise = null;

      private void ResolveExitPromise() =>
         _exitPromise?.Resolve();

      protected virtual void OnUpdate() {}
      protected virtual void ExitOnEndOfFrame() {}
   }
}