using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nest;

namespace CloudBoost.IO.REST.Models
{
    public class Data
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public bool IndexDataByElastic()
        {
            NESTConnect connect = new NESTConnect();
            var client = connect.GetClient();
            var index = client.Index(this);
            return index.Created;
        }


        public bool InsertDataInRedis()
        {
            var client = new RedisConnect().GetClient();
            client.SetValue(this.Id.ToString(), this.Value);
            return client.ContainsKey(this.Id.ToString());
        }

       public List<Data> SearchFromElastic(string query)
        {
            var client = new NESTConnect().GetClient();
            var r = client.Search<Data>(s => s.From(0).Query(q=>q.QueryString(d=>d.Query(query))));
            List<Data> lst = new List<Data>();
            foreach (var hit in r.Hits)
            {
                Data d = new Data();
                d.Value = hit.Source.Value;
                d.Id = hit.Source.Id;
                lst.Add(d);
            }
            return lst;
        }


    }
}