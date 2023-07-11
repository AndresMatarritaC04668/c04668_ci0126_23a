using Examen2_functional_tests.PageObjectModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Examen2_functional_tests.Tests
{
    [TestFixture]
    public class LeerAutomoviles_FunctionalTest
    {
        private IWebDriver driver = null;
        private AdministrarAutomovilesPage administrarAutomovilesPage = null;

        public LeerAutomoviles_FunctionalTest()
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
         * Objetivo de la prueba: Verificar que la funcionalidad de lectura de automóviles por marca funcione correctamente.
         * El resultado esperado es que la lista de automóviles en vista contenga solo automóviles de la marca especificada.
         * Esto cumple el objetivo de la prueba al asegurar que la funcionalidad de lectura devuelve los automóviles 
         * correctos según la marca especificada y pueden ser observados por el usuario.
         */
        public void LeerAutomovilesPorMarca_FunctionalTest()
        {
            //Arrange
            administrarAutomovilesPage.IrAdministrarAutomoviles();


            //Act 
            administrarAutomovilesPage.BuscarAutomovilesPorMarca("Toyota");
            List<string> automovilesEnVista = administrarAutomovilesPage.AutomovilesEnVista();


            // Assert
            foreach (string automovil in automovilesEnVista)
            {
                Assert.IsTrue(automovil.Contains("Toyota"));
                Console.WriteLine(automovil);
            }

            TearDown();
        }
    }
}
