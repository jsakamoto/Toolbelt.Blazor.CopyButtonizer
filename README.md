# Blazor Copy Buttonizer [![NuGet Package](https://img.shields.io/nuget/v/Toolbelt.Blazor.CopyButtonizer.svg)](https://www.nuget.org/packages/Toolbelt.Blazor.CopyButtonizer/)

## Summary

This is a component for Blazor apps to append "Copy to clipboard" button.

![movie.1](https://raw.githubusercontent.com/jsakamoto/Toolbelt.Blazor.CopyButtonizer/main/.assets/movie.001.gif)

## Installation

1. Add the "Toolbelt.Blazor.CopyButtonizer" NuGet package to your Blazor application project.

```shell
dotnet add package Toolbelt.Blazor.CopyButtonizer
```

2. To be convinience, open the `Toolbelt.Blazor.CopyButtonizer` name space globally.

```razor
@* _Import.razor *@
...
@* 👇 Open this name space. *@
@using Toolbelt.Blazor.CopyButtonizer
```

## Usage

Surround the contents what you want to add "Copy to clipboard" button with a `<CopyButtonize>` component.

```html
@* *.razor *@
...
<CopyButtonize>
  <input type="text" .../>
</CopyButtonize>
...
```

After doing that, the button to copy to the clipboard will be appended to the child's contents, which the `CopyButtonize` component surrounds.

![fig.1](https://raw.githubusercontent.com/jsakamoto/Toolbelt.Blazor.CopyButtonizer/main/.assets/fig.1.png)


## API

`CopyButtonize` component exposes the following properties.


Property Name  | Type               | Description
---------------|--------------------|---------------
Title          | string             | Specify the tooltip text of the "copy to clipboard" button.
Position       | CopyButtonPosition | Specify the layout position of the "copy to clipboard" button. (The default value is "Bottom".)
Class          | string             | Specify the CSS class name that will apply to the container element of the `CopyButtonize` component.
ContainerStyle | string             | Specify the inline styles that will apply to the container element of the `CopyButtonize` component.
ButtonStyle    | string             | Specify the inline styles that will apply to the button element of the `CopyButtonize` component.
Copied         | EventCallback      | Specify the event handler when copying to clipboard was fired.


## Configure default settings

You can configure the default settings of the `CopyButtonize` component globally in your start-up code. (See the following example.)


```csharp
// Program.cs

// 👇 Open these name spaces.
using Toolbelt.Blazor.CopyButtonizer;
using Toolbelt.Blazor.Extensions.DependencyInjection;
...
var builder = WebAssemblyHostBuilder.CreateDefault(args);
...

// 👇 Call "AddCopyButtonizeOptions()" method 
//    to configure the "CopyButtonize" component's options globally.
builder.Services.AddCopyButtonizeOptions(options =>
{
    options.GetTitle = services => "Copy to clipboard.";
    options.GetPosition = services => CopyButtonPosition.Top;
});
...
```


## Supported versions

Both Blazor WebAssembly and Blazor Server apps on .NET 6 or later are supported.

## Release notes

The release notes is [here](https://github.com/jsakamoto/Toolbelt.Blazor.CopyButtonizer/blob/main/RELEASE-NOTES.txt).

## License

[Mozilla Public License Version 2.0](https://github.com/jsakamoto/Toolbelt.Blazor.CopyButtonizer/blob/main/LICENSE)
