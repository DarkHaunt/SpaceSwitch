using Code.Gameplay.Features.Player.StaticData;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.Gameplay.Features.Player.Factories
{
   public interface IPlayerFactory
   {
      GameEntity CreateHero(Vector3 at, PlayerConfig config);
   }
}