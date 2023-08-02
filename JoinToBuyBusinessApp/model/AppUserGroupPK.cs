using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToBuyBusinessApp.model
{
    class AppuserGroupPK : ObservableObject
    {
        private int idGroup;
        [JsonProperty("idGroup")]
        public int IdGroup
        {
            get { return idGroup; }
            set { SetProperty(ref idGroup, value); }
        }

        private int idUser;
        [JsonProperty("idUser")]
        public int IdUser
        {
            get { return idUser; }
            set { SetProperty(ref idUser, value); }
        }
    }
}
