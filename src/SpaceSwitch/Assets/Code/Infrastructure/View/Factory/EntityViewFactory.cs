using Code.Infrastructure.AssetManagement;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Code.Infrastructure.View.Factory
{
  public class EntityViewFactory : IEntityViewFactory
  {
    private readonly IAssetProvider _assetProvider;
    private readonly IObjectResolver _resolver;
    private readonly Vector3 _farAway = new(-999, 999, 0);

    public EntityViewFactory(IAssetProvider assetProvider, IObjectResolver resolver)
    {
      _assetProvider = assetProvider;
      _resolver = resolver;
    }
    
    public EntityBehaviour CreateViewForEntity(GameEntity entity)
    {
      EntityBehaviour viewPrefab = _assetProvider.LoadAsset<EntityBehaviour>(entity.ViewPath);
      EntityBehaviour view = _resolver.Instantiate<EntityBehaviour>(
        viewPrefab,
        position: _farAway,
        Quaternion.identity,
        parent: null);
      
      view.SetEntity(entity);

      return view;
    }

    public EntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity)
    {
      EntityBehaviour view = _resolver.Instantiate<EntityBehaviour>(
        entity.ViewPrefab,
        position: _farAway,
        Quaternion.identity,
        parent: null);
      
      view.SetEntity(entity);

      return view;
    }
  }
}