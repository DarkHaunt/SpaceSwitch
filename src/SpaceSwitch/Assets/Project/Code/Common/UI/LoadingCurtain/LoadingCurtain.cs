using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Project.Code.Common.UI.LoadingCurtain
{
    public class LoadingCurtain : MonoBehaviour, ILoadingCurtain
    {
        [SerializeField] private CanvasGroup _curtain;
        
        private Tween _curtainTween;
        
        public UniTask Show(CancellationToken cancellation = default)
        {
            gameObject.SetActive(true);
            
            _curtainTween?.Kill();
            _curtainTween = _curtain
                .DOFade(1f, LoadingCurtainConstants.ShowTime)
                .SetUpdate(true);
            
            return _curtainTween.ToUniTask(cancellationToken: cancellation);
        }

        public UniTask Hide(CancellationToken cancellation = default)
        {
            _curtainTween?.Kill();
            _curtainTween = _curtain
                .DOFade(0f, LoadingCurtainConstants.HideTime)
                .SetUpdate(true)
                .OnComplete(() => gameObject.SetActive(false));

            return _curtainTween.ToUniTask(cancellationToken: cancellation);
        }

        public void ShowImmediate()
        {
            _curtainTween?.Kill();

            gameObject.SetActive(true);
            _curtain.alpha = 1;
        }
        
        public void HideImmediate()
        {
            _curtainTween?.Kill();
            
            _curtain.alpha = 0;
            gameObject.SetActive(false);
        }
    }
}