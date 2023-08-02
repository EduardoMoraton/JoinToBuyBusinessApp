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

namespace JoinToBuyBusinessApp.view.UserControls.Offers
{
    /// <summary>
    /// Lógica de interacción para OffersUserControl.xaml
    /// </summary>
    public partial class OffersUserControl : UserControl
    {
        private OffersUserControlVM vm;
        public OffersUserControl()
        {
            InitializeComponent();
            vm = new OffersUserControlVM();
            this.DataContext = vm;
        }
    }
}
