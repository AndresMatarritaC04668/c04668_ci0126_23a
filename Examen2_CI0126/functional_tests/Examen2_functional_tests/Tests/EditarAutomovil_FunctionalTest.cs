using Examen2_functional_tests.PageObjectModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Examen2_functional_tests.Tests
{
    [TestFixture]
    public class EditarAutomovil_FunctionalTest
    {
        private IWebDriver driver = null;
        private AdministrarAutomovilesPage administrarAutomovilesPage = null;
        private EditarAutomovilPage editarAutomovilPage = null;

        public EditarAutomovil_FunctionalTest()
        {
            driver = new ChromeDriver();
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("https://localhost:7281/");
            driver.Manage().Window.Maximize();

            administrarAutomovilesPage = new AdministrarAutomovilesPage(driver);
            editarAutomovilPage = new EditarAutomovilPage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        /*
         * Objetivo de la prueba: Verificar que se pueda editar un automóvil correctamente y observar el automovil con los nuevos cambios.
         * El resultado esperado cumple el objetivo de la prueba, ya que se espera que el automóvil se edite con los valores proporcionados.
         * Esto se verifica al observar los datos del ultimo automovil de la lista que es donde se ubican los automoviles recien actualizados
         * por lo tanto se actualiza el primer automovil de la lista que si se sigue el orden de pruebas es el Honda Civic que fue agregado
         * en la prueba de agregarAutomovil
        */
        public void EditarAutomovilFunctionalTest()
        {
            //Arrange
            administrarAutomovilesPage.IrAdministrarAutomoviles();
            editarAutomovilPage.ClickEditar();

            //Act 
            editarAutomovilPage.FillMarcaField("Suzuki");
            editarAutomovilPage.FillModeloField("Vitara");
            editarAutomovilPage.FillColorField("Amarillo");
            editarAutomovilPage.FillNumeroPuertasField("4");
            editarAutomovilPage.CheckDobleTraccion();
            editarAutomovilPage.ClickGuardar();
            string automovilEditado = administrarAutomovilesPage.VerificarUltimoAutomovilEnVista();

            //Assert
            Assert.That(automovilEditado, Is.EqualTo("Suzuki Vitara Amarillo 4"));


            TearDown();
        }
    }
}
