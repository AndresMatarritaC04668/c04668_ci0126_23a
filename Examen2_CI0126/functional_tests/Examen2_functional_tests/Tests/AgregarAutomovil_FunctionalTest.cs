using Examen2_functional_tests.PageObjectModels;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Examen2_functional_tests.Tests
{
    [TestFixture]
    public class AgregarAutomovil_FunctionalTest
    {
        private IWebDriver driver = null;
        private AgregarAutomovilPage agregarAutomovilPage = null;
        private AdministrarAutomovilesPage administrarAutomovilesPage = null;

        public AgregarAutomovil_FunctionalTest()
        {
            driver = new ChromeDriver();
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("https://localhost:7281/");
            driver.Manage().Window.Maximize();

            agregarAutomovilPage = new AgregarAutomovilPage(driver);
            administrarAutomovilesPage = new AdministrarAutomovilesPage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        /*
         * Objetivo de la prueba: Verificar que se pueda agregar un automóvil correctamente y observar los datos del nuevo automovil.
         * El resultado esperado cumple el objetivo de la prueba, ya que se espera que se agregue correctamente el automóvil "Honda Civic".
         * y al encontrarlo en la vista demuestra su funcionamiento correcto
         * Muy importante mencionar que el carro mas recientemente agregado es siempre el primero en la lista por eso se verifica el primero
         */
        public void agregarAutomovilFunctionalTest()
        {
            //Act 
            string mensajeAccion = agregarAutomovilPage.AgregarAutomovil("Honda", "Civic", "Azul", "2");
            string automovilAgregado = administrarAutomovilesPage.VerificarAutomovilAgregado();

            //Assert
            Assert.That(mensajeAccion, Is.EqualTo("El automóvil Honda Civic fue agregado con éxito."));
            Assert.That(automovilAgregado, Is.EqualTo("Honda Civic Azul 2"));

            TearDown();
        }
    }
}
