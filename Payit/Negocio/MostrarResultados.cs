using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Negocio
{
    public class MostrarResultados
    {
         public Factory factory { get; set; }

        //este método traera la información 
        public void MostrarResultado(string sUrl, int iOpc = 0, string sBook="")
        {
            string sPresentacion = "";
            factory = new Factory();
            factory.GetObtenerJsons().url = sUrl + sBook;

            //obtenemos el json
            string sJson = factory.GetObtenerJsons().GetJson();
            //obtenemos los Jtoken
            List<JToken> jTokens = factory.GetObtenerJsons().Token(sJson);
            Console.Clear();
            if (iOpc == 1)
            {
                List<AvailableBooks> availables = factory.GetObtenerObjetos().GetAvailableBooks(jTokens);
                sPresentacion = "********************************Libros encontrados************************************\n";
                //recorremos los elementos de la lista
                foreach (var el in availables)
                {
                    sPresentacion += "\nbook: " + el.book + "\nminimum_amount:\t" + el.minimum_amount + "\tminimum_amount:" + el.maximum_amount + "\tminimum_price:" + el.minimum_price
                        + "\nmaximum_price:" + el.maximum_price + "\tminimum_value:" + el.minimum_value + "\tmaximum_value:" + el.maximum_value + "\n";
                        
                }
                sPresentacion+= "\n*************************************************************************************\n";
                sPresentacion += "\n\nRegresar al Menú anterior....................22\nRegresar al Menú Principal..................100";
                
            }
            else if (iOpc == 2)
            {
                List<Tickers> tickers = factory.GetObtenerObjetos().GetTickers(jTokens);
                sPresentacion = "************************************Tickers encontrados************************************\n";
                foreach (var el in tickers)
                {
                    sPresentacion += "\nbook:" + el.book + "\nvolume: " + el.volume + "\thigh: " + el.high + "\tlast: " + el.last + "\tlow: " + el.low
                        + "\nvwap: " + el.vwap + "\task: " + el.ask + "\tbid: " + el.bid + "\tcreated_at" + el.created_at + "\n";
                        
                }
                sPresentacion += "********************************************************************************************";
                sPresentacion += "\n\nRegresar al Menú anterior....................22\nRegresar al Menú Principal.............100";

            }
            else if (iOpc == 3)
            {
                List<OrderBooks> orders = factory.GetObtenerObjetos().GetOrderBooks(jTokens);
                sPresentacion = "********************************Order Books encontrados********************************\n";
                foreach (var el in orders)
                {
                    sPresentacion += "updated_at: " + el.updated_at + "\tsequence: " + el.sequence + "\n"
                        + "bids: \n";
                    foreach (AsksBids ab in el.bids)
                    {
                        sPresentacion += "book: " + ab.book + "\tprice:" + ab.price + "\tamount: " + ab.amount + "\n";
                    }
                    sPresentacion += "\nasks:\n";
                    foreach (var ab in el.asks)
                    {
                        sPresentacion += "book: " + ab.book + "\tprice:" + ab.price + "\tamount: " + ab.amount + "\n";
                    }

                }
                sPresentacion += "***********************************************************************************";
                sPresentacion += "\n\nRegresar al Menú anterior....................22\nRegresar al Menú Principal.............100";
            }
            else if (iOpc == 4)
            {
                List<Trades> trades = factory.GetObtenerObjetos().GetTrades(jTokens);
                sPresentacion = "********************************Order Books encontrados********************************\n";

                foreach (var el in trades)
                {
                    sPresentacion += "\nbook: " + el.book + "\tcreated_at: " + el.created_at + "\tamount: " + el.amount + "\n"
                        + "maker_side: " + el.maker_side + "\tprice" + el.price + "\ttid" + el.tid + "\n";
                }
                sPresentacion += "***********************************************************************************";
                sPresentacion += "\n\nRegresar al Menú anterior....................22\nRegresar al Menú Principal.............100";

            }

            Console.WriteLine(sPresentacion);
            
        }

        public void MostrarTransacciones()
        {
            string sPresentacion = "";
            factory = new Factory();
            factory.GetObtenerJsons().url = "https://api.bitso.com/v3/available_books/";

            //obtenemos el json
            string sJson = factory.GetObtenerJsons().GetJson();
            //obtenemos los Jtoken
            List<JToken> jTokens = factory.GetObtenerJsons().Token(sJson);
            List<AvailableBooks> availables = factory.GetObtenerObjetos().GetAvailableBooks(jTokens);
            sPresentacion = "********************************Transacciones disponibles | Libros************************************\n";
            //recorremos los elementos de la lista
            int i = 0;
            foreach (var el in availables)
            {
                i++;
                sPresentacion += "book: " + el.book + "\t\t\t";
                if ((i % 3) == 0) { sPresentacion += "\n"; }
            }
            sPresentacion += "\n******************************************************************************************************\n";
            Console.WriteLine(sPresentacion);

        }
    }
}
