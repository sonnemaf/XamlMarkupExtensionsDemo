using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace XamlMarkupExtensionsDemo.MarkupExtensions {

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


    [MarkupExtensionReturnType(ReturnType = typeof(KeyboardAccelerator))]
    public class KeyboardAcceleratorExtension : MarkupExtension {

        //
        // Summary:
        //     Gets or sets the virtual key used to modify another keypress for a keyboard shortcut
        //     (accelerator).
        //
        // Returns:
        //     The virtual key.
        public VirtualKeyModifiers Modifiers { get; set; }

        //
        // Summary:
        //     Gets or sets the virtual key (used in conjunction with one or more modifier keys)
        //     for a keyboard shortcut (accelerator).
        //
        // Returns:
        //     The virtual key.
        public VirtualKey Key { get; set; }

        protected override object ProvideValue() {
            return new KeyboardAccelerator() {
                Key = this.Key,
                Modifiers = this.Modifiers,
            };
        }

        #region KeyboardAccelerator Attached Property

        /// <summary> 
        /// Identifies the KeyboardAccelerator attachted property. This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty KeyboardAcceleratorProperty =
            DependencyProperty.RegisterAttached("KeyboardAccelerator",
                                                typeof(UIElement),
                                                typeof(KeyboardAcceleratorExtension),
                                                new PropertyMetadata(default(object), OnKeyboardAcceleratorChanged));

        /// <summary>
        /// KeyboardAccelerator changed handler. 
        /// </summary>
        /// <param name="d">FrameworkElement that changed its KeyboardAccelerator attached property.</param>
        /// <param name="e">DependencyPropertyChangedEventArgs with the new and old value.</param> 
        private static void OnKeyboardAcceleratorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            if (d is FrameworkElement source) {
                var value = (KeyboardAccelerator)e.NewValue;
                source.KeyboardAccelerators.Add(value);
            }
        }

        /// <summary>
        /// Gets the value of the KeyboardAccelerator attached property from the specified FrameworkElement.
        /// </summary>
        public static object GetKeyboardAccelerator(DependencyObject obj) {
            return (object)obj.GetValue(KeyboardAcceleratorProperty);
        }


        /// <summary>
        /// Sets the value of the KeyboardAccelerator attached property to the specified FrameworkElement.
        /// </summary>
        /// <param name="obj">The object on which to set the KeyboardAccelerator attached property.</param>
        /// <param name="value">The property value to set.</param>
        public static void SetKeyboardAccelerator(DependencyObject obj, object value) {
            obj.SetValue(KeyboardAcceleratorProperty, value);
        }

        #endregion KeyboardAccelerator Attached Property


    }
}
