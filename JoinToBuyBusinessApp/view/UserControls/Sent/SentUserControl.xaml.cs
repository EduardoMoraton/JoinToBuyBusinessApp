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

namespace JoinToBuyBusinessApp.view.UserControls.Sent
{
    /// <summary>
    /// Lógica de interacción para SentUserControl.xaml
    /// </summary>
    public partial class SentUserControl : UserControl
    {
        private SentUserControlVM vm;
        public SentUserControl()
        {
            InitializeComponent();
            vm = new SentUserControlVM();
            this.DataContext = vm;
        }
    }
}
