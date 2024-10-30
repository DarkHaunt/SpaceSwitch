using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Code.Menu
{
   public class MenuInstaller : LifetimeScope
   {
      [SerializeField] private MenuView _view;
      
      
      protected override void Configure(IContainerBuilder builder)
      {
         builder.RegisterComponent(_view);
         builder.Register<MenuController>(Lifetime.Scoped).AsImplementedInterfaces().AsSelf();
      }
   }
}