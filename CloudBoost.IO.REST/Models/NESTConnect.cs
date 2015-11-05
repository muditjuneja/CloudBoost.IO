using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nest;

namespace CloudBoost.IO.REST.Models
{
    public class NESTConnect
    {
        private Uri _url;
        private ConnectionSettings _NESTsettings;
        

        public NESTConnect()
        {
            _url = new Uri("http://localhost:9200/");
            _NESTsettings = new ConnectionSettings(_url, defaultIndex: "cloudboost.io-application");
            
        }

        public ElasticClient GetClient()
        {
            return new ElasticClient(_NESTsettings);
        }

        
    }
}