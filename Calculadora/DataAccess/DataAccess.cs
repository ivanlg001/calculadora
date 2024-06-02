using Calculadora.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Calculadora.DataAccess
{
    public class DataAccess
    {
        private readonly SqlConnection _connection;
        public DataAccess(string connection)
        {
            //_connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Calculadora;Trusted_Connection=True;MultipleActiveResultSets=True;");
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings[connection].ConnectionString);
        }

        private object GetNullableValue(SqlDataReader reader, PropertyInfo property)
        {
            var t = property.PropertyType;

            if (reader[property.Name] == null || reader[property.Name] is DBNull)
                return null;

            if (property.PropertyType.Name.Equals(typeof(Nullable<>).Name))
            {
                t = Nullable.GetUnderlyingType(t);
                return Convert.ChangeType(reader[property.Name], t);
            }

            return Convert.ChangeType(reader[property.Name], property.PropertyType);
        }

        public List<TModel> GetListByParameter<TModel, TObject>(string procedure, TObject actualModel)
            where TModel : class, new()
        {
            var responseModel = new List<TModel>();

            using (_connection)
            {
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = procedure;
                    command.CommandTimeout = 90;
                    command.CommandType = CommandType.StoredProcedure;
                    var inAttributes = actualModel.GetType().GetProperties();

                    foreach (var inAttribute in inAttributes)
                    {
                        if (inAttribute.PropertyType.Name == "String")
                        {
                            command.Parameters.Add("@" + inAttribute.Name, SqlDbType.NVarChar, 1600);
                            command.Parameters["@" + inAttribute.Name].Value = inAttribute.GetValue(actualModel);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@" + inAttribute.Name, inAttribute.GetValue(actualModel));
                        }
                    }
                    _connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TModel model = new TModel();
                            var properties = model.GetType().GetProperties();

                            foreach (var property in properties)
                            {
                                try
                                {
                                    var obj = GetNullableValue(reader, property);
                                    property.SetValue(model, obj);
                                }
                                catch (Exception e)
                                {

                                }
                            }
                            responseModel.Add(model);
                        }

                    }
                }
            }
            return responseModel;
        }

        public int InsertModel<TObject>(string procedure, TObject actualModel) where TObject : new()
        {
            using (_connection)
            {
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = procedure;
                    command.CommandType = CommandType.StoredProcedure;

                    var inAttributes = actualModel.GetType().GetProperties();


                    foreach (var inAttribute in inAttributes)
                    {
                        //
                        /*var TypeVar = inAttribute.PropertyType;
                        if (TypeVar.Name == "String")
                        {
                            command.Parameters.Add("@" + inAttribute.Name, SqlDbType.NVarChar, -1).Direction = ParameterDirection.Input;
                            command.Parameters["@" + inAttribute.Name].Value = inAttribute.GetValue(actualModel);
                        }
                        else
                        {*/
                        command.Parameters.AddWithValue("@" + inAttribute.Name, inAttribute.GetValue(actualModel));
                        //}
                    }
                    _connection.Open();

                    return command.ExecuteNonQuery();
                }
            }
        }

        public int UpdateModel<TObject>(string procedure, TObject actualModel) where TObject : new()
        {
            using (_connection)
            {
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = procedure;
                    command.CommandType = CommandType.StoredProcedure;

                    var inAttributes = actualModel.GetType().GetProperties();

                    foreach (var inAttribute in inAttributes)
                    {
                        command.Parameters.AddWithValue("@" + inAttribute.Name, inAttribute.GetValue(actualModel));
                    }
                    _connection.Open();

                    return command.ExecuteNonQuery();
                }
            }
        }

        public int DeleteModel<TObject>(string procedure, TObject actualModel) where TObject : new()
        {
            using (_connection)
            {
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = procedure;
                    command.CommandType = CommandType.StoredProcedure;

                    var inAttributes = actualModel.GetType().GetProperties();

                    foreach (var inAttribute in inAttributes)
                    {
                        command.Parameters.AddWithValue("@" + inAttribute.Name, inAttribute.GetValue(actualModel));
                    }
                    _connection.Open();

                    return command.ExecuteNonQuery();
                }
            }
        }

        /*public List<Ecuacion> GetEcuacionesHistoric(string filter)
        {
            List<Ecuacion> lstEcuaciones = new List<Ecuacion>();

            try
            {
                using (connection)
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "dbo.spr_readEcuaciones";
                        //parameters
                        command.Parameters.Add("@filter", SqlDbType.NVarChar);
                        command.Parameters["@filter"].Value = filter;

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Ecuacion ecuacion = new Ecuacion();
                                var properties = model.GetType().GetProperties();

                                foreach (var property in properties)
                                {
                                    try
                                    {
                                        var obj = GetNullableValue(reader, property);
                                        property.SetValue(model, obj);
                                    }
                                    catch (Exception e)
                                    {

                                    }
                                }
                                responseModel.Add(model);
                            }

                        }
                    }
                }

            }
            catch(Exception ex)
            {

            }

            return lstEcuaciones;
        }
        */
        /*
        public bool InsertEcuacionHistoric(Ecuacion ecuacion)
        {
            try
            {
                using (connection)
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "dbo.spi_insertEcuaciones";
                        //parameters
                        command.Parameters.Add("@primerEcuacion", SqlDbType.NVarChar);
                        command.Parameters["@primerEcuacion"].Value = ecuacion.PrimerEcuacion;

                        command.Parameters.Add("@segundaEcuacion", SqlDbType.NVarChar);
                        command.Parameters["@segundaEcuacion"].Value = ecuacion.PrimerEcuacion;

                        command.Parameters.Add("@valorX", SqlDbType.NVarChar);
                        command.Parameters["@valorX"].Value = ecuacion.PrimerEcuacion;

                        command.Parameters.Add("@valorY", SqlDbType.NVarChar);
                        command.Parameters["@valorY"].Value = ecuacion.PrimerEcuacion;
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }
        */
    }
}