using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToBuyBusinessApp.model
{
    class ItemsImg : ObservableObject
    {
        private int id;
        [JsonProperty("id")]
        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private bool isMain;
        [JsonProperty("isMain")]
        public bool IsMain
        {
            get { return isMain; }
            set { SetProperty(ref isMain, value); }
        }

        private string urlImg;
        [JsonProperty("urlImg")]
        public string UrlImg
        {
            get { return urlImg; }
            set { SetProperty(ref urlImg, value); }
        }
    }
}