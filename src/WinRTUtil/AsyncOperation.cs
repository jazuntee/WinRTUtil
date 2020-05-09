using System;
using System.Threading.Tasks;
using Windows.Foundation;

namespace WinRTUtil
{
    public static class AsyncOperation<T>
    {
        public static Task<T> AsTask(object objAsyncOperation)
        {
            IAsyncOperation<T> asyncOperation = objAsyncOperation as IAsyncOperation<T>;
            return asyncOperation.AsTask();
        }

        public static T GetResults(object objAsyncOperation)
        {
            IAsyncOperation<T> asyncOperation = objAsyncOperation as IAsyncOperation<T>;
            return asyncOperation.GetResults();
        }
    }
}
