# WinRTUtil
Windows Runtime API Utilities

This .NET Standard library is an updated take on similar library by [Keith Hill](https://github.com/rkeithhill) called [PoshWinRT](https://github.com/rkeithhill/PoshWinRT) but with a static class and less [Task<TResult>](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) management. It includes the bare minimum to compensate for PowerShell not recognizing the [IAsyncOperation<TResult>](https://docs.microsoft.com/en-us/uwp/api/windows.foundation.iasyncoperation-1) Interface.
