using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Project.Code.Common.UI.BaseScreen
{
    public abstract class CommonScreen : MonoBehaviour
    {
        private bool _isInAnimation;
        
        public async UniTask ShowAsync()
        {
            if (_isInAnimation)
            {
                Debug.LogError($"Can't play <Show> animation of <{name}> while another animation is playing");
                return;
            }
            _isInAnimation = true;
            await PlayShowAnimationAsync();
            _isInAnimation = false;
        }

        public async UniTask HideAsync()
        {
            if (_isInAnimation)
            {
                Debug.LogError($"Can't play <Hide> animation of <{name}> while another animation is playing");
                return;
            }
            _isInAnimation = true;
            await PlayHideAnimationAsync();
            _isInAnimation = false;
        }
        
        protected virtual UniTask PlayShowAnimationAsync() => UniTask.CompletedTask;
        protected virtual UniTask PlayHideAnimationAsync() => UniTask.CompletedTask;
    }
}