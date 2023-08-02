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
    class Offer : ObservableObject
    {
        private string details;
        [JsonProperty("details")]
        public string Details
        {
            get { return details; }
            set { SetProperty(ref details, value); }
        }

        private int id;
        [JsonProperty("id")]
        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private Bsn idBsn;
        [JsonProperty("idBsn")]
        public Bsn IdBsn
        {
            get { return idBsn; }
            set { SetProperty(ref idBsn, value); }
        }


        private User idUsr;
        [JsonProperty("idUsr")]
        public User IdUsr
        {
            get { return idUsr; }
            set { SetProperty(ref idUsr, value); }
        }

        private float newPrice;
        [JsonProperty("newPrice")]
        public float NewPrice
        {
            get { return newPrice; }
            set { SetProperty(ref newPrice, value); }
        }

        private ObservableCollection<OfferImage> offersImgsCollection;
        [JsonProperty("offersImgsCollection")]
        public ObservableCollection<OfferImage> OffersImgsCollection
        {
            get { return offersImgsCollection; }
            set { SetProperty(ref offersImgsCollection, value); }
        }

        private float oldPrice;
        [JsonProperty("oldPrice")]
        public float OldPrice
        {
            get { return oldPrice; }
            set { SetProperty(ref oldPrice, value); }
        }

        private string title;
        [JsonProperty("title")]
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private ObservableCollection<UsrGroup> usrGroupsCollection;
        public ObservableCollection<UsrGroup> UsrGroupsCollection
        {
            get { return usrGroupsCollection; }
            set { SetProperty(ref usrGroupsCollection, value); }
        }
    }
}
