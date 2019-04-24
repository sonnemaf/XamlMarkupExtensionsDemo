using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace XamlMarkupExtensionsDemo.MarkupExtensions {
    /// <summary>
    ///    <Grid Background="{helpers:GradientBrush Start=Red, Stop=Green}">
    /// </summary>
    [MarkupExtensionReturnType(ReturnType = typeof(GradientBrush))]
    public class GradientBrushExtension : MarkupExtension {

        public Color Start { get; set; }

        public Color Stop { get; set; }

        /// <summary>
        /// Gets or sets the starting two-dimensional coordinates of the linear gradient.
        ///
        /// Returns:
        ///     The starting two-dimensional coordinates for the linear gradient. The default
        ///     is a Point with value 0,0.
        /// </summary>
        public Point StartPoint { get; set; } = new Point(0.5, 0);

        /// <summary>
        /// Summary:
        ///     Gets or sets the ending two-dimensional coordinates of the linear gradient.
        ///
        /// Returns:
        ///     The ending two-dimensional coordinates of the linear gradient. The default is
        ///     a Point with value 1,1.
        /// </summary>
        public Point EndPoint { get; set; } = new Point(0.5, 1);

        protected override object ProvideValue() {
            var gb = new LinearGradientBrush() {
                StartPoint = this.StartPoint,
                EndPoint = this.EndPoint,
            };
            gb.GradientStops.Add(new GradientStop() {
                Color = Start,
            });
            gb.GradientStops.Add(new GradientStop() {
                Color = Stop,
                Offset = 1,
            });
            return gb;
        }
    }
}
