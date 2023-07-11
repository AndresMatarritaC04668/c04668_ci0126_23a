using OpenQA.Selenium;

namespace Examen2_functional_tests.PageObjectModels
{
    class AdministrarAutomovilesPage
    {
        private IWebDriver driver;
        private readonly By administrarAutomovilesLink = By.LinkText("Administrar Automóviles");
        private readonly By MarcaAutomovil = By.CssSelector("tr:nth-child(1) > td:nth-child(1)");
        private readonly By ModeloAutomovil = By.CssSelector("tr:nth-child(1) > td:nth-child(2)");
        private readonly By eliminarLink = By.LinkText("Eliminar");

        public AdministrarAutomovilesPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string VerificarAutomovilAgregado()
        {
            driver.FindElement(administrarAutomovilesLink).Click();
            IWebElement modeloElement = driver.FindElement(ModeloAutomovil);
            IWebElement marcaElement = driver.FindElement(MarcaAutomovil);
            string automovilAgregado = marcaElement.Text + " " + modeloElement.Text;

            return automovilAgregado;



        }

    }
}
