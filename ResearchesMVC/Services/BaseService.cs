using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Http;




namespace ResearchesMVC.Services
{
    public class BaseService<T> where T : class
    {


        private string baseUri = "http://192.168.40.193/api/";

        //.../api/Courses
        //..api/Categories
        public async Task<IEnumerable<T>?> GetRequestAsync(string uri)
        {
            baseUri += uri;

            var client = new RestClient(baseUri);
            var request = new RestRequest();
            var response = await client.ExecuteGetAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string json = response.Content;
                return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
            }

            return default;

        }
       
        public async Task<IEnumerable<T>?> GetByNameAsync(string uri)
        {
            baseUri += uri;

            var client = new RestClient(baseUri);
            var request = new RestRequest();
            var response = await client.ExecuteGetAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string json = response.Content;
                return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
            }

            return default;
        }
        public async Task<T?> GetByEmailAsync(string uri)
        {
            baseUri += uri;

            var client = new RestClient(baseUri);
            var request = new RestRequest();
            var response = await client.ExecuteGetAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string json = response.Content;
                return JsonConvert.DeserializeObject<T>(json);
            }

            return default;
        }

        public int GetLastOrders(string uri)
        {
            baseUri += uri;

            var client = new RestClient(baseUri);
            var request = new RestRequest();
            var response =  client.Execute(request);
          
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string json = response.Content;
                return JsonConvert.DeserializeObject<int>(json);            
            }

            return default;
        }
       
        public string GetURL(string uri)
        {
            baseUri += uri;
            return baseUri;
        }
        public async Task<bool> AddAsync(T entry, string uri)
        {
            baseUri += uri;

            var client = new RestClient();
            var request = new RestRequest(baseUri, Method.Post);
            request.AddJsonBody(entry);
            var res = await client.ExecuteAsync(request);
            if (res.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public async void UpdateAsync(int id, T entry, string uri)
        {
            baseUri += uri;
            var client = new RestClient();
            var request = new RestRequest(baseUri, Method.Put);
            request.AddJsonBody(entry);
            await client.ExecuteAsync(request);
        }
        public async void DeleteAsync(int id, string uri)
        {
            baseUri += uri;        
            var client = new RestClient();
            var request = new RestRequest(baseUri, Method.Delete);
            await client.ExecuteAsync(request);
        }

        //user login
        public async Task<bool> LoginAsync(T entry, string uri)
        {
            baseUri += uri;

            var client = new RestClient();
            var request = new RestRequest(baseUri, Method.Post);
            request.AddJsonBody(entry);
            var res = await client.ExecuteAsync(request);
            if (res.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
        //user register
        public async Task<bool> RegisterAsync(T entry, string uri)
        {
            baseUri += uri;

            var client = new RestClient();
            var request = new RestRequest(baseUri, Method.Post);
            request.AddJsonBody(entry);
            var res = await client.ExecuteAsync(request);
            if (res.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        //upload
        public async Task<string?> UploadFile(IFormFile file, string uri)
        {
            baseUri += uri;

            var client = new RestClient();
            var request = new RestRequest(baseUri, Method.Post);
            request.AddJsonBody(file);
            var res = await client.ExecuteAsync(request);
            if (res.StatusCode == HttpStatusCode.OK)
            {
                string json = res.Content;
                return JsonConvert.DeserializeObject<string>(json);
               // return true;
            }
           // return false;
            return default;
        }

       
    }
}
