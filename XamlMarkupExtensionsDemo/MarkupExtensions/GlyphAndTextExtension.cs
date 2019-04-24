using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace XamlMarkupExtensionsDemo.MarkupExtensions {

    [MarkupExtensionReturnType(ReturnType = typeof(TextBlock))]
    public class GlyphAndTextExtension : MarkupExtension {

        public string Glyph { get; set; }
        public double GlyphFontSize { get; set; } = 14;
        public string Text { get; set; }
        public FontFamily FontFamily { get; set; } = new FontFamily("Segoe MDL2 Assets");

        protected override object ProvideValue() {
            var tb = new TextBlock();
            tb.Inlines.Add(new Run {
                Text = this.Glyph,
                FontSize = this.GlyphFontSize,
                FontFamily = this.FontFamily,
            });
            tb.Inlines.Add(new Run { Text = " " + this.Text });
            return tb;
        }
    }
}
