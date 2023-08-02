using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToBuyBusinessApp.model
{

    class User : ObservableObject
    {
        private string address;
        [JsonProperty("address")]
        public string Address
        {
            get { return address; }
            set { SetProperty(ref address, value); }
        }

        private string email;
        [JsonProperty("email")]
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        private int id;
        [JsonProperty("id")]
        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private double locLat;
        [JsonProperty("locLat")]
        public double LocLat
        {
            get { return locLat; }
            set { SetProperty(ref locLat, value); }
        }

        private double locLng;
        [JsonProperty("locLng")]
        public double LocLng
        {
            get { return locLng; }
            set { SetProperty(ref locLng, value); }
        }

        private string name;
        [JsonProperty("name")]
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string zip;
        [JsonProperty("zip")]
        public string Zip
        {
            get { return zip; }
            set { SetProperty(ref zip, value); }
        }
    }
}
