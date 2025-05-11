using System;
using Code.Infrastructure.Loading;
using Cysharp.Threading.Tasks;

namespace Project.Code.Common.Infrastructure.SceneLoader
{
    public interface ISceneLoader
    {
        public UniTask Load(SceneName scene, bool force = false, Action onLoaded = null);
        public UniTask LoadWithCurtain(SceneName scene, bool force = false, Action onLoaded = null);
    }
}