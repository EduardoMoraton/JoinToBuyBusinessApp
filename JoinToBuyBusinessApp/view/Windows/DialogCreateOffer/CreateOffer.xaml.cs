using JoinToBuyBusinessApp.model;
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

namespace JoinToBuyBusinessApp.view.Windows.DialogCreateOffer
{
    /// <summary>
    /// Lógica de interacción para CreateOffer.xaml
    /// </summary>
    public partial class CreateOffer : Window
    {
        private CreateOfferVM vm;
        public CreateOffer()
        {
            InitializeComponent();
            vm = new CreateOfferVM();
            this.DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Offer off = vm.api.PostOffer(vm.CurrOffer);
            if (vm.CurrItem.ItemsImgsCollection.Count() > 0)
            {
                foreach (ItemsImg itemImg in vm.CurrItem.ItemsImgsCollection)
                {
                    string imgstring = vm.imgUtils.DownloadAndConvertToBase64(itemImg.UrlImg);
                    vm.api.PostOfferImage(off.Id, false, imgstring);
                }
            }
        }
    }
}
