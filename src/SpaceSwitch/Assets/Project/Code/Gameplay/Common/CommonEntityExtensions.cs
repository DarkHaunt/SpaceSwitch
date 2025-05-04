using UnityEngine;

namespace Code.Gameplay.Common
{
   public static class CommonEntityExtensions
   {
      public static GameEntity RemoveAndDisableCollider(this GameEntity entity)
      {
         if (entity.hasCollider)
         {
            entity.Collider.enabled = false;
            entity.RemoveCollider();
         }
      
         return entity;
      }
   }
}