using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using HyperText.Avalonia.Extensions;

namespace HyperText.Avalonia.Controls
{
    public class Hyperlink : TextBlock
    {
        public static readonly DirectProperty<Hyperlink, string> UrlProperty
            = AvaloniaProperty.RegisterDirect<Hyperlink, string>(nameof(Url), o => o.Url, (o, v) => o.Url = v);

        private string _url;

        public string Url
        {
            get => _url;
            set => SetAndRaise(UrlProperty, ref _url, value);
        }

        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);
            if (!string.IsNullOrEmpty(Url))
                Url.OpenUrl();
        }
    }
}