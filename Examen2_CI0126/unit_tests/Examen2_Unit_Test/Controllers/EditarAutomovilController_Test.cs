using Examen2.Controllers;
using Examen2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Examen2_Unit_Test.Controllers
{
    [TestClass]
    public class EditarAutomovilController_Test
    {
        private AutomovilController automovilController;
        private ITempDataDictionary tempData;

        [TestInitialize]
        public void Setup()
        {
            automovilController = new AutomovilController();
            tempData = new TempDataDictionary(new DefaultHttpContext(), new MockSessionStateTempDataProvider());
            automovilController.TempData = tempData;
        }

        [TestMethod]
        // Justificación de la selección de los valores de entrada:
        // En esta prueba, pasamos un automóvil válido para editar.
        // Esperamos que la acción se ejecute correctamente y redirija a la acción "AdministrarAutomoviles".
        // Resultado esperado en palabras: La acción se ejecuta correctamente y redirige a la lista de automóviles.
        public void EditarAutomovil_ValidAutomovil_RedirectsToAdministrarAutomoviles()
        {
            // Arrange
            automovilController.TempData["modelo"] = "Corolla";
            automovilController.TempData["marca"] = "Toyota";

            AutomovilModel automovil = new AutomovilModel
            {
                Marca = "Toyota",
                Modelo = "Corolla",
                Color = "Azul",
                NumeroPuertas = 4,
                DobleTraccion = false
            };

            // Act
            IActionResult result = automovilController.EditarAutomovil(automovil);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectResult = (RedirectToActionResult)result;
            Assert.AreEqual("AdministrarAutomoviles", redirectResult.ActionName);
            Assert.AreEqual("Automovil", redirectResult.ControllerName);
        }

        [TestMethod]
        // Justificación de la selección de los valores de entrada:
        // En esta prueba, pasamos un automóvil con un valor nulo para el modelo.
        // Esperamos que se lance una excepción debido a que el modelo no puede ser nulo.
        // Resultado esperado en palabras: Se espera que se lance una excepción del
        // tipo Exception con el mensaje que indica un error en la modificación del automóvil.
        public void EditarAutomovil_NullModelo_ThrowsException()
        {
            // Arrange
            AutomovilModel automovil = new AutomovilModel
            {
                Marca = "Toyota",
                Modelo = null,
                Color = "Azul",
                NumeroPuertas = 4,
                DobleTraccion = false
            };

            // Act and Assert
            Exception exception = Assert.ThrowsException<Exception>(() => automovilController.EditarAutomovil(automovil));
            Assert.IsTrue(exception.Message.Contains("La modificación del automóvil tuvo un error"));
        }

        // Implementación simulada de ITempDataProvider para usar en pruebas
        public class MockSessionStateTempDataProvider : ITempDataProvider
        {
            public IDictionary<string, object> LoadTempData(HttpContext context)
            {
                return new Dictionary<string, object>();
            }

            public void SaveTempData(HttpContext context, IDictionary<string, object> values)
            {
                // No se necesita guardar los valores en las pruebas unitarias
            }

        }

    }
} 
