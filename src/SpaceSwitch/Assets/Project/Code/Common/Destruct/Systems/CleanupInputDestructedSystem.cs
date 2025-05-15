using System.Collections.Generic;
using Entitas;

namespace Code.Common.Destruct.Systems
{
   public class CleanupInputDestructedSystem : ICleanupSystem
   {
      private readonly IGroup<InputEntity> _entities;
      private readonly List<InputEntity> _buffer = new (16);

      public CleanupInputDestructedSystem(InputContext inputContext) => 
         _entities = inputContext.GetGroup(InputMatcher.Destructed);

      public void Cleanup()
      {
         foreach (InputEntity entity in _entities.GetEntities(_buffer)) 
            entity.Destroy();
      }
   }
}