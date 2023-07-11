using Examen2_functional_tests.PageObjectModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Examen2_functional_tests.Tests
{
    [TestFixture]
    class EliminarAutomovil_FunctionalTest
    {
        private IWebDriver driver = null;
        private AdministrarAutomovilesPage administrarAutomovilesPage = null;


        public EliminarAutomovil_FunctionalTest()
        {
            driver = new ChromeDriver();
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("https://localhost:7281/");
            driver.Manage().Window.Maximize();

            administrarAutomovilesPage = new AdministrarAutomovilesPage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        /*
        * Objetivo de la prueba: Esta prueba se enfoca en verificar que el sistema sea capaz de eliminar un automóvil seleccionado.
        * Justificación de cómo el resultado esperado cumple el objetivo de la prueba: Al verificar que el automóvil seleccionado
        * ha sido eliminado de la lista revisando todos los automoviles presentes en la vista de administrar automoviles
        * al no estar presente en esa vista significa que se eliminó correctamente y la funcionalidad de eliminar
        * realiza su trabajo correctamente
        */
        public void EliminarAutomovilFunctionalTest()
        {
            //Arrange
            administrarAutomovilesPage.IrAdministrarAutomoviles();


            //Act 
            string automovilAEliminar = administrarAutomovilesPage.VerificarUltimoAutomovilEnVista();
            administrarAutomovilesPage.EliminarUltimoAutomovilEnVista();
            List<string> automovilesEnVista = administrarAutomovilesPage.AutomovilesEnVista();


            //Assert
            foreach (string automovil in automovilesEnVista)
            {
                Assert.AreNotEqual(automovilAEliminar, automovil);
            }


            TearDown();
        }
    }
}

