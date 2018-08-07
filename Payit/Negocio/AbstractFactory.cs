using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public interface AbstractFactory
    {

    }

    public class Factory: AbstractFactory
    {
        //implementamos el patron singleton
        static private ObtenerJsons singletonJson = null;
        static private ObtenerObjetos singletonObjs = null;

        public virtual ObtenerJsons GetObtenerJsons()
        {
            if (singletonJson == null)
            {
                singletonJson = new ObtenerJsons();
            }
            return singletonJson;
        }

        public virtual ObtenerObjetos GetObtenerObjetos()
        {
            if(singletonObjs == null)
            {
                singletonObjs = new ObtenerObjetos();
            }
            return singletonObjs;
        }

    }
}
