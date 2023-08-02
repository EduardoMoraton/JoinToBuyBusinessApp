using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToBuyBusinessApp.model
{
    class Item : ObservableObject
    {

        private int id;
        [JsonProperty("id")]
        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private string title;
        [JsonProperty("title")]

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private string details;
        [JsonProperty("details")]
        public string Details
        {
            get { return details; }
            set { SetProperty(ref details, value); }
        }

        private float price;
        [JsonProperty("price")]
        public float Price
        {
            get { return price; }
            set { SetProperty(ref price, value); }
        }

        private int stock;
        [JsonProperty("stock")]
        public int Stock
        {
            get { return stock; }
            set { SetProperty(ref stock, value); }
        }


        private ObservableCollection<ItemsImg> itemsImgsCollection;
        [JsonProperty("itemsImgsCollection")]
        public ObservableCollection<ItemsImg> ItemsImgsCollection
        {
            get { return itemsImgsCollection; }
            set { SetProperty(ref itemsImgsCollection, value); }
        }


    }
}
