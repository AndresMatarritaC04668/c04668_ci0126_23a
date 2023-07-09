using Examen2.Controllers;
using Examen2.Handlers;
using Examen2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Examen2_Unit_Test.Controllers
{
    [TestClass]
    public class EditarAutomovilController_Test
    {
        private AutomovilController automovilController;

        [TestInitialize]
        public void Setup()
        {
            automovilController = new AutomovilController();
        }

        [TestMethod]
        // Justificación de la selección de los valores de entrada:
        // En esta prueba, pasamos un automóvil válido para editar.
        // Esperamos que la acción se ejecute correctamente y redirija a la acción "AdministrarAutomoviles".
        // Resultado esperado en palabras: La acción se ejecuta correctamente y redirige a la lista de automóviles.
        public void EditarAutomovil_ValidAutomovil_RedirectsToAdministrarAutomoviles()
        {
            // Arrange
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

    }
}
