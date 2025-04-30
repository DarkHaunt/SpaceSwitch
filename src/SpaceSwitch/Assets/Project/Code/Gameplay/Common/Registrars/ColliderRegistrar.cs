using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Common.Registrars
{
   public class ColliderRegistrar : EntityComponentRegistrar
   {
      public Collider Colllider;
      
      public override void RegisterComponents()
      {
         Entity.AddCollider(Colllider);
      }

      public override void UnregisterComponents()
      {
         if (Entity.hasCollider)
            Entity.RemoveCollider();
      }
   }
}