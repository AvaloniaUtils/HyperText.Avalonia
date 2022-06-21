using System;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Input;
using Avalonia.LogicalTree;
using Avalonia.Media;
using HyperText.Avalonia.Controls;

namespace HyperText.Avalonia.Example.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        protected override void OnOpened(EventArgs e)
        {
            /*var res = this.Find<ItemsControl>("myItems");
            var temp = res?.GetLogicalChildren();
            if (temp != null)
            {
                foreach (var logical in temp)
                {
                    var item = (ContentPresenter)logical;
                    if (item.Content is Models.HyperlinkContent content && item.Child is Hyperlink hyperlink)
                    {
                        var isAliasEmpty = string.IsNullOrEmpty(content.Alias);
                        var isUrlEmpty = string.IsNullOrEmpty(content.Url);
                        if (isAliasEmpty && !isUrlEmpty)
                        {
                            hyperlink.Text = content.Url;
                        }
                        else if (!isAliasEmpty && isUrlEmpty)
                        {
                            hyperlink.Foreground = new SolidColorBrush(Color.Parse("Black"));
                            hyperlink.TextDecorations = new TextDecorationCollection();
                            hyperlink.Cursor = new Cursor(StandardCursorType.Arrow);
                        }
                    }
                }
            }*/

            base.OnOpened(e);
        }
    }
}