using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;

namespace Bitso
{
    class Program
    {
        static void Main(string[] args)
        {
            MostrarResultados resultados = new MostrarResultados();
            Menus mnu = new Menus();
            int iOpcPpal = 0;
            int iOpcSec = 0;
            int iResp = 100;
            do
            {
                Console.Clear();
                resultados.MostrarTransacciones();
                if (iResp == 100)
                {
                    iOpcPpal = mnu.Principal();
                }
                mnu.iOpcPpal = iOpcPpal;
                if (iOpcPpal != 5)
                {
                    mnu.AccionesPpal();
                    string sMnuSec = mnu.sSubMenú;
                    string sUrl = mnu.sUrl;
                    Console.WriteLine(sMnuSec);
                    try
                    {
                        //leemos la opcion del submenu
                        iOpcSec = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        iOpcPpal = 0;
                        iOpcSec = 0;
                        Console.Write("No seleccionó una opción válida");
                    }
                    //ya que obtenemos la información del submenú procedemos a llamar la información de la API
                    //aqui armaremos la url de acuerdo a la opción seleccionada del submenu
                    if (iOpcPpal == 1)
                    {
                        //enviamos la información para mostrar en el negocio la información correspondiente de los libros disponibles
                        if (iOpcSec == 1)
                        {
                            //mandamos la url para mostrar la información
                            resultados.MostrarResultado(sUrl, iOpcPpal);
                            //iResp = Convert.ToInt16(Console.ReadLine());
                            iResp = Convert.ToInt16(Console.ReadLine());
                        }
                        else if (iOpcSec == 100)
                        {
                            iOpcPpal = 0;
                        }
                        else
                        { Console.WriteLine("No selecciono opción válida"); }
                    }
                    else if (iOpcPpal >= 2 && iOpcPpal <= 4)
                    {
                        //traemos los elementos core
                        string sBook = GetLibro(iOpcSec);
                        if (iOpcSec > 0 && iOpcSec < 12)
                        {
                            //colocar url

                            resultados.MostrarResultado(sUrl, iOpcPpal, sBook);
                            iResp = Convert.ToInt16(Console.ReadLine());
                            //if (iResp == 22) { }
                            sUrl = "";
                        }
                        else if (iOpcSec == 100)
                        {
                            iOpcPpal = 0;
                        }
                        else { Console.WriteLine("No selecciono opción válida"); }

                    }

                }

            }
            while (iOpcPpal != 5);

            Console.Read();
        }

        static string GetLibro(int opc)
        {
            string sBook = "";
            if (opc > 0 && opc<12)
            {
                if (opc == 1) { sBook = "btc_mxn"; }
                else if (opc == 2) { sBook = "eth_btc"; }
                else if (opc == 3) { sBook = "eth_mxn"; }
                else if (opc == 4) { sBook = "xrp_btc"; }
                else if (opc == 5) { sBook = "xrp_mxn"; }
                else if (opc == 6) { sBook = "ltc_btc"; }
                else if (opc == 7) { sBook = "ltc_mxn"; }
                else if (opc == 8) { sBook = "bch_btc"; }
                else if (opc == 9) { sBook = "bch_mxn"; }
                else if (opc == 10) { sBook = "tusd_btc"; }
                else if (opc == 11) { sBook = "tusd_mxn"; }
               
            }
            else
            {
                sBook = "";
            }
            return sBook;
        }

        
    }
}
