using Code.Infrastructure.States.StateInfrastructure;
using VContainer;

namespace Code.Infrastructure.States.Factory
{
  public class StateFactory : IStateFactory
  {
    private readonly IObjectResolver _resolver;

    public StateFactory(IObjectResolver resolver)
    {
      _resolver = resolver;
    }

    public T GetState<T>() where T : class, IExitableState
    {
      return _resolver.Resolve<T>();
    }
  }
}