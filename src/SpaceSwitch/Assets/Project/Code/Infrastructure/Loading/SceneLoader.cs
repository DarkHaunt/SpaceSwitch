using System;
using Code.Infrastructure.Loading;
using Cysharp.Threading.Tasks;
using Project.Code.Common.UI.LoadingCurtain;
using UnityEngine.SceneManagement;

namespace Project.Code.Common.Infrastructure.SceneLoader
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ILoadingCurtain _loadingCurtain;

        public SceneLoader(ILoadingCurtain loadingCurtain)
        {
            _loadingCurtain = loadingCurtain;
        }

        public UniTask Load(SceneName scene, bool force = false, Action onLoaded = null) =>
            LoadSceneAsync(scene.ToString(), force, onLoaded);
        
        public UniTask LoadWithCurtain(SceneName scene, bool force = false, Action onLoaded = null)
        {
            _loadingCurtain.Show();
            return LoadSceneAsync(scene.ToString(), force, onLoaded);
        }

        private async UniTask LoadSceneAsync(string nextScene, bool force, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == nextScene && force == false)
            {
                onLoaded?.Invoke();
                return;
            }
            
            await SceneManager
                .LoadSceneAsync(nextScene)
                .ToUniTask();
            
            onLoaded?.Invoke();
        }
    }
}