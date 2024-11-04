using Code.Infrastructure.States.StateInfrastructure;
using VContainer;

namespace Code.Infrastructure.States.Factory
{
   public class StateFactory : IStateFactory
   {
      private readonly IObjectResolver _objectResolver;

      public StateFactory(IObjectResolver objectResolver) =>
         _objectResolver = objectResolver;

      public T Create<T>(Lifetime lifetime) where T : class, IExitableState
      {
         RegistrationBuilder registrationBuilder = new RegistrationBuilder(typeof(T), lifetime)
            .AsImplementedInterfaces()
            .AsSelf();

         return (T)_objectResolver.Resolve(registrationBuilder.Build());
      }
   }
}