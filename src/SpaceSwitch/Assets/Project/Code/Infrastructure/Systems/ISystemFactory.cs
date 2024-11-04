using Entitas;
using VContainer;

namespace Code.Infrastructure.Systems
{
  public interface ISystemFactory
  {
    T Create<T>(Lifetime lifetime = Lifetime.Scoped) where T : ISystem;
  }
}