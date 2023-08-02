using JoinToBuyBusinessApp.view.UserControls.Items;
using JoinToBuyBusinessApp.view.UserControls.Offers;
using JoinToBuyBusinessApp.view.UserControls.Sent;
using JoinToBuyBusinessApp.view.Windows.DialogCreateOffer;
using JoinToBuyBusinessApp.view.Windows.DialogLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToBuyBusinessApp.services
{
    class NavService
    {

        ItemsUserControl itemsUserControl;
        OffersUserControl offersUserControl;
        SentUserControl sentUserControl;


        public ItemsUserControl GoItemsUserControl()
        {
            if (itemsUserControl is null)
            {
                itemsUserControl = new ItemsUserControl();
            }
            return itemsUserControl;
        }

        public OffersUserControl GoOffersUserContro()
        {
            if (offersUserControl is null)
            {
                offersUserControl = new OffersUserControl();
            }
            return offersUserControl;
        }

        public SentUserControl GoSentUserControl()
        {
            if (sentUserControl is null)
            {
                sentUserControl = new SentUserControl();
            }
            return sentUserControl;
        }



        public bool Login()
        {
            return new LoginDialog().ShowDialog() ?? false;
        }

        public bool CreateOffer()
        {
            return new CreateOffer().ShowDialog() ?? false;
        }
    }
}
