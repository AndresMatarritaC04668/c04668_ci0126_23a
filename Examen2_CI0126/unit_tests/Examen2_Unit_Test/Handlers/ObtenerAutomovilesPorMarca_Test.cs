using Examen2.Handlers;
using Examen2.Models;


namespace Examen2_Unit_Test.Handlers
{
    [TestClass]
    public class ObtenerAutomovilesPorMarca_Test
    {
        private AutomovilHandler automovilHandler;

        [TestInitialize]
        public void Setup()
        {
            automovilHandler = new AutomovilHandler();
        }

        [TestMethod]
        // Justificación de la selección de los valores de entrada:
        // En esta prueba, pasamos una marca existente en el concesionario.
        // Esperamos obtener una lista de automóviles con la marca especificada.
        // Resultado esperado en palabras: Se espera obtener una lista de automóviles que tienen la marca especificada.
        public void ObtenerAutomovilesPorMarca_ExistingMarca_ReturnsAutomovilesList()
        {
            // Arrange
            string marca = "Toyota";

            // Act
            List<AutomovilModel> automoviles = automovilHandler.ObtenerAutomovilesPorMarca(marca);

            // Assert
            Assert.IsNotNull(automoviles);
            Assert.IsTrue(automoviles.Count > 0);
            foreach (var automovil in automoviles)
            {
                Assert.AreEqual(marca, automovil.Marca);
            }
        }

        [TestMethod]
        // Justificación de la selección de los valores de entrada:
        // En esta prueba, pasamos una marca inexistente en el concesionario.
        // Esperamos obtener una lista vacía de automóviles.
        // Resultado esperado en palabras: Se espera obtener una lista vacía de automóviles,
        // ya que la marca especificada no existe en la tabla Concesionario.
        public void ObtenerAutomovilesPorMarca_NonExistingMarca_ReturnsEmptyList()
        {
            // Arrange
            string marca = "Lamborghini";

            // Act
            List<AutomovilModel> automoviles = automovilHandler.ObtenerAutomovilesPorMarca(marca);

            // Assert
            Assert.IsNotNull(automoviles);
            Assert.AreEqual(0, automoviles.Count);
        }
    }
}
