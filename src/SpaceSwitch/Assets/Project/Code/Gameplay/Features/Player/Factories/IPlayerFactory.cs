using UnityEngine;

namespace Code.Gameplay.Features.Player.Factories
{
   public interface IPlayerFactory
   {
      GameEntity CreateHero(Vector3 at);
   }
}