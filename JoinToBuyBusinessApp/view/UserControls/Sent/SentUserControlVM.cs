using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JoinToBuyBusinessApp.model;
using JoinToBuyBusinessApp.services;
using JoinToBuyBusinessApp.services.network;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JoinToBuyBusinessApp.view.UserControls.Sent
{
    class SentUserControlVM : ObservableRecipient
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

        private UsrGroup currGroup;

        public UsrGroup CurrGroup
        {
            get { return currGroup; }
            set { SetProperty(ref currGroup, value); }
        }
        


        private ObservableCollection<string> statusList;

        public ObservableCollection<string> StatusList
        {
            get { return statusList; }
            set { SetProperty(ref statusList, value); }
        }

        // Services

        NavService navService;
        JTBAPIService api;
        AlertService alertService;
        ImgUtils imgUtils;
        PdfGeneratorService pdf;

        // Commands

        public RelayCommand ApplyStateCommand { get; set; }
        public RelayCommand GetQRCommand { get; set; }
        public RelayCommand RefreshCommand { get; set; }


        public SentUserControlVM()
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
            pdf = new PdfGeneratorService();
        }

        private void InitVM()
        {
            CurrOffer = new Offer();
            CurrOffer.Id = 0;
            StatusList = new ObservableCollection<string>();
            StatusList.Add("open");
            StatusList.Add("processing");
            StatusList.Add("sent");
            StatusList.Add("delivered");
        }

        private void InitCommands()
        {
            ApplyStateCommand = new RelayCommand(ApplyStateCommandFun);
            GetQRCommand = new RelayCommand(GetQRCommandFun);
            RefreshCommand = new RelayCommand(RefreshCommandFun);
        }

        private void GetQRCommandFun()
        {
            if (CurrOffer.Id != 0)
            {
                try
                {
                    bool allpaid = true;
                    foreach (AppuserGroup user in CurrGroup.AppuserGroupCollection)
                    {
                        allpaid = user.Paid;
                    }

                    if (allpaid)
                    {
                        User master = null;
                        foreach (AppuserGroup user in CurrGroup.AppuserGroupCollection)
                        {
                            if (user.IsLead)
                            {
                                master = user.AppUsers;
                            }
                        }
                        pdf.GeneratePdfWithQRCode(master.Name, master.Email, master.Address, master.Zip, CurrGroup.Id.ToString(), master.Id.ToString());
                    } else
                    {
                        alertService.MsgBox("Not all the users said that will pay");
                    }
                }
                catch (Exception)
                {

                    alertService.MsgBoxError("Something bad happened, try again later");
                }
            }
        }

        private void ApplyStateCommandFun()
        {
            
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

       
    }
}
