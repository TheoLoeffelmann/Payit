using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Menus: Factory
    {
        public int iOpcPpal { get; set; }
        public string sSubMenú { get; set; }
        public string sUrl { get; set; }
        
        public int Principal()
        {
            int opc = 0;
            Console.WriteLine("*********¿Qué deseas visualizar?*********");
            Console.WriteLine("Available Books.........................1");
            Console.WriteLine("Ticker .................................2");
            Console.WriteLine("Order Book..............................3");
            Console.WriteLine("Trades..................................4");
            Console.WriteLine("Salir...................................5");
            Console.WriteLine();
            try
            {
                opc = Convert.ToInt16(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("No seleccionó ningún elemento válido");
            }
            return opc;
        }

        public void AccionesPpal()
        {            
            int iOpc = 0;
            Console.Clear();
            //mandamos la opcion que le corresponde de acuerdo al valor de la opcion seleccionada anteriormente
            switch (iOpcPpal)
            {
                case 1:
                    //mostraremos opción el contenido para libros disponibles
                    this.sSubMenú = "*****En esta opción usted podrá visualizar Available Books*****\n" +
                           "Ver Available Books.........................1\n"+
                           "Regresar Menú principal.....................100\n";
                    this.sUrl = "https://api.bitso.com/v3/available_books/";
                    break;

                case 2:
                    this.sSubMenú = "*****En esta opción usted podrá visualizar Ticker*****\n" +
                                    "******Seleccione el tipo de libro a visualizar********\n"+
                           "btc_mxn.........................1\n" +
                           "eth_btc.........................2\n" +
                           "eth_mxn.........................3\n" +
                           "xrp_btc.........................4\n" +
                           "xrp_mxn.........................5\n" +
                           "ltc_btc.........................6\n" +
                           "ltc_mxn.........................7\n" +
                           "bch_btc.........................8\n" +
                           "bch_mxn.........................9\n" +
                           "tusd_btc.......................10\n" +
                           "tusd_mxn.......................11\n" +
                           "Regresar Menú principal........100\n";
                    this.sUrl = "https://api.bitso.com/v3/ticker/?book="; ///se debe pasar parámetro de acuerdo a seleccion
                    break;

                case 3:
                    this.sSubMenú = "";
                    this.sSubMenú = "*****En esta opción usted podrá visualizar Ticker*****\n" +
                                    "******Seleccione el tipo de libro a visualizar********\n" +
                           "btc_mxn.........................1\n" +
                           "eth_btc.........................2\n" +
                           "eth_mxn.........................3\n" +
                           "xrp_btc.........................4\n" +
                           "xrp_mxn.........................5\n" +
                           "ltc_btc.........................6\n" +
                           "ltc_mxn.........................7\n" +
                           "bch_btc.........................8\n" +
                           "bch_mxn.........................9\n" +
                           "tusd_btc.......................10\n" +
                           "tusd_mxn.......................11\n" +
                           "Regresar Menú principal........100\n";
                    this.sUrl = "https://api.bitso.com/v3/order_book/?book="; ///se debe pasar parámetro

                    break;
                case 4:
                    this.sSubMenú = "";
                    this.sSubMenú = "*****En esta opción usted podrá visualizar Ticker*****\n" +
                                    "******Seleccione el tipo de libro a visualizar********\n" +
                           "btc_mxn.........................1\n" +
                           "eth_btc.........................2\n" +
                           "eth_mxn.........................3\n" +
                           "xrp_btc.........................4\n" +
                           "xrp_mxn.........................5\n" +
                           "ltc_btc.........................6\n" +
                           "ltc_mxn.........................7\n" +
                           "bch_btc.........................8\n" +
                           "bch_mxn.........................9\n" +
                           "tusd_btc.......................10\n" +
                           "tusd_mxn.......................11\n" +
                           "Regresar Menú principal........100\n";
                    this.sUrl = "https://api.bitso.com/v3/trades/?book="; ///se debe pasar parámetro
                    break;
                default:
                    Console.WriteLine("No seleccionó ningun valor válido");
                    break;
            }

        }

    }
}
