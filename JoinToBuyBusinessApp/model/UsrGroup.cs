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
    class UsrGroup : ObservableObject
    {
        private ObservableCollection<AppuserGroup> appuserGroupCollection;
        [JsonProperty("appuserGroupCollection")]
        public ObservableCollection<AppuserGroup> AppuserGroupCollection
        {
            get { return appuserGroupCollection; }
            set { SetProperty(ref appuserGroupCollection, value); }
        }

        private bool completed;
        [JsonProperty("completed")]
        public bool Completed
        {
            get { return completed; }
            set { SetProperty(ref completed, value); }
        }

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

        private string name;
        [JsonProperty("name")]
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string paymentInfo;
        [JsonProperty("paymentInfo")]
        public string PaymentInfo
        {
            get { return paymentInfo; }
            set { SetProperty(ref paymentInfo, value); }
        }

        private string status;
        [JsonProperty("status")]
        public string Status
        {
            get { return status; }
            set { SetProperty(ref status, value); }
        }
    }
}
