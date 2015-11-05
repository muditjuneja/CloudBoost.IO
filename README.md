# CloudBoost.IO

Run elasicsearch on your windwos
Run Redis on your windows 

    public class StringsController : ApiController
    {

        /*
         Request Type : POST
         URL : http://localhost:49623/api/Strings/Post
         JSON : {"Value":"MUDIT JUNEJA","Id":1}
         */
        [HttpPost]
        public HttpResponseMessage Post(Data d)
        {
           var isDataIndexed = d.IndexDataByElastic() && d.InsertDataInRedis();
            return isDataIndexed ? Request.CreateResponse(HttpStatusCode.Created, "Created") : Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Unable to create");
        }


        /*
         Request Type : GET
         URL : http://localhost:49623/api/Strings/GetFromRedis?key=1
         Data : "MUDIT JUNEJA"
         */
        [HttpGet]
        public HttpResponseMessage GetFromRedis(string key)
       {
            var client = new RedisConnect();
            var value = client.GetValue(key);
            return value != null ? Request.CreateResponse(HttpStatusCode.Found, value) : Request.CreateErrorResponse(HttpStatusCode.NotFound, "No such key");
       }


        /*
        Request Type : GET
        URL : http://localhost:49623/api/Strings/SearchFromElastic?key=%27Mudit%27
        Data : [{"Id":1,"Value":"MUDIT JUNEJA"}]
        */
        [HttpGet]
        public HttpResponseMessage SearchFromElastic(string key)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new Data().SearchFromElastic(key));
        }



       
    }
