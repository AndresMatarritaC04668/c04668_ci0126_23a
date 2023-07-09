using Examen2.Handlers;
using Examen2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2_Unit_Test.Handlers
{

    [TestClass]
    public class EliminarAutomoviles_Test
    {
        private AutomovilHandler automovilHandler;

        [TestInitialize]
        public void Setup()
        {
            automovilHandler = new AutomovilHandler();
        }

        [TestMethod]
        // Justificación de la selección de los valores de entrada:
        // En esta prueba, intentamos eliminar un automóvil existente en el concesionario.
        // Esperamos que la consulta se ejecute correctamente y el automóvil sea eliminado.
        // Resultado esperado en palabras: La consulta se ejecuta correctamente y el automóvil es eliminado.
        public void EliminarAutomovil_AutomovilExistente_ReturnsTrue()
        {
            // Arrange
            AutomovilModel automovil = new AutomovilModel
            {
                Marca = "Toyota",
                Modelo = "Raize",
                Color = "Negro",
                NumeroPuertas = 4,
                DobleTraccion = false
            };

            // Act
            automovilHandler.AgregarAutomovil(automovil);
            automovilHandler.EliminarAutomovil(automovil);

            // Assert
            List<AutomovilModel> automoviles = automovilHandler.ObtenerAutomoviles();
            Assert.IsFalse(automoviles.Contains(automovil));
        }

        [TestMethod]
        // Justificación de la selección de los valores de entrada:
        // En esta prueba, intentamos eliminar un automóvil que no existe en el concesionario.
        // Esperamos que la consulta no tenga ningún efecto y no se produzca ningún error.
        // Resultado esperado en palabras: La consulta no tiene efecto y no se produce ningún error.
        public void EliminarAutomovil_AutomovilInexistente_NoEffect()
        {
            // Arrange
            AutomovilModel automovil = new AutomovilModel
            {
                Marca = "Ford",
                Modelo = "Mustang",
                Color = "Azul",
                NumeroPuertas = 2,
                DobleTraccion = false
            };

            // Act
            automovilHandler.EliminarAutomovil(automovil);

            // Assert
            List<AutomovilModel> automoviles = automovilHandler.ObtenerAutomoviles();
            Assert.IsFalse(automoviles.Contains(automovil));
        }
    }

}
