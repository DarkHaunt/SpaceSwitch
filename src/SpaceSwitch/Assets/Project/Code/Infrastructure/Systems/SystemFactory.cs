using Entitas;
using VContainer;
using VContainer.Unity;

namespace Code.Infrastructure.Systems
{
  public class SystemFactory : ISystemFactory
  {
    private readonly IObjectResolver _objectResolver;

    public SystemFactory(IObjectResolver objectResolver) => 
      _objectResolver = objectResolver;

    public T Create<T>(Lifetime lifetime = Lifetime.Scoped) where T : ISystem
    {
      RegistrationBuilder registrationBuilder = new RegistrationBuilder(typeof(T), lifetime)
        .AsImplementedInterfaces()
        .AsSelf();
      
      return (T) _objectResolver.Resolve(registrationBuilder.Build());
    }
  }
}