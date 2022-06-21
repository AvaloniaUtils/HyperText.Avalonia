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

        public static readonly DirectProperty<Hyperlink, string> AliasProperty
            = AvaloniaProperty.RegisterDirect<Hyperlink, string>(nameof(Alias), o => o.Alias, (o, v) => o.Alias = v);

        private string _alias;

        public string Url
        {
            get => _url;
            set
            {
                SetAndRaise(UrlProperty, ref _url, value);
                if (string.IsNullOrEmpty(_alias))
                {
                    Text = _url;
                }
                if (!string.IsNullOrEmpty(_url))
                {
                   Classes.Add("hyperlink");
                }
            }
        }


        public string Alias
        {
            get => Text;
            set
            {
                SetAndRaise(UrlProperty, ref _alias, value);
                if (string.IsNullOrEmpty(_alias))
                {
                    Text = _url;
                }
                else
                {
                    Text = _alias;
                }
            }
        }

        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);
            if (!string.IsNullOrEmpty(Url))
                Url.OpenUrl();
        }
    }
}