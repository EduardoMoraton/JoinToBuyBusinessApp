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
using System.Windows.Shapes;

namespace JoinToBuyBusinessApp.view.Windows.DialogLogin
{
    /// <summary>
    /// Lógica de interacción para LoginDialog.xaml
    /// </summary>
    public partial class LoginDialog : Window
    {
        private LoginDialogVM vm; 
        public LoginDialog()
        {
            InitializeComponent();
            vm = new LoginDialogVM();
            this.DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (vm.api.Login(vm.CurrBsn))
            {
                Properties.Settings.Default.remember = vm.Remember;
                Properties.Settings.Default.email = vm.CurrBsn.Email;
                Properties.Settings.Default.idbsn = vm.CurrBsn.IdNum;
                Properties.Settings.Default.pass = vm.CurrBsn.Pass;
                DialogResult = true;
            }
        }
    }

    public static class PasswordBoxHelper
    {
        public static readonly DependencyProperty BoundPasswordProperty =
            DependencyProperty.RegisterAttached("BoundPassword", typeof(string), typeof(PasswordBoxHelper), new PropertyMetadata(string.Empty, OnBoundPasswordChanged));

        private static bool _isUpdating;

        public static string GetBoundPassword(DependencyObject d)
        {
            return (string)d.GetValue(BoundPasswordProperty);
        }

        public static void SetBoundPassword(DependencyObject d, string value)
        {
            d.SetValue(BoundPasswordProperty, value);
        }

        private static void OnBoundPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is PasswordBox passwordBox))
                return;

            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            if (!_isUpdating)
            {
                passwordBox.Password = (string)e.NewValue;
            }

            passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
        }

        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!(sender is PasswordBox passwordBox))
                return;

            _isUpdating = true;
            SetBoundPassword(passwordBox, passwordBox.Password);
            _isUpdating = false;
        }
    }
}
