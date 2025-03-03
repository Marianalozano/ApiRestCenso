using System.Collections.Generic;
using System.Web.Http;
using apiRESTCenso.Models;

public class CensoController : ApiController
{
    // Definición del arreglo de objetos
    public static clsCensoPoblacion[] objCenso = null;

    // GET: api/Censo
    public IEnumerable<clsCensoPoblacion> Get()
    {
        return objCenso;
    }

    // GET: api/Censo/5
    public clsCensoPoblacion Get(int id)
    {
        clsCensoPoblacion elemento = null;

        if (objCenso != null)
        {
            foreach (var item in objCenso)
            {
                if (item != null && item.id == id)
                {
                    elemento = item;
                    break;
                }
            }
        }

        return elemento;
    }

    // POST: api/Censo
    public string Post(int posicion, [FromBody] clsCensoPoblacion modelo)
    {
        string ban = "";

        if (objCenso == null)
        {
            objCenso = new clsCensoPoblacion[5];
            for (int i = 0; i < objCenso.Length; i++)
            {
                objCenso[i] = new clsCensoPoblacion();
            }
        }

        if (posicion >= 0 && posicion < objCenso.Length)
        {
            objCenso[posicion] = modelo;
            ban = "1";
        }
        else
        {
            ban = "0";
        }

        return ban;
    }

    // PUT: api/Censo/5
    public string Put(int posicion, [FromBody] clsCensoPoblacion modelo)
    {
        string ban = "-1";

        if (objCenso != null)
        {
            if (posicion >= 0 && posicion < objCenso.Length)
            {
                objCenso[posicion] = modelo;
                ban = "1";
            }
            else
            {
                ban = "0";
            }
        }

        return ban;
    }

    // DELETE: api/Censo/5
    public string Delete(int posicion)
    {
        string ban = "-1";

        if (objCenso != null)
        {
            if (posicion >= 0 && posicion < objCenso.Length)
            {
                objCenso[posicion] = new clsCensoPoblacion();
                ban = "1";
            }
            else
            {
                ban = "0";
            }
        }

        return ban;
    }
}
