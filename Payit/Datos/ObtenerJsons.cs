using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Datos
{
    public interface ObtenerJson
    {
        string GetJson();
        List<JToken> Token(string sJson);
    }

    public class ObtenerJsons : ObtenerJson
    {     
        public string url { get; set; }
        
        public string GetJson()
        {
            return new WebClient().DownloadString(url);
        }

        public List<JToken> Token(string sJson)
        {
            JObject jobj = JObject.Parse(sJson);
            List<JToken> result = jobj["payload"].Children().ToList();
            return result;
        } 

    }
}
