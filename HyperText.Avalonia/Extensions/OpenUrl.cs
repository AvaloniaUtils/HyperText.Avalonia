using System.Diagnostics;
using System.Runtime.InteropServices;
using HyperText.Avalonia.Exceptions;

namespace HyperText.Avalonia.Extensions
{
    public static class OpenUrlExtension
    {
        private static bool IsValidUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) return false;
            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute)) return false;
            if (!Uri.TryCreate(url, UriKind.Absolute, out var tmp)) return false;
            return tmp.Scheme == Uri.UriSchemeHttp || tmp.Scheme == Uri.UriSchemeHttps;
        }

        public static void OpenUrl(this string url)
        {
            if (!IsValidUrl(url)) throw new InvalidUrlException("invalid url: " + url);
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                //https://stackoverflow.com/a/2796367/241446
                using var proc = new Process { StartInfo = { UseShellExecute = true, FileName = url } };
                proc.Start();

                return;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start("x-www-browser", url);
                return;
            }

            if (!RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) throw new InvalidUrlException("invalid url: " + url);
            Process.Start("open", url);
            return;
        }
    }
}