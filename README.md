[![NuGet version (dotnet_tarball_cleanup)](https://img.shields.io/nuget/v/dotnet-tarball-cleanup.svg?style=flat-square)](https://www.nuget.org/packages/dotnet-tarball-cleanup/) [![Build status](https://ci.appveyor.com/api/projects/status/804re7py0d5a6qs3/branch/master?svg=true)](https://ci.appveyor.com/project/CarlosLanderas/dotnet-tarball-cleanup)

# Dotnet Tarball Cleanup Global Tool

## A simple global tool for Linux to list and remove sdks and runtimes when installed from tarballs using dotnet-install scripts

This tool is a work in progress, and has only been tested in Manjaro Linux

### Installation:

```
dotnet tool install dotnet-tarball-cleanup --global
```

## Instructions:

Be sure your DOTNET_ROOT environment variable is pointing to the installation folder created by dotnet-install scripts

Example:

```
DOTNET_ROOT=/home/clanderas/.dotnet
```


## Usage:


### **Remove sdk by version**
```
 dotnet-tarball-cleanup sdks remove --version 2.2.401
```

**Output**
```
Looking for sdk 2.2.401
Removing: /home/clanderas/.dotnet/sdk/2.2.401 Done! ✔
Sdk 2.2.401 removed ✔
```

### **Remove runtime by version**
```
 dotnet-tarball-cleanup runtimes remove --version 2.2.6
```

**Output**
```
Looking for runtime 2.2.6
Removing: /home/clanderas/.dotnet/shared/Microsoft.AspNetCore.All/2.2.6 Done! ✔
```

### **Remove runtimes matching regex**

Dotnet and AspNetCore runtimes have different minor versions so using a regex makes easier to clean all of them:

```
dotnet-tarball-cleanup runtimes remove -r 3.0.0-preview5
```
**Output**
```
Removing runtimes using regex: 3.0.0-preview5
Removing: /home/clanderas/.dotnet/shared/Microsoft.AspNetCore.App/3.0.0-preview5-19227-01 Done! ✔
Removing: /home/clanderas/.dotnet/shared/Microsoft.NETCore.App/3.0.0-preview5-27626-15 Done! ✔
```

### **Remove all sdks**
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

### **Remove all runtimes**
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

### **List sdks**

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

### **List runtimes**

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








