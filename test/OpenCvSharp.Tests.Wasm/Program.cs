using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OpenCvSharp.Tests.Wasm;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

await builder.Build().RunAsync();
