# WinRTUtil
Windows Runtime API Utilities

This .NET Standard library is an updated take on similar library by [Keith Hill](https://github.com/rkeithhill) called [PoshWinRT](https://github.com/rkeithhill/PoshWinRT) but with a static class and less [Task<TResult>](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) management. It includes the bare minimum to compensate for PowerShell not recognizing the [IAsyncOperation<TResult>](https://docs.microsoft.com/en-us/uwp/api/windows.foundation.iasyncoperation-1) Interface.

## Example Usage in PowerShell
```powershell
Add-Type -Path 'WinRTUtil.dll'
[Windows.Storage.StorageFile, Windows.Storage, ContentType = WindowsRuntime] | Out-Null
$AsyncOperation = [Windows.Storage.StorageFile]::GetFileFromPathAsync("D:\myFile.txt")
[Windows.Storage.StorageFile] $StorageFile = [WinRTUtil.AsyncOperation[Windows.Storage.StorageFile]]::GetResults($AsyncOperation)
```

```powershell
Add-Type -Path 'WinRTUtil.dll'
[Windows.Storage.StorageFile, Windows.Storage, ContentType = WindowsRuntime] | Out-Null
$AsyncOperation = [Windows.Storage.StorageFile]::GetFileFromPathAsync("D:\myFile.txt")
[System.Threading.Tasks.Task[Windows.Storage.StorageFile]] $Task = [WinRTUtil.AsyncOperation[Windows.Storage.StorageFile]]::AsTask($AsyncOperation)
[Windows.Storage.StorageFile] $StorageFile = $Task.Result
```
