using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Player.Factories
{
   public class PlayerFactory : IPlayerFactory
   {
      private readonly IIdentifierService _identifiers;

      public PlayerFactory(IIdentifierService identifiers)
      {
         _identifiers = identifiers;
      }
      
      public GameEntity CreateHero(Vector3 at)
      {
         return CreateGameEntity.Empty()
               .AddId(_identifiers.Next())
               .With(x => x.isPlayer = true)
               .AddWorldPosition(at)
            ;
      }
   }
}