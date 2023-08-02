using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using JoinToBuyBusinessApp.messaging;
using JoinToBuyBusinessApp.model;
using JoinToBuyBusinessApp.services;
using JoinToBuyBusinessApp.services.network;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToBuyBusinessApp.view.UserControls.Items
{
    class ItemsUserControlVM : ObservableRecipient
    {

       

        private ObservableCollection<Item> itemList;

        public ObservableCollection<Item> ItemList
        {
            get { return itemList; }
            set { SetProperty(ref itemList, value); }
        }

        private Item currItem;

        public Item CurrItem
        {
            get { return currItem; }
            set { SetProperty(ref currItem, value); }
        }





        // Services

        NavService navService;
        JTBAPIService api;
        ImgUtils imgUtils;

        // Commands

        public RelayCommand SaveToCloud { get; set; }
        public RelayCommand OpenImageCommand { get; set; }
        public RelayCommand ToOfferCommand { get; set; }
        public RelayCommand ApplyCommand { get; set; }
        public RelayCommand NewCommand { get; set; }
        public RelayCommand DeleteItemCommand { get; set; }
        public RelayCommand DeleteAllPhotosCommand { get; set; }
        


        public ItemsUserControlVM()
        {
            InitServices();
            InitVM();
            InitCommands();
            manageMessages();
        }

        private void manageMessages()
        {
            WeakReferenceMessenger.Default.Register<ItemsUserControlVM, OfferValueRequestMessage>(this, (r, m) =>
             {
                 m.Reply(CurrItem);
             });
        }

        private void InitServices()
        {
            navService = new NavService();
            api = new JTBAPIService();
            imgUtils = new ImgUtils();
        }

        private void InitVM()
        {
            CurrItem = new Item();
            CurrItem.ItemsImgsCollection = new ObservableCollection<ItemsImg>();
            CurrItem.Id = 0;
        }

        private void InitCommands()
        {
            SaveToCloud = new RelayCommand(SaveToCloudFun);
            OpenImageCommand = new RelayCommand(OpenImageCommandFun);
            ToOfferCommand = new RelayCommand(ToOfferCommandFun);
            ApplyCommand = new RelayCommand(ApplyCommandFun);
            NewCommand = new RelayCommand(NewCommandFun);
            DeleteAllPhotosCommand = new RelayCommand(DeleteAllPhotosCommandFun);
            DeleteItemCommand = new RelayCommand(DeleteItemCommandFun);
        }

        private void DeleteItemCommandFun()
        {
            if (CurrItem.Id != 0)
            {
                api.DeleteItem(CurrItem.Id);
                ItemList = api.GetItems();
            }
        }

        private void DeleteAllPhotosCommandFun()
        {
            CurrItem.ItemsImgsCollection = new ObservableCollection<ItemsImg>();
        }

        private void NewCommandFun()
        {
            CurrItem = new Item
            {
                ItemsImgsCollection = new ObservableCollection<ItemsImg>(),
                Id = 0
            };
        }

        private void ApplyCommandFun()
        {
            if (CurrItem.Id == 0)
            {
                ObservableCollection<ItemsImg> imgs = new ObservableCollection<ItemsImg>(CurrItem.ItemsImgsCollection);
                CurrItem.ItemsImgsCollection.Clear();
                Item newItem = api.PostItem(CurrItem);
                foreach (ItemsImg img in imgs)
                {
                    string b64 = imgUtils.DownloadAndConvertToBase64(img.UrlImg);
                    api.PostItemImage(newItem.Id, false, b64);
                }
                
            } else
            {
                ObservableCollection<ItemsImg> imgs = new ObservableCollection<ItemsImg>(CurrItem.ItemsImgsCollection);
                CurrItem.ItemsImgsCollection.Clear();
                api.PutItem(CurrItem);
                foreach (ItemsImg img in imgs)
                {
                    if (img.Id != 0)
                    {
                        api.DeleteImage(img.Id);
                    }
                    string b64 = imgUtils.DownloadAndConvertToBase64(img.UrlImg);
                    api.PostItemImage(CurrItem.Id, false, b64);
                }
            }
            ItemList = api.GetItems();
        }

        private void ToOfferCommandFun()
        {
            navService.CreateOffer();
        }

        private void OpenImageCommandFun()
        {
            string b64img = imgUtils.OpenImage();
            if (b64img!= null)
            {
                ItemsImg img = new ItemsImg();
                img.IsMain = false;
                img.UrlImg = api.uploadPic(b64img);
              
                CurrItem.ItemsImgsCollection.Add(img);
            }
        }

        // Command Functions

        private void SaveToCloudFun()
        { 
            ItemList = api.GetItems();
        }

    }
}
