using JoinToBuyBusinessApp.model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToBuyBusinessApp.services.network
{
    class JTBAPIService
    {
        private string endpoint;
        private string cookie;
        public JTBAPIService()
        {
            this.endpoint = Properties.Settings.Default.endpoint;
            this.cookie = Properties.Settings.Default.cookie;
        }


        public Boolean Login(Bsn bsn)
        {
            string url = $"http://{endpoint}";

            var client = new RestClient(url);
            var request = new RestRequest("bsn/login", Method.Post);
            string data = JsonConvert.SerializeObject(bsn);
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            MensajeAPI res = new MensajeAPI();
            var response = client.Execute<MensajeAPI>(request);

            if (response.IsSuccessful)
            {
                // Handle the successful response
                res = response.Data;
                string cookieValue = response.Cookies[0].ToString();
                Properties.Settings.Default.cookie = cookieValue;
            }
            else
            {
                // Handle the failed response
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
            }

            return res.Mensaje == "Session Iniciada";
               
        }

        public ObservableCollection<Item> GetItems()
        {
            string url = $"http://{endpoint}";
            ObservableCollection<Item> list = null;

            var client = new RestClient(url);
            var request = new RestRequest("bsn/items", Method.Get);
 
            request.AddParameter("Cookie", cookie, ParameterType.HttpHeader);
           
            var response = client.Execute<ObservableCollection<Item>>(request);


            if (response.IsSuccessful)
            {
                // Handle the successful response
                list = response.Data;


            }
            else
            {
                // Handle the failed response
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
            }

            return list;
        }

        public ObservableCollection<Offer> GetOffers()
        {
            string url = $"http://{endpoint}";
            ObservableCollection<Offer> list = null;

            var client = new RestClient(url);
            var request = new RestRequest("bsn/offers", Method.Get);

            request.AddParameter("Cookie", cookie, ParameterType.HttpHeader);

            var response = client.Execute<ObservableCollection<Offer>>(request);


            if (response.IsSuccessful)
            {
                // Handle the successful response
                list = response.Data;


            }
            else
            {
                // Handle the failed response
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
            }

            return list;
        }


        public bool PutItem(Item item)
        {
            string url = $"http://{endpoint}";
            MensajeAPI res = null;

            var client = new RestClient(url);
            var request = new RestRequest("bsn/items", Method.Put);

            request.AddParameter("Cookie", cookie, ParameterType.HttpHeader);
            string data = JsonConvert.SerializeObject(item);
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            var response = client.Execute<MensajeAPI>(request);


            if (response.IsSuccessful)
            {
                // Handle the successful response
                res = response.Data;


            }
            else
            {
                // Handle the failed response
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
            }

            return res.Mensaje == "OK";
        }

        public Item PostItem(Item item)
        {
            string url = $"http://{endpoint}";
            Item res = null;

            var client = new RestClient(url);
            var request = new RestRequest("bsn/items", Method.Post);

            request.AddParameter("Cookie", cookie, ParameterType.HttpHeader);
            string data = JsonConvert.SerializeObject(item);
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            var response = client.Execute<Item>(request);


            if (response.IsSuccessful)
            {
                // Handle the successful response
                res = response.Data;


            }
            else
            {
                // Handle the failed response
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
            }

            return res;
        }

        public bool PostItemImage(int itemId, bool isMain, string base64Data)
        {
            string url = $"http://{endpoint}";
            MensajeAPI responseMessage = null;

            var client = new RestClient(url);
            var request = new RestRequest($"bsn/items/img?id_item={itemId}&is_main={isMain}", Method.Post);

            request.AddParameter("Cookie", cookie, ParameterType.HttpHeader);
           
            request.AddParameter("application/text", base64Data, ParameterType.RequestBody);
            var response = client.Execute<MensajeAPI>(request);

            if (response.IsSuccessful)
            {
                // Handle the successful response
                responseMessage = response.Data;
            }
            else
            {
                // Handle the failed response
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
            }

            return responseMessage.Mensaje == "OK";
        }

        public bool DeleteImage(int itemId)
        {
            string url = $"http://{endpoint}";
            MensajeAPI responseMessage = null;

            var client = new RestClient(url);
            var request = new RestRequest($"bsn/items/img?id_item={itemId}", Method.Delete);

            request.AddParameter("Cookie", cookie, ParameterType.HttpHeader);

            var response = client.Execute<MensajeAPI>(request);

            if (response.IsSuccessful)
            {
                // Handle the successful response
                responseMessage = response.Data;
            }
            else
            {
                // Handle the failed response
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
            }

            return responseMessage.Mensaje == "OK";
        }

        public bool DeleteItem(int itemId)
        {
            string url = $"http://{endpoint}";
            MensajeAPI responseMessage = null;

            var client = new RestClient(url);
            var request = new RestRequest($"bsn/items?id_item={itemId}", Method.Delete);

            request.AddParameter("Cookie", cookie, ParameterType.HttpHeader);

            var response = client.Execute<MensajeAPI>(request);

            if (response.IsSuccessful)
            {
                // Handle the successful response
                responseMessage = response.Data;
            }
            else
            {
                // Handle the failed response
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
            }

            return responseMessage.Mensaje == "OK";
        }

        public string uploadPic(string b64)
        {
            string url = $"http://{endpoint}";
            MensajeAPI res = null;

            var client = new RestClient(url);
            var request = new RestRequest("azure/upload", Method.Post);

            request.AddParameter("text/plain", b64, ParameterType.RequestBody);

            var response = client.Execute<MensajeAPI>(request);


            if (response.IsSuccessful)
            {
                // Handle the successful response
                res = response.Data;


            }
            else
            {
                // Handle the failed response
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
            }

            return res.Mensaje;
        }


        public Offer PostOffer(Offer offer)
        {
            string url = $"http://{endpoint}";
            Offer res = null;

            var client = new RestClient(url);
            var request = new RestRequest("off/offers", Method.Post);

            request.AddParameter("Cookie", cookie, ParameterType.HttpHeader);
            string data = JsonConvert.SerializeObject(offer);
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            var response = client.Execute<Offer>(request);


            if (response.IsSuccessful)
            {
                // Handle the successful response
                res = response.Data;


            }
            else
            {
                // Handle the failed response
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
            }

            return res;
        }

        public bool PostOfferImage(int offerId, bool isMain, string base64Data)
        {
            string url = $"http://{endpoint}";
            MensajeAPI responseMessage = null;

            var client = new RestClient(url);
            var request = new RestRequest($"off/img?offer_id={offerId}&is_main={isMain}", Method.Post);

            request.AddParameter("Cookie", cookie, ParameterType.HttpHeader);

            request.AddParameter("application/text", base64Data, ParameterType.RequestBody);
            var response = client.Execute<MensajeAPI>(request);

            if (response.IsSuccessful)
            {
                // Handle the successful response
                responseMessage = response.Data;
            }
            else
            {
                // Handle the failed response
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
            }

            return responseMessage.Mensaje == "OK";
        }

        public bool DeleteOffer(int offerId)
        {
            string url = $"http://{endpoint}";
            MensajeAPI responseMessage = null;

            var client = new RestClient(url);
            var request = new RestRequest($"off/offers?offer_id={offerId}", Method.Delete);

            request.AddParameter("Cookie", cookie, ParameterType.HttpHeader);

            var response = client.Execute<MensajeAPI>(request);

            if (response.IsSuccessful)
            {
                // Handle the successful response
                responseMessage = response.Data;
            }
            else
            {
                // Handle the failed response
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
            }

            return responseMessage.Mensaje == "OK";
        }




    }
}
