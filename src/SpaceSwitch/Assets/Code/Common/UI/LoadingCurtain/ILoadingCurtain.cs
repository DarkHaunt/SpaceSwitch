using Cysharp.Threading.Tasks;

namespace Project.Code.Common.UI.LoadingCurtain
{
    public interface ILoadingCurtain
    {
        UniTask Show();
        UniTask Hide();
        void ShowImmediate();
        void HideImmediate();
    }
}