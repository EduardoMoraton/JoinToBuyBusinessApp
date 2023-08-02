using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JoinToBuyBusinessApp.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace JoinToBuyBusinessApp
{

    class MainWindowVM : ObservableRecipient
    {
        private UserControl currUserControl;

        public UserControl CurrUserControl
        {
            get { return currUserControl; }
            set { SetProperty(ref currUserControl, value);  }
        }

        // Services

        NavService navService;

        // Commands

        public RelayCommand ItemsCommand { get; set; }
        public RelayCommand OffersCommand { get; set; }
        public RelayCommand HomeCommand { get; set; }
        public RelayCommand SentCommand { get; set; }


        public MainWindowVM()
        {
            InitServices();
            InitVM();
            InitCommands();
        }

        private void InitServices()
        {
            navService = new NavService();
        }

        private void InitVM()
        {
            bool inside = navService.Login();

            if (inside)
                currUserControl = navService.GoItemsUserControl();
            else
                Application.Current.Shutdown();
        }

        private void InitCommands()
        {
            ItemsCommand = new RelayCommand(ItemsCommandFun);
            OffersCommand = new RelayCommand(OfferCommandFun);
            SentCommand = new RelayCommand(SentCommandFun);
        }

        // Command Functions

        private void OfferCommandFun()
        {
            CurrUserControl = navService.GoOffersUserContro();
        }

        private void ItemsCommandFun()
        {
            CurrUserControl = navService.GoItemsUserControl();
        }


        private void SentCommandFun()
        {
            CurrUserControl = navService.GoSentUserControl();
        }

    }
}
