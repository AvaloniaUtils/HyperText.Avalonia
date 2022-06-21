using System.Collections.Generic;
using HyperText.Avalonia.Models;

namespace HyperText.Avalonia.Example.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public IEnumerable<HyperlinkContent> HyperlinkContentProvider => new[]
        {
            new HyperlinkContent
                { Alias = "dedede         ", Url = "https://docs.avaloniaui.net/docs/styling/styles" },
            new HyperlinkContent { Alias = "edvyydebbvydebvyed    " },
            new HyperlinkContent { Url = "https://docs.avaloniaui.net/docs/styling/styles" }
        };
    }
}