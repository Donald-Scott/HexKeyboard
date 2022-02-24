using HexPanel;
using Keyboard.KbdBtn;
using System.Windows;
using System.Windows.Controls;

namespace HexKeyboard
{
    public class HexKebboardBtn : KeyboardBtn
    {
        static HexKebboardBtn()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HexKebboardBtn), new FrameworkPropertyMetadata(typeof(HexKebboardBtn)));
        }

        public static readonly DependencyProperty OrientationProperty = HexGrid.OrientationProperty.AddOwner(typeof(HexKebboardBtn));

        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }
    }
}
