
using ResearchesMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.IO;


namespace ResearchesMVC.Services.UploadHelper
{
    public class UploadHelper
    {
        public string? fileName;
        public string? Message;

        private BaseService<Order>? _service;
       
        //public async Task<string> UploadFile(IFormFile file)
        //{
        //    fileName = "";
        //    if (file == null)
        //        return "";

        //    var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
        //    fileName = DateTime.Now.Ticks + extension;

        //    var content = new MultipartFormDataContent();
        //    content.Add(new StreamContent(await file.OpenReadAsync()), "file", fileName);
        //    var httpClient = new HttpClient();

        //    //"http://192.168.212.193/api/Orders/imageupload";
        //    string urlUpload = "Orders/imageupload";
        //    _service = new BaseService<Order>();
        //    string url = _service.GetURL(urlUpload);

        //    httpClient.BaseAddress = new Uri(url);
        //    var response = await httpClient.PostAsync("", content);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        Message = "تم الرفع بنجاح";
        //        ReturnMessage();
             
             
        //    }
        //    return fileName;
        //}
        public string ReturnMessage()
        {
            return Message;
        }
        //public async Task<ImageSource> GetImage(string imgName)
        //{
        //    ImageSource imgSource=null;
        //    var httpClient = new HttpClient();
        //  //  string url = "http://192.168.212.193/api/Orders/GetImage/" + imgName;
        //    string urlUpload = $"Orders/GetImage/{imgName}";
        //    _service = new BaseService<Order>();
        //    string url = _service.GetURL(urlUpload);
        //    httpClient.BaseAddress = new Uri(url);
        //    var response = await httpClient.GetAsync("");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        string content = await response.Content.ReadAsStringAsync();
        //        var byteArray = Convert.FromBase64String(content);
        //        Stream stream = new MemoryStream(byteArray);
        //         imgSource = ImageSource.FromStream(() => stream);
        //        // img.Source = imgSource;
        //    }
        //    return imgSource;
        //}
    }
}
