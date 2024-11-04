using System;
using System.Threading;
using System.Threading.Tasks;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
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

      public RootBootstrapper(ISceneLoader sceneLoader, ILoadingCurtain loadingCurtain, IAssetProvider assetProvider)
      {
         _sceneLoader = sceneLoader;
         _loadingCurtain = loadingCurtain;
         _assetProvider = assetProvider;
      }

      public async UniTask StartAsync(CancellationToken cancellation = new CancellationToken())
      {
         _loadingCurtain.HideImmediate();
         
         Promise.UnhandledException += LogPromiseException;
      
         await LoadAddressables();
      
         await _sceneLoader.Load(SceneName.Menu);  
      }

      private async UniTask LoadAddressables()
      {
         await _assetProvider.InitializeAsync();

         await UniTask.WhenAll
         (
            _assetProvider.WarmupAssetsByLabel(AssetLabel.Player),
            _assetProvider.WarmupAssetsByLabel(AssetLabel.Enemies),
            _assetProvider.WarmupAssetsByLabel(AssetLabel.Projectiles)
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