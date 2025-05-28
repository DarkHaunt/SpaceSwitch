using System.Collections.Generic;
using Entitas;

namespace Project.Code.Gameplay.Features.Player.Systems
{
   public sealed class PlayerSoundPlayerInitSystem : ReactiveSystem<GameEntity>
   {
      public PlayerSoundPlayerInitSystem(GameContext context) : base(context)
      {
      }

      protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
         context.CreateCollector(GameMatcher.AllOf
         (
            GameMatcher.Player,
            GameMatcher.Speed,
            GameMatcher.PlayerSoundPlayer
         ).Added());
      protected override bool Filter(GameEntity entity) => entity.isPlayer;

      protected override void Execute(List<GameEntity> entities)
      {
         foreach (GameEntity player in entities)
            player.PlayerSoundPlayer.PlayAmbientSound();
      }
   }
}