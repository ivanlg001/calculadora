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
        // GET: api/Calculadora
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Calculadora/5
        public IHttpActionResult Get(string filter)
        {
            string result = "entro";
            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
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
        public void Delete(int id)
        {
        }
    }
}
