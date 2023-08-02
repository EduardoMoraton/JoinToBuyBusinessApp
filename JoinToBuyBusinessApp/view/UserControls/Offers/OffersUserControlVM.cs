using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JoinToBuyBusinessApp.model;
using JoinToBuyBusinessApp.services;
using JoinToBuyBusinessApp.services.network;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToBuyBusinessApp.view.UserControls.Offers
{
    class OffersUserControlVM : ObservableRecipient
    {
        private ObservableCollection<Offer> offerList;

        public ObservableCollection<Offer> OfferList
        {
            get { return offerList; }
            set { SetProperty(ref offerList, value); }
        }

        private Offer currOffer;

        public Offer CurrOffer
        {
            get { return currOffer; }
            set { SetProperty(ref currOffer, value); }
        }





        // Services

        NavService navService;
        JTBAPIService api;
        AlertService alertService;
        ImgUtils imgUtils;

        // Commands

        public RelayCommand TrashOffer { get; set; }
        public RelayCommand RefreshCommand { get; set; }
        

        public OffersUserControlVM()
        {
            InitServices();
            InitVM();
            InitCommands();
        }

        private void InitServices()
        {
            navService = new NavService();
            api = new JTBAPIService();
            imgUtils = new ImgUtils();
            alertService = new AlertService();
        }

        private void InitVM()
        {
            CurrOffer = new Offer();
            CurrOffer.Id = 0;
        }

        private void InitCommands()
        {
            TrashOffer = new RelayCommand(TrashOfferFun);

            RefreshCommand = new RelayCommand(RefreshCommandFun);
        }

        private void RefreshCommandFun()
        {
            try
            {
                this.OfferList = api.GetOffers();
            }
            catch (Exception)
            {

                alertService.MsgBoxError("Algo salió mal");
            }
            
        }

        private void TrashOfferFun()
        {
            try
            {
                if (CurrOffer.Id != 0)
                {
                    api.DeleteOffer(CurrOffer.Id);
                    this.OfferList = api.GetOffers();
                }
                
            }
            catch (Exception)
            {

                alertService.MsgBoxError("Algo salió mal");
            }
        }
    }
}
