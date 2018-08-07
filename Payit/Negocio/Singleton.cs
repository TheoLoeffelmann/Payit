using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class Singleton
    {
        //patron de diseño singleton sólo tomara los datos que necesito de la capa de datos
        static private ObtenerJsons singleton = null;
        private Singleton()
        {
            
        }

        static public ObtenerJsons GetSingleton()
        {
            if (singleton == null)
            {
                singleton = new ObtenerJsons();
            }

            return singleton;
        }



    }
}
