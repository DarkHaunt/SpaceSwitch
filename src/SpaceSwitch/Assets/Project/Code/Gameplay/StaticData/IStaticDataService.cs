using System.Collections.Generic;
using System.Threading;
using Code.Gameplay.Features.Enemy;
using Code.Gameplay.Features.Player.StaticData;
using Code.Gameplay.Features.Projectiles;
using Code.Gameplay.Windows;
using Cysharp.Threading.Tasks;
using Project.Code.Gameplay.Features.Cameras;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
  public interface IStaticDataService
  {
    PlayerConfig PlayerConfig { get; }
    CameraConfig CameraConfig { get; }
    
    ProjectileConfig GetProjectileConfigById(ProjectileTypeId id);
    EnemyConfig GetEnemyConfigWithId(EnemyTypeId id);
    
    UniTask LoadAll(CancellationToken cancellation = default);
    
    GameObject GetWindowPrefab(WindowId id);
  }
}