using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Code.Gameplay.Features.Enemy;
using Code.Gameplay.Features.Player.StaticData;
using Code.Gameplay.Features.Projectiles;
using Code.Gameplay.Features.Scrolling.StaticData;
using Code.Gameplay.Windows;
using Code.Gameplay.Windows.Configs;
using Code.Infrastructure.AssetManagement;
using Cysharp.Threading.Tasks;
using Project.Code.Gameplay.Features.Cameras;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
   public class StaticDataService : IStaticDataService
   {
      private readonly IAssetProvider _assetProvider;

      private Dictionary<WindowId, GameObject> _windowPrefabsById;

      private Dictionary<ProjectileTypeId, ProjectileConfig> _projectileConfigs;
      private Dictionary<EnemyTypeId, EnemyConfig> _enemyConfigs;

      public EnemySpawnConfig[] EnemySpawnSpawnConfigs { get; private set; }
      public PlayerConfig PlayerConfig { get; private set; }
      public CameraConfig CameraConfig { get; private set; }
      public LevelsConfig LevelsConfig { get; private set; }

      public StaticDataService(IAssetProvider assetProvider)
      {
         _assetProvider = assetProvider;
      }

      public UniTask LoadAll(CancellationToken cancellation = default)
      {
         return UniTask.WhenAll
         (
            LoadPlayerConfig(),
            LoadCameraConfig(),
            LoadLevelsConfig(),
            LoadEnemyConfigs(),
            LoadAllWindows(),
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
         PlayerConfig = await _assetProvider.Load<PlayerConfig>(AssetPath.PlayerConfig);

      private async UniTask LoadLevelsConfig() =>
         LevelsConfig = await _assetProvider.Load<LevelsConfig>(AssetPath.LevelPartConfig);

      private async UniTask LoadCameraConfig() =>
         CameraConfig = await _assetProvider.Load<CameraConfig>(AssetPath.CameraConfig);

      private async UniTask LoadEnemyConfigs()
      {
         var enemies = await _assetProvider.LoadAllByLabel<EnemyConfig>(AssetLabel.Enemies);
         _enemyConfigs = enemies.ToDictionary(x => x.Id, y => y);
         
         EnemySpawnSpawnConfigs = await _assetProvider.LoadAllByLabel<EnemySpawnConfig>(AssetLabel.EnemySpawners);
      }

      private async UniTask LoadAllWindows()
      {
         var windows = await _assetProvider.LoadAllByLabel<WindowConfig>(AssetLabel.Windows);
         _windowPrefabsById = windows.ToDictionary(x => x.Id, y => y.Prefab);
      }
   }
}