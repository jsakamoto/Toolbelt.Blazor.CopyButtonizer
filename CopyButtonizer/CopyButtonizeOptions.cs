namespace Toolbelt.Blazor.CopyButtonizer;

public class CopyButtonizeOptions
{
    public Func<IServiceProvider, string>? GetTitle { get; set; }

    public Func<IServiceProvider, CopyButtonPosition>? GetPosition { get; set; }
}
