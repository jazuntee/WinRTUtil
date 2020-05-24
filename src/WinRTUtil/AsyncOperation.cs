using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public static object AwaitResult(object objAsyncOperation, bool convertTypes)
        {
            Task<T> task = AsTask(objAsyncOperation);
            //task.Wait();

            if (convertTypes)
            {
                if (typeof(T).IsConstructedGenericType && typeof(T).GetGenericTypeDefinition() == typeof(IDictionary<,>))
                {
                    return Activator.CreateInstance(typeof(Dictionary<,>).MakeGenericType(typeof(T).GenericTypeArguments), task.Result);
                }
                else if (typeof(T).IsConstructedGenericType && typeof(T).GetGenericTypeDefinition() == typeof(IList<>))
                {
                    return Activator.CreateInstance(typeof(List<>).MakeGenericType(typeof(T).GenericTypeArguments), task.Result);
                }
                else if (typeof(T).IsConstructedGenericType && typeof(T).GetGenericTypeDefinition() == typeof(IReadOnlyList<>))
                {
                    var list = Activator.CreateInstance(typeof(List<>).MakeGenericType(typeof(T).GenericTypeArguments), task.Result);
                    return Activator.CreateInstance(typeof(ReadOnlyCollection<>).MakeGenericType(typeof(T).GenericTypeArguments), list);
                }
                else
                {
                    return task.Result;
                }
            }
            else
            {
                return task.Result;
            }
        }

        public static T GetResults(object objAsyncOperation)
        {
            IAsyncOperation<T> asyncOperation = objAsyncOperation as IAsyncOperation<T>;
            return asyncOperation.GetResults();
        }
    }
}
