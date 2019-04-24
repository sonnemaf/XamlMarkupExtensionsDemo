using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;

namespace XamlMarkupExtensionsDemo.MarkupExtensions {
    [MarkupExtensionReturnType(ReturnType = typeof(KeyboardAccelerator))]
    public class KeyboardAcceleratorExtension : MarkupExtension {

        /// <summary> 
        /// Identifies the KeyboardAccelerator attachted property. This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty KeyboardAcceleratorProperty =
            DependencyProperty.RegisterAttached("KeyboardAccelerator",
                                                typeof(UIElement),
                                                typeof(KeyboardAcceleratorExtension),
                                                new PropertyMetadata(default(object), OnKeyboardAcceleratorChanged));

        //
        // Summary:
        //     Gets or sets the virtual key (used in conjunction with one or more modifier keys)
        //     for a keyboard shortcut (accelerator).
        //
        // Returns:
        //     The virtual key.
        public VirtualKey Key { get; set; }

        //
        // Summary:
        //     Gets or sets the virtual key used to modify another keypress for a keyboard shortcut
        //     (accelerator).
        //
        // Returns:
        //     The virtual key.
        public VirtualKeyModifiers Modifiers { get; set; }

        /// <summary>
        /// Gets the value of the KeyboardAccelerator attached property from the specified FrameworkElement.
        /// </summary>
        public static object GetKeyboardAccelerator(DependencyObject obj) {
            return (object)obj.GetValue(KeyboardAcceleratorProperty);
        }

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

        protected override object ProvideValue() {
            return new KeyboardAccelerator() {
                Key = this.Key,
                Modifiers = this.Modifiers,
            };
        }


        /// <summary>
        /// Sets the value of the KeyboardAccelerator attached property to the specified FrameworkElement.
        /// </summary>
        /// <param name="obj">The object on which to set the KeyboardAccelerator attached property.</param>
        /// <param name="value">The property value to set.</param>
        public static void SetKeyboardAccelerator(DependencyObject obj, object value) {
            obj.SetValue(KeyboardAcceleratorProperty, value);
        }

    }
}
