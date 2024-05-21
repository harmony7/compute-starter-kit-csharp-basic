# Basic Starter Kit for C#

by Katsuyuki Omuro

Get to know [HarmonicBytes.FastlyCompute](https://github.com/harmony7/dotnet-compute),
an SDK for running .NET code on [Fastly Compute](https://www.fastly.com/documentation/guides/compute/),
with a basic starter in C# that demonstrates simple synthetic responses.

> [!WARNING]
> Use at your own risk. This is a personal project that I'm working on in
> my free time. It's not owned or sponsored by Fastly, so please don't try
> to contact them for support with it. If you need help, please visit the
> [GitHub project page](https://github.com/harmony7/dotnet-compute).

## Features

* Get information about the request
* Build synthetic responses at the edge

## Prerequisites

In addition to the [Fastly CLI](https://www.fastly.com/documentation/reference/tools/cli/), you will need the following:

* .NET 8 SDK
  > (This will NOT work with .NET 9.)
    * Obtain it at the [.NET 8 Downloads Page](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
    * The SDK package is all you need, it includes all the tooling as well as the runtime.

* WASI SDK
    * Obtain the release for your platform on the [wasi-sdk GitHub releases Page](https://github.com/WebAssembly/wasi-sdk/releases)
    * Extract it to some permanent location on your computer (I like `/opt/wasi-sdk`).
    * Add an environment variable `WASI_SDK_PATH` pointing to the extracted directory.

* WASI-Experimental workload for .NET 8
    * `dotnet workload install wasi-experimental`

* (optional) binaryen - This is optional and if it exists the WASI SDK will use it to optimize your Wasm builds.
    * [Release Page](`https://github.com/WebAssembly/binaryen/releases`)
    * Extract it somewhere and add it to your `PATH`.
    * Alternatively, if you're using macOS with [Homebrew](https://brew.sh), you can use `brew install binaryen`.

## Understanding the code

This starter is intentionally lightweight, and requires no dependencies aside from the `HarmonicBytes.FastlyCompute`
NuGet package. It will help you understand the basics of processing requests at the edge using Fastly.

The starter doesn't require the use of any backends. Once deployed, you will have a Fastly service running on Compute
that can generate synthetic responses at the edge.

When building this project, the `scripts.build` entry in `fastly.toml` calls the .NET 8 toolchain (which in turn invokes
the WASI SDK) to build a `.wasm` file from `Program.cs`. It then copies this file to `bin/main.wasm` for bundling into a
`.tar.gz` file ready for deployment to Compute.

For more details on how the library works, visit the SDK's
[GitHub project](https://github.com/harmony7/dotnet-compute/blob/main/docs/index.md).

> [!NOTE]
> There are limitations are the current time, either those imposed by the platform or due to not yet being implemented.
> See [Limitations](https://github.com/harmony7/dotnet-compute/blob/main/src/HarmonicBytes.FastlyCompute/README.md#limitations).

## LICENSE

[Apache 2.0](https://github.com/harmony7/dotnet-compute/LICENSE)

Copyright 2024 Katsuyuki Omuro

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
