using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;

namespace KopitekCounter
{
    class Api
    {
        public bool PostCounter(Counter counter)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://counter.kopitek.com.tr");
                    client.DefaultRequestHeaders.Add("x-api-key", "V24e05S83");
                    var response = client.PostAsync("api/Counters", new StringContent(new JavaScriptSerializer().Serialize(counter), Encoding.UTF8, "application/json")).Result;
                    return response.IsSuccessStatusCode;

                }
            }
            catch(Exception ex)
            {
                var logger = new Logger();
                logger.ErrorLog(ex.ToString());
                return false;
            }
        }
    }
}
