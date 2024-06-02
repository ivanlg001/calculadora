using Calculadora.Handlers;
using Calculadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Calculadora.Controllers
{
    public class CalculadoraController : ApiController
    {
        CalculadoraHandler calculadoraHandler;
        public CalculadoraController()
        {
            calculadoraHandler = new CalculadoraHandler();
        }
        // GET: api/Calculadora
        public IEnumerable<Ecuacion> Get()
        {
            return calculadoraHandler.GetAll();
        }

        // GET: api/Calculadora/5
        //public string Get(string filter)
        //{
        //    string result = "entro";

        //    return result;
        //}
        public IEnumerable<Ecuacion> Get(string filter)
        {
            return calculadoraHandler.GetEcuacionByFilter(filter);
        }

        // POST: api/Calculadora
        public IEnumerable<string> Post([FromBody]string value)
        {
            List<string> lstEcuacion = new List<string> { value };
            return lstEcuacion;
        }

        // PUT: api/Calculadora/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Calculadora/5
        public bool Delete(string id)
        {
            int _id = 0;
            int.TryParse(id, out _id);

            return calculadoraHandler.DeleteEcuacion(_id);
        }
    }
}
