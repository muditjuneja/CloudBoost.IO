using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StackExchange.Redis;
using ServiceStack.Redis;

namespace CloudBoost.IO.REST.Models
{
    public class RedisConnect
    {
        public RedisClient GetClient()
        {
            return new RedisClient("localhost",6379);
        }

        public string GetValue(string key)
        {
            var client = GetClient();
            return client.ContainsKey(key) ? client.GetValue(key) : null;
        }

        
    }
}