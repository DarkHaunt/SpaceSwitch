using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Player.StaticData;
using Code.Gameplay.StaticData;
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
      
      public GameEntity CreateHero(Vector3 at, PlayerConfig config)
      {
         return CreateGameEntity.Empty()
               .AddId(_identifiers.Next())
               .AddWorldPosition(at)
               .AddDirection(Vector2.zero)
               .AddVelocity(Vector2.zero)
               
               .AddAssetReference(config.Prefab)
               .AddSpeed(config.Speed)
               
               .With(x => x.isPlayer = true)
               .With(x => x.isMovementAvailable = true)
            ;
      }
   }
}