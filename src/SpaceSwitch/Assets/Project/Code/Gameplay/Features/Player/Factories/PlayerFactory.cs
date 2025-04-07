using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.ColorSwitch.StaticData;
using Code.Gameplay.Features.Player.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Player.Factories
{
   public class PlayerFactory
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
               
               .AddViewPrefab(config.Prefab)
               .AddSpeed(config.Speed)
               .AddColorType(ColorType.Blue)
               
               .AddShootDirection(Vector3.up)
               
               .With(x => x.isPlayer = true)
               .With(x => x.isMovementAvailable = true)
            ;
      }
   }
}