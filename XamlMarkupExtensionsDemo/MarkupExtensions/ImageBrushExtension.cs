using System;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace XamlMarkupExtensionsDemo.MarkupExtensions {
    /// <summary>
    ///     <Grid Background="{helpers:ImageBrush Source='ms-appx:///Assets/StoreLogo.png' }">
    /// </summary>
    [MarkupExtensionReturnType(ReturnType = typeof(ImageBrush))]
    public class ImageBrushExtension : MarkupExtension {

        public string Source { get; set; }

        protected override object ProvideValue() {
            return new ImageBrush() {
                ImageSource = new BitmapImage {
                    UriSource = new Uri(Source),
                }
            };
        }
    }
}
