﻿using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Project.Code.Common.UI.LoadingCurtain
{
    public class LoadingCurtain : MonoBehaviour, ILoadingCurtain
    {
        [SerializeField] private CanvasGroup _curtain;
        
        public UniTask Show(CancellationToken cancellation = default)
        {
            gameObject.SetActive(true);
            
            return _curtain
                .DOFade(1f, LoadingCurtainConstants.ShowTime)
                .SetUpdate(true)
                .ToUniTask(cancellationToken: cancellation);
        }

        public UniTask Hide(CancellationToken cancellation = default)
        {
            return _curtain
                .DOFade(0f, LoadingCurtainConstants.HideTime)
                .SetUpdate(true)
                .OnComplete(() => gameObject.SetActive(false))
                .ToUniTask(cancellationToken: cancellation);
        }

        public void ShowImmediate()
        {
            gameObject.SetActive(true);
            _curtain.alpha = 1;
        }
        
        public void HideImmediate()
        {
            _curtain.alpha = 0;
            gameObject.SetActive(false);
        }
    }
}