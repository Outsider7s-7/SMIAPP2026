using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SMIAPP2026.Shared.Services;
using SMIAPP2026.Web.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add device-specific services used by the SMIAPP2026.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

await builder.Build().RunAsync();
