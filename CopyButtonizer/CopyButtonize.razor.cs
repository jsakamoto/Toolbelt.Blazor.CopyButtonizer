using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;

namespace Toolbelt.Blazor.CopyButtonizer;

public partial class CopyButtonize : IAsyncDisposable
{
    [Inject] private IServiceProvider ServiceProvider { get; init; } = null!;

    [Inject] private IJSRuntime JSRuntime { get; init; } = null!;

    [Parameter] public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public string? Title
    {
        get { return this._Title ?? this._Options.GetTitle?.Invoke(this.ServiceProvider); }
        set { this._Title = value; }
    }

    [Parameter]
    public CopyButtonPosition Position
    {
        get { return this._Position ?? this._Options.GetPosition?.Invoke(this.ServiceProvider) ?? CopyButtonPosition.Bottom; }
        set { this._Position = value; }
    }

    [Parameter] public string? Class { get; set; }

    [Parameter] public string? ContainerStyle { get; set; }

    [Parameter] public string? ButtonStyle { get; set; }

    [Parameter] public EventCallback Copied { get; set; }

    private ElementReference _Container;

    private IJSObjectReference? _JSModule;

    private CopyButtonizeOptions _Options = new();

    private string? _Title;

    private CopyButtonPosition? _Position;


    protected override void OnInitialized()
    {
        this._Options = this.ServiceProvider.GetService<CopyButtonizeOptions>() ?? new();
    }

    private string GetClassString()
    {
        return $"copy-buttonize copy-buttonize-pos-{this.Position.ToString().ToLower()} {this.Class}".TrimEnd();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            this._JSModule = await this.JSRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Toolbelt.Blazor.CopyButtonizer/CopyButtonize.razor.js");
        }
    }

    private async Task OnClickCopyButton()
    {
        this._JSModule?.InvokeVoidAsync("copyToClipboard", this._Container);
        await this.Copied.InvokeAsync();
    }

    public async ValueTask DisposeAsync()
    {
        if (this._JSModule != null) await this._JSModule.DisposeAsync();
    }
}

