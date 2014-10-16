using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using ITCR.Domain.Entities;
using ITCR.Domain.Exceptions;

namespace ITCR.Services.Classes
{
    public class DeathstarRESTClient : IDisposable
    {
        public const string API_POST_SKYWALKERALERT = "api/SkywalkerAlert";

        private static DeathstarRESTClient _current;
        public static DeathstarRESTClient Current
        {
            get { return _current ?? (_current = new DeathstarRESTClient()); }
        }

        public void PostAlert(string name, Specie specie, Role role) 
        {
            try
            {
                var data = new SkywalkerAlert()
                {
                    Timestamp = DateTime.Now,
                    Name = name,
                    Specie = specie,
                    Role = role,
                    ClientIP =
                        HttpContext.Current.Request.UserHostName + " (" + HttpContext.Current.Request.UserHostAddress +
                        ")",
                    BrowserInfo = HttpContext.Current.Request.UserAgent
                };

                var client = new HttpClient();
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["DeathstarServoceBaseUrl"]);

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.PostAsJsonAsync(API_POST_SKYWALKERALERT, data).Result;
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Couldn't connect with the Deathstar service!");
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
        }

        public void Dispose()
        {
            _current = null;
        }
    }
}
