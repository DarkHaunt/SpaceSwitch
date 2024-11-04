using System.Collections.Generic;
using Code.Infrastructure.View.Factory;
using Entitas;

namespace Code.Infrastructure.View.Systems
{
   public sealed class BindEntityViewFromAssetReferenceSystem : IExecuteSystem
   {
      private readonly IEntityViewFactory _entityViewFactory;
      private readonly IGroup<GameEntity> _entities;
      private readonly List<GameEntity> _buffer = new(32);

      public BindEntityViewFromAssetReferenceSystem(GameContext context)
      {
         _entities = context.GetGroup(GameMatcher
            .AllOf(GameMatcher.AssetReference)
            .NoneOf(GameMatcher.View));
      }

      public void Execute()
      {
         foreach (GameEntity entity in _entities.GetEntities(_buffer))
         {
            _entityViewFactory.CreateViewForEntityFromAsset(entity.AssetReference);
         }
      }
   }
}