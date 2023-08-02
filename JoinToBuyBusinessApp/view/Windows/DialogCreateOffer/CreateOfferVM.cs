using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using JoinToBuyBusinessApp.messaging;
using JoinToBuyBusinessApp.model;
using JoinToBuyBusinessApp.services;
using JoinToBuyBusinessApp.services.network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToBuyBusinessApp.view.Windows.DialogCreateOffer
{
    class CreateOfferVM : ObservableRecipient
    {
        private Offer currOffer;

        public Offer CurrOffer
        {
            get { return currOffer; }
            set { SetProperty(ref currOffer, value); }
        }

        private Item item;

        public Item CurrItem
        {
            get { return item; }
            set { SetProperty(ref item, value); }
        }

        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }


        public RelayCommand CalculateCommand { get; set; }

        public AlertService alertService;
        public JTBAPIService api;
        public ImgUtils imgUtils;

        public CreateOfferVM()
        {
            InitServices();
            manageMessages();
            InitVm();
            
        }

        private void InitServices()
        {
            api = new JTBAPIService();
            alertService = new AlertService();
            imgUtils = new ImgUtils();
        }

        private void manageMessages()
        {
            CurrItem = WeakReferenceMessenger.Default.Send<OfferValueRequestMessage>();
        }

        private void InitVm()
        {
            CurrOffer = new Offer();
            Quantity = 1;
            CurrOffer.Title = CurrItem.Title;
            CurrOffer.Details = CurrItem.Details;
            CurrOffer.OldPrice = CurrItem.Price * Quantity;
            CurrOffer.NewPrice = CurrOffer.OldPrice;
            CalculateCommand = new RelayCommand(CalculateCommandFun);
        }

        private void CalculateCommandFun()
        {
            
            CurrOffer.OldPrice = Quantity * CurrItem.Price;
        }
    }
}
