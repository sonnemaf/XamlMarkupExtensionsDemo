using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace XamlMarkupExtensionsDemo.MarkupExtensions {


    /// <summary>
    /// Source: https://www.pedrolamas.com/2019/03/31/making-the-case-for-xaml-markup-extensions/
    /// </summary>
    [MarkupExtensionReturnType(ReturnType = typeof(FontIcon))]
    public class FontIconExtension : MarkupExtension {

        public string Glyph { get; set; }

        public FontFamily FontFamily { get; set; } = new FontFamily("Segoe MDL2 Assets");

        protected override object ProvideValue() {
            return new FontIcon() {
                Glyph = this.Glyph,
                FontFamily = this.FontFamily,
            };
        }
    }
}
