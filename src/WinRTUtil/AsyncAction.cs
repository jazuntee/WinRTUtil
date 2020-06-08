using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Foundation;

namespace WinRTUtil
{
    public static class AsyncAction
    {
        public static Task AsTask(object objAsyncAction)
        {
            IAsyncAction asyncAction = objAsyncAction as IAsyncAction;
            return asyncAction.AsTask();
        }

        public static void Await(object objAsyncAction)
        {
            Task task = AsTask(objAsyncAction);
            task.Wait();
        }

        public static void GetResults(object objAsyncAction)
        {
            IAsyncAction asyncAction = objAsyncAction as IAsyncAction;
            asyncAction.GetResults();
        }
    }
    
}
