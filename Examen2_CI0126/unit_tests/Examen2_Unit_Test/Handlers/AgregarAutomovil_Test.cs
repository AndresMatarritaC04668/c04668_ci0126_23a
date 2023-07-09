using Examen2.Handlers;
using Examen2.Models;

namespace Examen2_Unit_Test.Handlers
{
    [TestClass]
    public class AgregarAutomovil_Test
    {
        private AutomovilHandler automovilHandler;

        [TestInitialize]
        public void Setup()
        {
            automovilHandler = new AutomovilHandler();
        }

        [TestMethod]
        // Justificación de la selección de los valores de entrada:
        // En esta prueba, utilizamos valores válidos para todos los parámetros del automóvil.
        // Esperamos que la consulta se ejecute correctamente y se agregue el automóvil al concesionario.
        // Resultado esperado en palabras: La consulta se ejecuta correctamente y se agrega el automóvil al concesionario.
        public void AgregarAutomovil_ValidParameters_ReturnsTrue()
        {
            // Arrange
            AutomovilModel automovil = new AutomovilModel
            {
                Marca = "Toyota",
                Modelo = "RAV4",
                Color = "Azul",
                NumeroPuertas = 2,
                DobleTraccion = false
            };

            // Act
            bool resultado = automovilHandler.AgregarAutomovil(automovil);

            // Assert
            Assert.IsTrue(resultado);

            // Clean to repeat the test
            automovilHandler.EliminarAutomovil(automovil);
        }

        [TestMethod]
        // Justificación de la selección de los valores de entrada:
        // En esta prueba, pasamos un valor nulo para la marca.
        // Esperamos que se lance una excepción debido a que la marca no puede ser nula.
        // Resultado esperado en palabras: Se lanza una excepción debido a un parámetro obligatorio faltante.
        [ExpectedException(typeof(Exception), "Error al ejecutar la consulta: La marca no puede ser nula.")]
        public void AgregarAutomovil_NullMarca_ThrowsException()
        {
            // Arrange
            AutomovilModel automovil = new AutomovilModel
            {
                Marca = null,
                Modelo = "Corolla",
                Color = "Rojo",
                NumeroPuertas = 4,
                DobleTraccion = false
            };

            // Act
            automovilHandler.AgregarAutomovil(automovil);

            // Assert
            // ExpectedException attribute handles the assertion
        }
    }
}