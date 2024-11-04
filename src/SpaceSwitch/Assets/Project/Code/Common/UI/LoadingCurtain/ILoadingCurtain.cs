using System.Threading;
using Cysharp.Threading.Tasks;

namespace Project.Code.Common.UI.LoadingCurtain
{
    public interface ILoadingCurtain
    {
        UniTask Show(CancellationToken cancellation = default);
        UniTask Hide(CancellationToken cancellation = default);
        void ShowImmediate();
        void HideImmediate();
    }
}