using Code.Infrastructure.States.StateInfrastructure;
using VContainer;

namespace Code.Infrastructure.States.Factory
{
  public interface IStateFactory
  {
    T Create<T>(Lifetime lifetime) where T : class, IExitableState;
  }
}