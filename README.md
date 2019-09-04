[![Build status](https://ci.appveyor.com/api/projects/status/804re7py0d5a6qs3/branch/master?svg=true)](https://ci.appveyor.com/project/CarlosLanderas/dotnet-tarball-cleanup)

# Dotnet Tarball Cleanup Global Tool

## A simple global tool to list and remove sdks and runtimes when installed from tarballs using dotnet-install scripts

### Usage:


## **Remove sdk by version**
```
 dotnet-tarball-cleanup sdks remove --version 2.2.401
```

**Output**
```
Looking for sdk 2.2.401
Removing: /home/clanderas/.dotnet/sdk/2.2.401 Done! ✔
Sdk 2.2.401 removed ✔

```

## **Remove runtime by version**
```
 dotnet-tarball-cleanup runtimes remove --version 2.2.6
```

**Output**
```
Looking for runtime 2.2.6
Removing: /home/clanderas/.dotnet/shared/Microsoft.AspNetCore.All/2.2.6 Done! ✔
```

## **Remove all sdks**
```
dotnet-tarball-cleanup sdks remove --all

```

**Output**
```
Looking for sdk 3.0.100-preview6-012264
Removing: /home/clanderas/.dotnet/sdk/3.0.100-preview6-012264 Done! ✔
Sdk 3.0.100-preview6-012264 removed ✔
Looking for sdk 3.0.100-preview7-012821
Removing: /home/clanderas/.dotnet/sdk/3.0.100-preview7-012821 Done! ✔
Sdk 3.0.100-preview7-012821 removed ✔
Looking for sdk 3.0.100-preview8-013656
Removing: /home/clanderas/.dotnet/sdk/3.0.100-preview8-013656 Done! ✔
Sdk 3.0.100-preview8-013656 removed ✔

```

## **Remove all runtimes**
```
dotnet-tarball-cleanup runtimes remove --all
```

**Output**
```
Looking for runtime 2.2.6
Removing: /home/clanderas/.dotnet/shared/Microsoft.AspNetCore.App/2.2.6 Done! ✔
Looking for runtime 3.0.0-preview6.19307.2
Removing: /home/clanderas/.dotnet/shared/Microsoft.AspNetCore.App/3.0.0-preview6.19307.2 Done! ✔
Looking for runtime 3.0.0-preview7.19365.7
Removing: /home/clanderas/.dotnet/shared/Microsoft.AspNetCore.App/3.0.0-preview7.19365.7 Done! ✔
Looking for runtime 3.0.0-preview8.19405.7
Removing: /home/clanderas/.dotnet/shared/Microsoft.AspNetCore.App/3.0.0-preview8.19405.7 Done! ✔
Looking for runtime 2.2.6
Removing: /home/clanderas/.dotnet/shared/Microsoft.NETCore.App/2.2.6 Done! ✔
Looking for runtime 3.0.0-preview6-27804-01
Removing: /home/clanderas/.dotnet/shared/Microsoft.NETCore.App/3.0.0-preview6-27804-01 Done! ✔
Looking for runtime 3.0.0-preview7-27912-14
Removing: /home/clanderas/.dotnet/shared/Microsoft.NETCore.App/3.0.0-preview7-27912-14 Done! ✔
Looking for runtime 3.0.0-preview8-28405-07
Removing: /home/clanderas/.dotnet/shared/Microsoft.NETCore.App/3.0.0-preview8-28405-07 Done! ✔

```

## -> Warning, don't clean all runtimes prior to cleaning all sdks

## **List sdks**

```
dotnet-tarball-cleanup sdks list
```

**Output**
```
Installed SDKs ✔
2.2.401 ➡ /home/clanderas/.dotnet/sdk
3.0.100-preview6-012264 ➡ /home/clanderas/.dotnet/sdk
3.0.100-preview7-012821 ➡ /home/clanderas/.dotnet/sdk
3.0.100-preview8-013656 ➡ /home/clanderas/.dotnet/sdk

```

## **List runtimes**

```
dotnet-tarball-cleanup runtimes list
```

**Output**
```
Installed runtimes ✔
2.2.6 ➡ [Microsoft.AspNetCore.All | Microsoft.AspNetCore.App | Microsoft.NETCore.App]
3.0.0-preview6.19307.2 ➡ [Microsoft.AspNetCore.App]
3.0.0-preview7.19365.7 ➡ [Microsoft.AspNetCore.App]
3.0.0-preview8.19405.7 ➡ [Microsoft.AspNetCore.App]
3.0.0-preview6-27804-01 ➡ [Microsoft.NETCore.App]
3.0.0-preview7-27912-14 ➡ [Microsoft.NETCore.App]
3.0.0-preview8-28405-07 ➡ [Microsoft.NETCore.App]

```








