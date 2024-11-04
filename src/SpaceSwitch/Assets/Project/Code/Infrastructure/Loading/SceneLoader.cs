using System;
using Code.Infrastructure.Loading;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Project.Code.Common.Infrastructure.SceneLoader
{
    public class SceneLoader : ISceneLoader
    {
        public UniTask Load(SceneName scene, bool force = false, Action onLoaded = null) =>
            LoadSceneAsync(scene.ToString(), force, onLoaded);

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