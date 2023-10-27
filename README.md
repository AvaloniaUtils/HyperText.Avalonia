# HyperText.Avalonia

Little control for big links


![](photo.jpg)

>   dotnet add package HyperText.Avalonia 


[![nuget](https://img.shields.io/badge/hypertext-nuget-blue)](https://www.nuget.org/packages/HyperText.Avalonia/) or download this repo.

For using

Add control in View
Now hyperlink works as a button and you may set any option for it command.
If you need to continue open url in browser -> check the example MainViewModel in src.


```xml
   <controls:Hyperlink Alias="{Binding Alias}" Url="{Binding Url}"  Command="{Binding $parent[Window].DataContext.OpenUrl}" />
```

Add style in App.xaml

```xml
   <avalonia:HyperLinkStyle/>
```

---
Special thanks for ![Tako](https://github.com/Takoooooo)
