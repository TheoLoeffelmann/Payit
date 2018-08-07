using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Datos
{
    public class ObtenerObjetos
    {
        public List<AvailableBooks> GetAvailableBooks(List<JToken> result)
        {
            List<AvailableBooks> list = new List<AvailableBooks>();
            foreach (var res in result)
            {
                AvailableBooks el = JsonConvert.DeserializeObject<AvailableBooks>(res.ToString());
                list.Add(el);
            }
            return list;
        }

        public List<Tickers> GetTickers(List<JToken> result)
        {
            List<Tickers> list = new List<Tickers>();
            Tickers t = new Tickers();

            t.high = result[0].First.ToString();
            t.last = result[1].First.ToString();
            t.created_at = result[2].First.ToString();
            t.book = result[3].First.ToString();
            t.volume = result[4].First.ToString();
            t.vwap = result[5].First.ToString();
            t.low = result[6].First.ToString();
            t.ask = result[7].First.ToString();
            t.bid = result[8].First.ToString();
            list.Add(t);
            
            return list;
        }

        public List<OrderBooks> GetOrderBooks(List<JToken> result)
        {
            List<OrderBooks> list = new List<OrderBooks>();
            OrderBooks or = new OrderBooks();
            or.updated_at = result[0].First.ToString();
            or.sequence = result[3].First.ToString();
            //traemos nuevamente los elementos del asks
            string jsonB = result[1].First.ToString();
            JArray arr = JArray.Parse(jsonB) as JArray;
            dynamic bids = arr;
            List<AsksBids> asksBids = new List<AsksBids>();
            foreach(dynamic el in arr)
            {
                AsksBids ab = new AsksBids();
                ab.book = el.book;
                ab.amount = el.amount;
                ab.price = el.price;
                ab.oid = null;
                asksBids.Add(ab);
            }
            or.bids = asksBids;
            
            string jsonA = result[1].First.ToString();
            JArray arrA = JArray.Parse(result[1].First.ToString());
            dynamic asks = arrA;
            or.asks = new List<AsksBids>();
            foreach(dynamic el in arrA)
            {
                AsksBids ab = new AsksBids();
                ab.book = el.book;
                ab.amount = el.amount;
                ab.price = el.price;
                ab.oid = null;
                or.asks.Add(ab);
            }

            list.Add(or);
            
            return list;
        }

        public List<Trades> GetTrades(List<JToken> jTokens)
        {
            List<Trades> trades = new List<Trades>();
            foreach(var el in jTokens)
            {
                Trades trade = JsonConvert.DeserializeObject<Trades>(el.ToString());
                trades.Add(trade);
            }
            return trades;
        }

        
    }
}
