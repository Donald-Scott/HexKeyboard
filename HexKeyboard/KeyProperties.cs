using System.Windows;

namespace HexKeyboard
{
    public static class KeyProperties
    {
        public static string GetUnmodifiedContent(DependencyObject obj)
        {
            return (string)obj.GetValue(UnmodifiedContentProperty);
        }

        public static void SetUnmodifiedContent(DependencyObject obj, string value)
        {
            obj.SetValue(UnmodifiedContentProperty, value);
        }

        // Using a DependencyProperty as the backing store for UnmodifiedContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UnmodifiedContentProperty =
            DependencyProperty.RegisterAttached("UnmodifiedContent", typeof(string), typeof(KeyProperties), new PropertyMetadata(""));


        public static string GetModifiedContent(DependencyObject obj)
        {
            return (string)obj.GetValue(ModifiedContentProperty);
        }

        public static void SetModifiedContent(DependencyObject obj, string value)
        {
            obj.SetValue(ModifiedContentProperty, value);
        }

        // Using a DependencyProperty as the backing store for ModifiedContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModifiedContentProperty =
            DependencyProperty.RegisterAttached("ModifiedContent", typeof(string), typeof(KeyProperties), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.Inherits));


        public static ModifierSensitivity GetSensitivityTyp(DependencyObject obj)
        {
            return (ModifierSensitivity)obj.GetValue(SensitivityTypeProperty);
        }

        public static void SetSensitivityType(DependencyObject obj, ModifierSensitivity value)
        {
            obj.SetValue(SensitivityTypeProperty, value);
        }

        // Using a DependencyProperty as the backing store for SensitivityTyp.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SensitivityTypeProperty =
            DependencyProperty.RegisterAttached("SensitivityType", typeof(ModifierSensitivity), typeof(KeyProperties), new FrameworkPropertyMetadata(ModifierSensitivity.None));
    }
}
