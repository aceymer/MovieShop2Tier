using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DtoModel;


namespace MoviesShopProxy.Proxies
{
    public class MovieProxyService
    {
        public IEnumerable<Movie> ReadAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:4835/api/movie/").Result;
                return response.Content.ReadAsAsync<IEnumerable<Movie>>().Result;
            }
        }
    }
}
