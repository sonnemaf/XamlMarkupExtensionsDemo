using System;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace XamlMarkupExtensionsDemo.MarkupExtensions {
    /// <summary>
    ///     <Grid Background="{me:ImageBrush Source='ms-appx:///Assets/StoreLogo.png' }">
    /// </summary>
    [MarkupExtensionReturnType(ReturnType = typeof(ImageBrush))]
    public class ImageBrushExtension : MarkupExtension {

        public string Source { get; set; }
        public Stretch Stretch { get; set; } = Stretch.Fill;
        public double Opacity { get; set; } = 1.0;

        protected override object ProvideValue() {
            return new ImageBrush() {
                Stretch = this.Stretch,
                Opacity = this.Opacity,
                ImageSource = new BitmapImage {
                    UriSource = new Uri(Source),
                }
            };
        }
    }
}
