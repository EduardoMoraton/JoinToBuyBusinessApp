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

namespace JoinToBuyBusinessApp.view.Windows.DialogLogin
{
    class LoginDialogVM : ObservableRecipient
    {
        private Bsn currBsn;

        public Bsn CurrBsn
        {
            get { return currBsn; }
            set { SetProperty(ref currBsn, value); }
        }

        private bool remember;

        public bool Remember
        {
            get { return remember; }
            set { remember = value; }
        }


 


        // Commands
        public RelayCommand LoginCommand { get; set; }

        // Services


        NavService navService;
        AlertService alertService;
        public JTBAPIService api;
        PdfGeneratorService pdf;


        public LoginDialogVM()
        {
            InitServices();
            InitVM();
            InitCommands();
        }

        private void InitServices()
        {
            navService = new NavService();
            alertService = new AlertService();
            api = new JTBAPIService();
        }

        private void InitVM()
        {
            CurrBsn = new Bsn();
            Remember = Properties.Settings.Default.remember;
            if (Remember)
            {
                CurrBsn.Email = Properties.Settings.Default.email;
                CurrBsn.IdNum = Properties.Settings.Default.idbsn;
                currBsn.Pass = Properties.Settings.Default.pass;
            }
        }

        private void InitCommands()
        {
            LoginCommand = new RelayCommand(LoginCommandFun);

        }

        private void LoginCommandFun()
        {
            if (api.Login(currBsn))
            {

                alertService.MsgBox("You are loged in");
               
            } else
            {
                alertService.MsgBoxError("Something went wrong");
            }
               
        }
    }
}
