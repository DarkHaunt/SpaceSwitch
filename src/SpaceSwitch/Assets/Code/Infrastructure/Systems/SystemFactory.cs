using Entitas;
using VContainer;
using VContainer.Unity;

namespace Code.Infrastructure.Systems
{
  public class SystemFactory : ISystemFactory
  {
    private readonly IObjectResolver _resolver;

    public SystemFactory(IObjectResolver resolver) => 
      _resolver = resolver;

    public T Create<T>() where T : ISystem =>
      _resolver.Resolve<T>();
  }
}