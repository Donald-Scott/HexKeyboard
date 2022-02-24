using Keyboard.KbdBtn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HexKeyboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<KeyboardBtn> shiftSensitiveButtons;
        private List<KeyboardBtn> capsSinsitiveButtons;
        private List<KeyboardBtn> modifierKeys;

        public MainWindow()
        {
            shiftSensitiveButtons = new List<KeyboardBtn>();
            capsSinsitiveButtons = new List<KeyboardBtn>();
            modifierKeys = new List<KeyboardBtn>();

            InitializeComponent();
            Loaded += MainWindowLoaded;
        }

        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            AddHandler(KeyboardBtn.ModifierChangedEvent, new ModifierChangedEventHandler(ModifierKeyChanged), true);

            foreach (UIElement child in MainGrid.Children)
            {
                if (child is KeyboardBtn)
                {
                    SaveKeyboardButton(child as KeyboardBtn);
                }
                if (child is Panel)
                {
                    Panel panel = child as Panel;
                    foreach (UIElement decendent in panel.Children)
                    {
                        if (!(decendent is KeyboardBtn))
                        {
                            continue;
                        }

                        SaveKeyboardButton(decendent as KeyboardBtn);
                    }
                }
            }

            foreach (KeyboardBtn btn in modifierKeys)
            {
                btn.SynchroniseKeyState();
            }
        }

        private void ModifierKeyChanged(object sender, ModifierChangedEventArgs e)
        {
            switch (e.virtualKeyCode)
            {
                case VirtualKeyCode.Shift:
                    if (e.IsInEffect)
                    {
                        ProcessShiftInEffect();
                    }
                    else
                    {
                        ProcessShiftNotInEffect();
                    }
                    break;
                case VirtualKeyCode.Capital:
                    if (e.IsInEffect)
                    {
                        ProcessCapsInEffect();
                    }
                    else
                    {
                        ProcessCapsNotInEffect();
                    }
                    break;
            }

        }

        private void ProcessShiftInEffect()
        {
            foreach (KeyboardBtn btn in shiftSensitiveButtons)
            {
                object modifiedContent = btn.GetValue(KeyProperties.ModifiedContentProperty);
                btn.SetValue(ContentProperty, modifiedContent);
            }
            foreach (KeyboardBtn btn in capsSinsitiveButtons)
            {
                object modifiedContent = btn.GetValue(KeyProperties.ModifiedContentProperty);
                btn.SetValue(ContentProperty, modifiedContent);
            }
        }

        private void ProcessShiftNotInEffect()
        {
            foreach (KeyboardBtn btn in shiftSensitiveButtons)
            {
                object unmodifiedContent = btn.GetValue(KeyProperties.UnmodifiedContentProperty);
                btn.SetValue(ContentProperty, unmodifiedContent);
            }
            foreach (KeyboardBtn btn in capsSinsitiveButtons)
            {
                object unmodifiedContent = btn.GetValue(KeyProperties.UnmodifiedContentProperty);
                btn.SetValue(ContentProperty, unmodifiedContent);
            }
        }

        private void ProcessCapsInEffect()
        {
            foreach (KeyboardBtn btn in capsSinsitiveButtons)
            {
                object modifiedContent = btn.GetValue(KeyProperties.ModifiedContentProperty);
                btn.SetValue(ContentProperty, modifiedContent);
            }
        }

        private void ProcessCapsNotInEffect()
        {
            foreach (KeyboardBtn btn in capsSinsitiveButtons)
            {
                object unmodifiedContent = btn.GetValue(KeyProperties.UnmodifiedContentProperty);
                btn.SetValue(ContentProperty, unmodifiedContent);
            }
        }

        private void SaveKeyboardButton(KeyboardBtn btn)
        {
            if (btn.KeyBehaviour == KeyBehaviour.InstantaneousModifier || btn.KeyBehaviour == KeyBehaviour.TogglingModifier)
            {
                modifierKeys.Add(btn);
            }

            ModifierSensitivity sensitiveType = (ModifierSensitivity)btn.GetValue(KeyProperties.SensitivityTypeProperty);
            switch (sensitiveType)
            {
                case ModifierSensitivity.Caps:
                    capsSinsitiveButtons.Add(btn as KeyboardBtn);
                    //shiftSensitiveButtons.Add(decendent as KeyboardBtn);
                    break;
                case ModifierSensitivity.Shift:
                    shiftSensitiveButtons.Add(btn as KeyboardBtn);
                    break;
            }
        }

        private void KebboardSwapClick(object sender, RoutedEventArgs e)
        {
            if(alphaGrid.Visibility == Visibility.Visible)
            {
                alphaGrid.Visibility = Visibility.Collapsed;
                symbolGrid.Visibility = Visibility.Visible;
            }
            else
            {
                alphaGrid.Visibility = Visibility.Visible;
                symbolGrid.Visibility = Visibility.Collapsed;
            }
        }
    }
}
