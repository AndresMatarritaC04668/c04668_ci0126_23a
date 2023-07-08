using Examen2.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Examen2.Handlers
{
    public class AutomovilHandler : HandlerAbstracto
    {
       public AutomovilHandler() {} 

       public bool  AgregarAutomovil(AutomovilModel automovil)
       {
            bool exito = false;

                string consulta = @"INSERT INTO concesionario(marca, modelo, color,
                                  numeroPuertas, dobleTraccion)
                                  VALUES(@marca, @modelo, @color, @numeroPuertas, @dobleTraccion)";
                SqlCommand comandoParaConsulta = new SqlCommand(consulta, conexion);
                try
                {
                    SqlDataAdapter adaptadorParaTabla = new SqlDataAdapter(comandoParaConsulta);
                    comandoParaConsulta.Parameters.AddWithValue("@marca", automovil.Marca);
                    comandoParaConsulta.Parameters.AddWithValue("@modelo", automovil.Modelo);
                    comandoParaConsulta.Parameters.AddWithValue("@color", automovil.Color);
                    comandoParaConsulta.Parameters.AddWithValue("@numeroPuertas",automovil.NumeroPuertas);
                    comandoParaConsulta.Parameters.AddWithValue("@dobleTraccion", automovil.DobleTraccion);
                    conexion.Open();
                    exito = comandoParaConsulta.ExecuteNonQuery() >= 1;
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
                }
            
            return exito;
        }
        public List<AutomovilModel> ObtenerAutomoviles()
        {
            List<AutomovilModel> automoviles= new List<AutomovilModel>();
            string consulta = "SELECT * FROM concesionario";
            DataTable tablaResultado = CrearTablaConsulta(consulta);
            foreach (DataRow columna in tablaResultado.Rows)
            {
                automoviles.Add(
                    new AutomovilModel
                    {
                        Marca = Convert.ToString(columna["marca"]),
                        Modelo = Convert.ToString(columna["modelo"]),
                        Color = Convert.ToString(columna["color"]),
                        NumeroPuertas = Convert.ToInt32(columna["numeroPuertas"]),
                        DobleTraccion = Convert.ToBoolean(columna["dobleTraccion"]),

                    });
            }
            return automoviles;
        }




    }
}
