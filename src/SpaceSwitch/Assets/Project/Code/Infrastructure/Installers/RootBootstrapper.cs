﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Loading;
using Code.Progress.SaveLoad;
using Cysharp.Threading.Tasks;
using Project.Code.Common.Infrastructure.SceneLoader;
using Project.Code.Common.UI.LoadingCurtain;
using RSG;
using UnityEngine;
using VContainer.Unity;

namespace Code.Infrastructure.Installers
{
   public class RootBootstrapper : IAsyncStartable, IDisposable
   {
      private readonly ISceneLoader _sceneLoader;
      private readonly ILoadingCurtain _loadingCurtain;
      private readonly IAssetProvider _assetProvider;
      private readonly ISaveLoadService _saveLoadService;

      public RootBootstrapper(ISceneLoader sceneLoader, ILoadingCurtain loadingCurtain, IAssetProvider assetProvider, ISaveLoadService saveLoadService)
      {
         _sceneLoader = sceneLoader;
         _loadingCurtain = loadingCurtain;
         _assetProvider = assetProvider;
         _saveLoadService = saveLoadService;
      }

      public async UniTask StartAsync(CancellationToken cancellation = new CancellationToken())
      {
         _loadingCurtain.HideImmediate();
         
         Promise.UnhandledException += LogPromiseException;
      
         await LoadAddressables();
         await LoadProgress();
      
         await _sceneLoader.Load(SceneName.Game);  
      }

      private async UniTask LoadProgress()
      {
         if (_saveLoadService.HasSavedProgress)
            _saveLoadService.LoadProgress();
         else
            _saveLoadService.CreateProgress();
      }

      private async UniTask LoadAddressables()
      {
         await _assetProvider.InitializeAsync();

         await UniTask.WhenAll
         (
            _assetProvider.WarmupAssetsByLabel(AssetLabel.Enemies),
            _assetProvider.WarmupAssetsByLabel(AssetLabel.EnemySpawners),
            
            _assetProvider.WarmupAssetsByLabel(AssetLabel.Projectiles),
            
            _assetProvider.WarmupAssetsByLabel(AssetLabel.Gameplay),
            _assetProvider.WarmupAssetsByLabel(AssetLabel.Configs)
         );
      }

      public void Dispose()
      {
         Promise.UnhandledException -= LogPromiseException;
      }

      private void LogPromiseException(object sender, ExceptionEventArgs e) =>
         Debug.LogException(e.Exception);
   }
}