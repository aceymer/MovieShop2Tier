using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesShopGateway.Services;

namespace MoviesShopGateway
{
    public class Facade
    {
        public MovieGatewayService GetMovieGateway()
        {
            return new MovieGatewayService();
        }
    }
}
