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

        // Método para agregar un automóvil al concesionario
        public bool  AgregarAutomovil(AutomovilModel automovil)
        {
             bool consultaExitosa = false;

            string consulta = @"INSERT INTO concesionario(marca, modelo, color,
                              numeroPuertas, dobleTraccion)
                              VALUES(@marca, @modelo, @color, @numeroPuertas, @dobleTraccion)";
            SqlCommand comandoParaConsulta = new SqlCommand(consulta, conexion);
            try
            {
                // Establecer los parámetros de la consulta
                SqlDataAdapter adaptadorParaTabla = new SqlDataAdapter(comandoParaConsulta);
                comandoParaConsulta.Parameters.AddWithValue("@marca", automovil.Marca);
                comandoParaConsulta.Parameters.AddWithValue("@modelo", automovil.Modelo);
                comandoParaConsulta.Parameters.AddWithValue("@color", automovil.Color);
                comandoParaConsulta.Parameters.AddWithValue("@numeroPuertas",automovil.NumeroPuertas);
                comandoParaConsulta.Parameters.AddWithValue("@dobleTraccion", automovil.DobleTraccion);

                // Abrir la conexión y ejecutar la consulta
                conexion.Open();
                // Verificar si se agregó al menos una fila
                consultaExitosa = comandoParaConsulta.ExecuteNonQuery() >= 1;
                conexion.Close();
            }
            catch (Exception ex)
            {
                // Lanzar una excepción para manejar el error en un nivel superior
                throw new Exception("Error al ejecutar la consulta: " + ex.Message);
            }
            
            return consultaExitosa;
        }

        // Método para obtener todos los automóviles del concesionario
        public List<AutomovilModel> ObtenerAutomoviles()
        {
            List<AutomovilModel> automoviles = new List<AutomovilModel>();
            string consulta = "SELECT * FROM concesionario";
            DataTable? tablaResultado;

            try
            {
                tablaResultado = CrearTablaConsulta(consulta);
                automoviles = DevolverAutomovilesConsulta(tablaResultado);
            }
            catch (Exception ex)
            {
                // Lanzar una excepción para manejar el error en un nivel superior
                throw new Exception("Error al crear la tabla de consulta: " + ex.Message);
            }
            return automoviles;
        }

        // Método para obtener los automóviles por marca
        public List<AutomovilModel> ObtenerAutomovilesPorMarca(string marca)
        {
            List<AutomovilModel> automoviles = new List<AutomovilModel>();

            string consulta = "SELECT * FROM concesionario WHERE marca = @marca";

            try
            {
                 using (SqlCommand comandoConsulta = new SqlCommand(consulta, conexion))
                 {
                      // Abrir la conexión y ejecutar la consulta
                     comandoConsulta.Parameters.AddWithValue("@marca", marca);
                    
                     // Cerrar la conexión
                     conexion.Open();

                     DataTable tablaResultado = new DataTable();
                     tablaResultado.Load(comandoConsulta.ExecuteReader());
                     automoviles = DevolverAutomovilesConsulta(tablaResultado);
                 }
            }
            catch (Exception ex)
            {
                // Lanzar una excepción para manejar el error en un nivel superior
                throw new Exception("Error al ejecutar la consulta: " + ex.Message);
            }

            return automoviles;
        }

        // Método privado para convertir los resultados de la consulta en una lista de automóviles
        private List<AutomovilModel> DevolverAutomovilesConsulta(DataTable tablaResultado)
        {
            List<AutomovilModel> automoviles = new List<AutomovilModel>();

            foreach (DataRow columna in tablaResultado.Rows)
            {
                try
                {
                    automoviles.Add(new AutomovilModel
                    {
                        Marca = Convert.ToString(columna["marca"]),
                        Modelo = Convert.ToString(columna["modelo"]),
                        Color = Convert.ToString(columna["color"]),
                        NumeroPuertas = Convert.ToInt32(columna["numeroPuertas"]),
                        DobleTraccion = Convert.ToBoolean(columna["dobleTraccion"]),
                    });
                }
                catch (Exception ex)
                {
                    // Lanzar una excepción para manejar el error en un nivel superior
                    throw new Exception("Error al agregar un automóvil: " + ex.Message);
                }
            }

            return automoviles;
        }

        // Método para eliminar un automóvil del concesionario
        public void EliminarAutomovil(AutomovilModel? automovil)
        {
            if (AutomovilNoNulo(automovil))
            {
                string consulta = "DELETE from concesionario  WHERE concesionario.marca = '" + automovil.Marca +
                    "' AND concesionario.modelo = '" + automovil.Modelo + "';";
                SqlCommand comandoParaConsulta = new SqlCommand(consulta, conexion);
                try
                {
                    conexion.Open();
                    comandoParaConsulta.ExecuteNonQuery();
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    // Lanzar una excepción para manejar el error en un nivel superior
                    throw new Exception("Error al ejecutar la consulta: " + ex.Message);
                }
            }

        }

        public bool AutomovilNoNulo(AutomovilModel? automovil)
        {
            return automovil != null;
        }

        // Método para editar un automóvil del concesionario
        public void  EditarAutomovil(AutomovilModel automovilNuevo , AutomovilModel automovilAEditar)
        {
            if (AutomovilNoNulo(automovilNuevo) && AutomovilNoNulo(automovilAEditar))
            {
                var consulta = @"UPDATE [dbo].[concesionario] SET
                           modelo = @modelo,
                           marca = @marca,
                           color = @color,
                           numeroPuertas = @numeroPuertas,
                           dobleTraccion = @dobleTraccion                           
                           WHERE modelo = @modeloViejo AND marca = @marcaVieja ";
                SqlCommand comandoParaConsulta = new SqlCommand(consulta, conexion);
                try
                {
                    comandoParaConsulta.Parameters.AddWithValue("@modelo", automovilNuevo.Modelo);
                    comandoParaConsulta.Parameters.AddWithValue("@marca", automovilNuevo.Marca);
                    comandoParaConsulta.Parameters.AddWithValue("@color", automovilNuevo.Color);
                    comandoParaConsulta.Parameters.AddWithValue("@numeroPuertas", automovilNuevo.NumeroPuertas);
                    comandoParaConsulta.Parameters.AddWithValue("@dobleTraccion", automovilNuevo.DobleTraccion);
                    comandoParaConsulta.Parameters.AddWithValue("@modeloViejo", automovilAEditar.Modelo);
                    comandoParaConsulta.Parameters.AddWithValue("@marcaVieja", automovilAEditar.Marca);
                    conexion.Open();
                    comandoParaConsulta.ExecuteNonQuery();
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    // Lanzar una excepción para manejar el error en un nivel superior
                    throw new Exception("Error al ejecutar la consulta: " + ex.Message);
                }
            }

        }
    }
}
