using Calculadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DA = Calculadora.DataAccess;
namespace Calculadora.Handlers
{
    public class CalculadoraHandler
    {
        private DA.DataAccess dataAccess;

        public CalculadoraHandler()
        {
            dataAccess = new DA.DataAccess("connectionDB");
        }

        public List<Ecuacion> GetAll()
        {
            object request = new
            {
                filter = "*"
            };
            var res = dataAccess.GetListByParameter<Ecuacion, object>("dbo.spr_readEcuaciones", request);

            return res;
        }

        public List<Ecuacion> GetEcuacionByFilter(string _filter)
        {
            object request = new
            {
                filter = _filter
            };
            var res = dataAccess.GetListByParameter<Ecuacion, object>("dbo.spr_readEcuaciones", request);

            return res;
        }

        public bool CreateEcuacion(Ecuacion ecuacion)
        {
            bool result = false;

            object request = new
            {
                primerEcuacion = ecuacion.PrimerEcuacion,
                segundaEcuacion = ecuacion.SegundaEcuacion,
                valorX = ecuacion.ValorX,
                valorY = ecuacion.ValorY
            };
            var res = dataAccess.InsertModel<object>("dbo.spi_insertEcuacion", request);

            result = res > 0 ? true : false;
            
            return result;
        }

        public bool DeleteEcuacion(int _id)
        {
            bool result = false;

            object request = new
            {
                id = _id
            };
            var res = dataAccess.DeleteModel<object>("dbo.spd_deleteEcuacion", request);

            result = res > 0 ? true : false;

            return result;
        }
    }
}