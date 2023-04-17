using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Styling;


namespace HyperText.Avalonia;

public class HyperLinkStyle : AvaloniaObject, IStyle, IResourceProvider
{
    private readonly IStyle _controlsStyles;
    private bool _isLoading;
    private IStyle? _loaded;

    /// <summary>
    /// Initializes a new instance of the <see cref="FluentTheme"/> class.
    /// </summary>
    /// <param name="baseUri">The base URL for the XAML context.</param>
    public HyperLinkStyle(Uri? baseUri)
    {
        _controlsStyles = new StyleInclude(baseUri)
        {
            Source = new Uri("avares://HyperText.Avalonia/Styles/HyperlinkStyle.axaml")
        };
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FluentTheme"/> class.
    /// </summary>
    /// <param name="serviceProvider">The XAML service provider.</param>
    public HyperLinkStyle(IServiceProvider serviceProvider)
        : this(((IUriContext)serviceProvider.GetService(typeof(IUriContext)))?.BaseUri)
    {
    }


    public IResourceHost? Owner => (Loaded as IResourceProvider)?.Owner;

    /// <summary>
    /// Gets the loaded style.
    /// </summary>
    public IStyle Loaded
    {
        get
        {
            if (_loaded != null) return _loaded!;
            _isLoading = true;

            _loaded = new Styles() { _controlsStyles };

            _isLoading = false;

            return _loaded!;
        }
    }

    public bool TryGetResource(object key, ThemeVariant? theme, out object? value)
    {
        if (!_isLoading && Loaded is IResourceProvider p)
        {
            return p.TryGetResource(key,theme, out value);
        }

        value = null;
        return false;
    }

    bool IResourceNode.HasResources => (Loaded as IResourceProvider)?.HasResources ?? false;
    IReadOnlyList<IStyle> IStyle.Children => _loaded?.Children ?? Array.Empty<IStyle>();

    public event EventHandler OwnerChanged
    {
        add
        {
            if (Loaded is IResourceProvider rp)
            {
                rp.OwnerChanged += value;
            }
        }
        remove
        {
            if (Loaded is IResourceProvider rp)
            {
                rp.OwnerChanged -= value;
            }
        }
    }





    void IResourceProvider.AddOwner(IResourceHost owner) => (Loaded as IResourceProvider)?.AddOwner(owner);
    void IResourceProvider.RemoveOwner(IResourceHost owner) => (Loaded as IResourceProvider)?.RemoveOwner(owner);

    private CancellationTokenSource? _currentCancellationTokenSource;
    private Task? _currentThemeUpdateTask;
}