# `sokol`.NET

[![Build, test, and deploy status](https://img.shields.io/azure-devops/build/lustranks/sokol-sharp/lithiumtoast.sokol-sharp/master?label=build%2Ftest%2Fdeploy&logo=azure-pipelines)](https://dev.azure.com/lustranks/sokol-csharp/_build/latest?definitionId=4&branchName=master)

A .NET wrapper for https://github.com/floooh/sokol.

Includes the C style API precisely as it is and a .NET style API for convenience.

[`sokol_gfx`](https://github.com/floooh/sokol#sokol_gfxh) is a modern and simple 3D graphics API. To learn more about `sokol` and it's philosophy, see the [*A Tour of `sokol_gfx.h`*](https://floooh.github.io/2017/07/29/sokol-gfx-tour.html) blog post, written Andre Weissflog, the owner of `sokol`. 

## C API

The [P/Invoke](https://docs.microsoft.com/en-us/dotnet/framework/interop/consuming-unmanaged-dll-functions) bindings are a pure port of the C headers; they exactly match what is in C, and the naming conventions used in C are maintained.

The C structs in C# are blittable, meaning they have the [same memory layout as the C structs](https://docs.microsoft.com/en-us/dotnet/framework/interop/blittable-and-non-blittable-types). This allows the structs to be passed by value (copy of data) or reference (akin to copy of pointer) from the managed world of .NET to the unmanaged world of C [as is](https://docs.microsoft.com/en-us/dotnet/framework/interop/copying-and-pinning#formatted-blittable-classes).

In .NET, the `unsafe` keyword will most often be necessary for using the C structs and calling the C functions. Also, for practicality, it's recommended to import the module with all the bindings, structs, and enums like so:

```cs
using static sokol_gfx;
```

To learn how to use the C API, check out the [official C samples](https://github.com/floooh/sokol-samples). You can also find the same examples that run in [your browser](https://floooh.github.io/sokol-html5/index.html). The comments in the [`sokol_gfx.h`](https://github.com/floooh/sokol/blob/master/sokol_gfx.h) file are also a good reference.

## .NET API

The .NET style API is a modification of the C bindings (from the side of .NET) to be more idiomatic and overall easier to use. The `unsafe` keyword is not required.

The .NET API currently targets [.NET Core 3.1 (LTS)](https://devblogs.microsoft.com/dotnet/announcing-net-core-3-1/). One the reasons is to use `System.Numerics` for `Vector2`, `Vector3`, `Matrix4x4`, etc and `System.Memory` for `Span<T>`, `Memory<T>`, etc. By using these, the code required remains small, highly performant, and easy to use without re-inventing the wheel. Another reason to use .NET Core is easy cross platform support for desktop platforms and soon mobile, browser, and console platforms. More about platforms in the next section.

All the types are [.NET value types](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/value-types). This is to get as close as possible to zero allocations on the managed heap during the long running state of the application's loop. [This is often desirable in games](https://www.shawnhargreaves.com/blog/twin-paths-to-garbage-collector-nirvana.html) and [other demanding, high performance, applications](https://docs.microsoft.com/en-us/dotnet/csharp/write-safe-efficient-code).

### Samples

To learn how to use the .NET API, check out the [samples](htree/master/src/Samples), which are in sync with the official [C samples](https://github.com/floooh/sokol-samples).

The following is a table of the same .NET API samples ordered by their complexity.

Name|Description|GIF/Screenshot
:---:|:---:|:---:
[Clear](src/Samples/Sokol.Graphics.Samples.Clear/Sokol.Graphics.Samples.Clear/ClearApplication.cs)|[Clears the frame buffer with a specific color](src/Samples/Sokol.Graphics.Samples.Clear/Sokol.Graphics.Samples.Clear/ClearApplication.cs).|<img src="screenshots/gifs/clear.gif" width="300">
[Triangle](src/Samples/Sokol.Graphics.Samples.Triangle/Sokol.Graphics.Samples.Triangle/Application.cs)|[Draw a triangle in clip space](src/Samples/Sokol.Graphics.Samples.Triangle/Sokol.Graphics.Samples.Triangle/Application.cs).|<img src="screenshots/gifs/triangle.gif" width="300">
[Quad](src/Samples/Sokol.Graphics.Samples.Quad/Sokol.Graphics.Samples.Quad/Application.cs)|[Draw a quad in clip space](src/Samples/Sokol.Graphics.Samples.Quad/Sokol.Graphics.Samples.Quad/Application.cs).|<img src="screenshots/gifs/quad.gif" width="300">

## Supported Platforms & 3D APIs

Since `sokol_gfx` is a C library technically any platform is possible. However, currently only desktop platforms (Windows, macOS, and Linux) are supported with `Sokol.NET` by using .NET Core 3.1. In November 2020, `Sokol.NET` will move to .NET 5 and support mobile (iOS, Android), browser (WebAssembly), consoles (Nintendo Switch, Xbox One, PlayStation 4), and micro-consoles (tvOS). See [.NET 5 annoucement as the next .NET Core that will unify desktop, mobile, browser, consoles, and other platforms](https://devblogs.microsoft.com/dotnet/introducing-net-5/).

[`sokol_gfx`](https://github.com/floooh/sokol#sokol_gfxh) converges old and modern graphics APIs to one simple and easy to use API. To learn more about the convergence of modern 3D graphics APIs (such as Metal, DirectX11/12, and WebGPU) and how they compare to legacy APIs (such as OpenGL), see *[A Comparison of Modern Graphics APIs](https://alain.xyz/blog/comparison-of-modern-graphics-apis)* blog written by Alain Galvan, a graphics software engineer.

The following is a table of platforms that are known to work and their supported graphics API backends with `sokol_gfx` in C.

Platform vs 3D API|OpenGL|OpenGLES|Direct3D11|Direct3D12|Metal|Vulkan|WebGPU
:---|:---:|:---:|:---:|:---:|:---:|:---:|:---:
Desktop Windows|✅|❌|✅|⭕|❌|⭕|❌
Desktop macOS|❗|❌|❌|❌|✅|⭕|❌
Desktop Linux|✅|❌|❌|❌|❌|⭕|❌
Mobile iOS|❌|❌|❌|❌|✅|⭕|❌
Mobile Android|❌|✅|❌|❌|❌|⭕|❌
Browser WebAssembly|❌|✅|❌|❌|❌|❌|🚧
Micro-console tvOS|❌|❌|❌|❌|✅|❌|❌
Console Nintendo Switch|✅|❌|❌|❌|❌|⭕|❌
Console Xbox One|❌|❌|✅|⭕|❌|❌|❌
Console PlayStation 4|✅|❌|❌|❌|❌|⭕|❌

- ⭕ means the graphics API is supported on the platform but not by `sokol_gfx`.
- 🚧 means the graphics API will be supported by `sokol_gfx` but is currently under construction (from `sokol` side).
- ❗ means the graphics API is deprecated on that platform but can still work with `sokol_gfx`. OpenGL is deprecated for macOS. It is recommended to only use Metal for macOS if hardware supports it. All Apple platforms support Metal.

## NuGet

To get the NuGet packages, add the following feed: `https://www.myget.org/F/lithiumtoast/api/v3/index.json`

Name|Description
:---|:---:
[`Sokol.App`](https://www.myget.org/feed/lithiumtoast/package/nuget/Sokol.App)|Application framework for `sokol_gfx` using SDL2. Similar to MonoGame.
[`Sokol.Graphics`](https://www.myget.org/feed/lithiumtoast/package/nuget/Sokol.Graphics)|PInvoke code for `sokol_gfx`.
[`Sokol.Graphics.OpenGL`](https://www.myget.org/feed/lithiumtoast/package/nuget/Sokol.Graphics.OpenGL)|PInvoke code for getting `sokol_gfx` working with OpenGL.
[`Sokol.Graphics.OpenGL.Native`](https://www.myget.org/feed/lithiumtoast/package/nuget/Sokol.Graphics.OpenGL.Native)|Shared libraries for getting `sokol_gfx` working with OpenGL.
[`Sokol.Graphics.Metal`](https://www.myget.org/feed/lithiumtoast/package/nuget/Sokol.Graphics.Metal)|PInvoke code for getting `sokol_gfx` working with Metal.
[`Sokol.Graphics.Metal.Native`](https://www.myget.org/feed/lithiumtoast/package/nuget/Sokol.Graphics.Metal)|Shared libraries for getting `sokol_gfx` working with Metal.
[`Sokol.SDL2`](https://www.myget.org/feed/lithiumtoast/package/nuget/Sokol.SDL2)|PInvoke code for getting `sokol_gfx` working with SDL2.
[`Sokol.SDL2.Native`](https://www.myget.org/feed/lithiumtoast/package/nuget/Sokol.SDL2.Native)|Shared libraries for getting `sokol_gfx` working with SDL2.

## General Learning Resources

All the linked resources in this section are 100% free and easily accessible from a modern browser (some have interactive tutorials).

#### Know some programming but new to game development?

- https://gameprogrammingpatterns.com/contents.html

#### New to or need a refresher on vectors and matrices?

- http://immersivemath.com

#### Don't know what are "Model View Projection" matrices or how they work?

- http://www.codinglabs.net/article_world_view_projection_matrix.aspx

#### Confused about fragment shaders or want to learn how to create cool shader effects?

- https://thebookofshaders.com

## Contributing

You want to contribute? Awesome! To get started please read the [CONTRIBUTING](CONTRIBUTING) file for details on our code of conduct, and the process for submitting pull requests.

## Versioning

`Sokol.NET` uses [calendar versioning](https://calver.org) and [semantic versioning](https://semver.org) where appropriate. For example, the version scheme used for native shared libraries such as `sokol_gfx` is `YYYY.MM.DD` and the version scheme for `Sokol.NET` is `MAJOR.MINOR.PATCH-TAG`. For a complete list of the versions available, see the [tags on this repository](https://github.com/lithiumtoast/Sokol.NET/tags).

## License

`Sokol#` is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Authors

- **Lucas Girouard-Stranks** [@lithiumtoast](https://github.com/lithiumtoast) *Owner*
