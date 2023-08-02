using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToBuyBusinessApp.model
{
    class Bsn : ObservableObject
    {
        private string email;
        [JsonProperty("email")]
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        private string idNum;
        [JsonProperty("idNum")]
        public string IdNum
        {
            get { return idNum; }
            set { SetProperty(ref idNum, value); }
        }

        private string name;
        [JsonProperty("name")]
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string pass;
        [JsonProperty("pass")]
        public string Pass
        {
            get { return pass; }
            set { SetProperty(ref pass, value); }
        }

    }
}
