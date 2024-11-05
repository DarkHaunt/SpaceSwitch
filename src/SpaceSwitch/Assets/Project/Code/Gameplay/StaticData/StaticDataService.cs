using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Code.Gameplay.Features.Enemy;
using Code.Gameplay.Features.Player.StaticData;
using Code.Gameplay.Features.Projectiles;
using Code.Gameplay.Windows;
using Code.Infrastructure.AssetManagement;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.Gameplay.StaticData
{
   public class StaticDataService : IStaticDataService
   {
      private readonly IAssetProvider _assetProvider;

      private Dictionary<WindowId, GameObject> _windowPrefabsById;

      private Dictionary<ProjectileTypeId, ProjectileConfig> _projectileConfigs;
      private Dictionary<EnemyTypeId, EnemyConfig> _enemyConfigs;

      public PlayerConfig PlayerConfig { get; private set; }

      public StaticDataService(IAssetProvider assetProvider)
      {
         _assetProvider = assetProvider;
      }

      public UniTask LoadAll(CancellationToken cancellation = default)
      {
         return UniTask.WhenAll
         (
            LoadPlayerConfig(),
            LoadAllWindows(),
            LoadEnemyConfigs(),
            LoadProjectileConfigs()
         );
      }

      public ProjectileConfig GetProjectileConfigById(ProjectileTypeId id)
      {
         return _projectileConfigs.TryGetValue(id, out ProjectileConfig config)
            ? config
            : throw new Exception($"Projectile config for id {id} does not exist");
      }

      public EnemyConfig GetEnemyConfigWithId(EnemyTypeId id)
      {
         return _enemyConfigs.TryGetValue(id, out EnemyConfig config)
            ? config
            : throw new Exception($"Enemy config for id {id} does not exist");
      }

      public GameObject GetWindowPrefab(WindowId id)
      {
         return _windowPrefabsById.TryGetValue(id, out GameObject prefab)
            ? prefab
            : throw new Exception($"Prefab config for window {id} was not found");
      }

      private async UniTask LoadProjectileConfigs()
      {
         var projectiles = await _assetProvider.LoadAllByLabel<ProjectileConfig>(AssetLabel.Projectiles);
         _projectileConfigs = projectiles.ToDictionary(x => x.Id, y => y);
      }

      private async UniTask LoadPlayerConfig() =>
         PlayerConfig = await _assetProvider.Load<PlayerConfig>(AssetLabel.Player);

      private async UniTask LoadEnemyConfigs()
      {
         var enemies = await _assetProvider.LoadAllByLabel<EnemyConfig>(AssetLabel.Enemies);
         _enemyConfigs = enemies.ToDictionary(x => x.Id, y => y);
      }

      private UniTask LoadAllWindows()
      {
         return UniTask.CompletedTask;
      }
   }
}