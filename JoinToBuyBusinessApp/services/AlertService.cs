using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JoinToBuyBusinessApp.services
{
    class AlertService
    {
        public bool MsgBox(string text)
        {
            MessageBoxResult result = MessageBox.Show(text, "OK", MessageBoxButton.OK, MessageBoxImage.Information);

            if (result == MessageBoxResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool MsgBoxError(string mensajeError)
        {
            MessageBoxResult result = MessageBox.Show(mensajeError, "OK", MessageBoxButton.OK, MessageBoxImage.Error);

            return true;
        }
    }
}
