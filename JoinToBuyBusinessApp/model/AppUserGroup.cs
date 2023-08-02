using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToBuyBusinessApp.model
{
    class AppuserGroup : ObservableObject
    {
        private User appUsers;
        [JsonProperty("appUsers")]

        public User AppUsers
        {
            get { return appUsers; }
            set { SetProperty(ref appUsers, value); }
        }

        private AppuserGroupPK appuserGroupPK;
        [JsonProperty("appuserGroupPK")]
        public AppuserGroupPK AppuserGroupPK
        {
            get { return appuserGroupPK; }
            set { SetProperty(ref appuserGroupPK, value); }
        }

        private bool isLead;
        [JsonProperty("isLead")]
        public bool IsLead
        {
            get { return isLead; }
            set { SetProperty(ref isLead, value); }
        }

        private bool paid;
        [JsonProperty("paid")]
        public bool Paid
        {
            get { return paid; }
            set { SetProperty(ref paid, value); }
        }
    }
}
