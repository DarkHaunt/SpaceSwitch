using System.Collections;

namespace Project.Code.Common.Infrastructure.CoroutineRunner
{
    public interface ICoroutineRunner
    {
        void RunCoroutine(IEnumerator coroutine);
        void StopRunningCoroutine(IEnumerator coroutine);
    }
}