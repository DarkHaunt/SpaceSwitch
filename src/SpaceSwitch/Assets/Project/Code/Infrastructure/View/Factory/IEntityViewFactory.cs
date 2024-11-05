using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Code.Infrastructure.View.Factory
{
  public interface IEntityViewFactory
  {
    EntityBehaviour CreateViewForEntity(GameEntity entity);
    EntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity);
    UniTask<EntityBehaviour> CreateViewForEntityFromAsset(GameEntity entity);
  }
}