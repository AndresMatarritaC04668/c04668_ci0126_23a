using Examen2_functional_tests.PageObjectModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace Examen2_functional_tests.Tests
{   [TestFixture]
    public class Operaciones_CRUD_Test
    {
        private IWebDriver driver = null;
        private AgregarAutomovilPage agregarAutomovilPage = null;
        private AdministrarAutomovilesPage administrarAutomovilesPage = null;

        public Operaciones_CRUD_Test() {
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


        /*
         * Objetivo de la prueba: Verificar que se pueda agregar un automóvil correctamente.
         * El resultado esperado cumple el objetivo de la prueba, ya que se espera que se agregue correctamente el automóvil "Honda Civic".
         */
        [Test, Order(1)]
        public void agregarAutomovilFunctionalTest()
        {
            //Arrange
            SetUp();

            //Act 
            string mensajeAccion = agregarAutomovilPage.AgregarAutomovil("Honda", "Civic", "Azul", "2");
            string automovilAgregado = administrarAutomovilesPage.VerificarAutomovilAgregado();

            //Assert
            Assert.That(mensajeAccion, Is.EqualTo("El automóvil Honda Civic fue agregado con éxito."));
            Assert.That(automovilAgregado, Is.EqualTo("Honda Civic"));

            TearDown();
        }

    }
}

