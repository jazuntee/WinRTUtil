# WinRTUtil
Windows Runtime API Utilities

This .NET Standard library is an updated take on a similar library by [Keith Hill](https://github.com/rkeithhill) called [PoshWinRT](https://github.com/rkeithhill/PoshWinRT) but with a static class and less [Task<TResult>](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1) management. It includes the bare minimum to compensate for PowerShell not recognizing the [IAsyncOperation<TResult>](https://docs.microsoft.com/en-us/uwp/api/windows.foundation.iasyncoperation-1) Interface.

## Example Usage in PowerShell
```powershell
Add-Type -Path 'WinRTUtil.dll'
[Windows.Storage.StorageFile, Windows.Storage, ContentType = WindowsRuntime] | Out-Null

## Get Storage File
$AsyncOperation = [Windows.Storage.StorageFile]::GetFileFromPathAsync("D:\myFile.txt")
[Windows.Storage.StorageFile] $StorageFile = [WinRTUtil.AsyncOperation[Windows.Storage.StorageFile]]::GetResults($AsyncOperation)
```

```powershell
Add-Type -Path 'WinRTUtil.dll'
[Windows.Storage.StorageFile, Windows.Storage, ContentType = WindowsRuntime] | Out-Null

## Get Storage File
$AsyncOperation = [Windows.Storage.StorageFile]::GetFileFromPathAsync("D:\myFile.txt")
[System.Threading.Tasks.Task[Windows.Storage.StorageFile]] $Task = [WinRTUtil.AsyncOperation[Windows.Storage.StorageFile]]::AsTask($AsyncOperation)
[Windows.Storage.StorageFile] $StorageFile = $Task.Result

## Get Storage File Properties
[System.Collections.Generic.List[string]] $listPropertyNames = New-Object System.Collections.Generic.List[string]
$listPropertyNames.Add('System.Title')
$listPropertyNames.Add('System.Author')

$AsyncOperation = $StorageFile.Properties.RetrievePropertiesAsync($listPropertyNames)
[System.Threading.Tasks.Task[System.Collections.Generic.IDictionary[string, object]]] $Task = [WinRTUtil.AsyncOperation[System.Collections.Generic.IDictionary[string, object]]]::AsTask($AsyncOperation)
$StorageFileProperties = [WinRTUtil.ConvertTo[System.Collections.Generic.Dictionary[string, object]]]::From($Task.Result)
```

```powershell
Add-Type -Path 'WinRTUtil.dll'
[Windows.Storage.StorageFile, Windows.Storage, ContentType = WindowsRuntime] | Out-Null

## Get Storage File
$AsyncOperation = [Windows.Storage.StorageFile]::GetFileFromPathAsync("D:\myFile.txt")
[Windows.Storage.StorageFile] $StorageFile = [WinRTUtil.AsyncOperation[Windows.Storage.StorageFile]]::AwaitResult($AsyncOperation)

## Get Storage File Properties
[System.Collections.Generic.List[string]] $listPropertyNames = New-Object System.Collections.Generic.List[string]
$listPropertyNames.Add('System.Title')
$listPropertyNames.Add('System.Author')

$AsyncOperation = $StorageFile.Properties.RetrievePropertiesAsync($listPropertyNames)
$StorageFileProperties = [WinRTUtil.AsyncOperation[System.Collections.Generic.IDictionary[string, object]]]::AwaitResult($AsyncOperation, $true)
```
