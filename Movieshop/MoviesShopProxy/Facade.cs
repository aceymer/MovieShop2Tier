using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesShopProxy.Proxies;

namespace MoviesShopProxy
{
    public class Facade
    {
        public MovieProxyService GetMovieProxy()
        {
            return new MovieProxyService();
        }
    }
}
