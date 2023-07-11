using OpenQA.Selenium;

namespace Examen2_functional_tests.PageObjectModels
{
    class AdministrarAutomovilesPage
    {
        private IWebDriver driver;
        private readonly By administrarAutomovilesLink = By.LinkText("Administrar Automóviles");
        private readonly By marcaPrimerAutomovil = By.CssSelector("tr:nth-child(1) > td:nth-child(1)");
        private readonly By modeloPrimerAutomovil = By.CssSelector("tr:nth-child(1) > td:nth-child(2)");
        private readonly By marcaUltimoAutomovil = By.CssSelector("tr:last-child > td:nth-child(1)");
        private readonly By modeloUltimoAutomovil = By.CssSelector("tr:last-child > td:nth-child(2)");
        private readonly By colorUltimoAutomovil = By.CssSelector("tr:last-child > td:nth-child(3)");
        private readonly By puertasUltimoAutomovil = By.CssSelector("tr:last-child > td:nth-child(4)");
        private readonly By eliminarLink = By.LinkText("Eliminar");

        public AdministrarAutomovilesPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string VerificarAutomovilAgregado()
        {
            driver.FindElement(administrarAutomovilesLink).Click();
            IWebElement modeloElement = driver.FindElement(modeloPrimerAutomovil);
            IWebElement marcaElement = driver.FindElement(marcaPrimerAutomovil);
            string automovilAgregado = marcaElement.Text + " " + modeloElement.Text;
            return automovilAgregado;
        }
        public string VerificarAutomovilEditado()
        {
            driver.FindElement(administrarAutomovilesLink).Click();
            IWebElement modeloElement = driver.FindElement(modeloUltimoAutomovil);
            IWebElement marcaElement = driver.FindElement(marcaUltimoAutomovil);
            IWebElement colorElement = driver.FindElement(colorUltimoAutomovil);
            IWebElement puertasElement = driver.FindElement(puertasUltimoAutomovil);
            string automovilEditado = marcaElement.Text + " " + modeloElement.Text
                + " " + colorElement.Text + " " + puertasElement.Text;
            return automovilEditado;
        }


        public void IrAdministrarAutomoviles()
        {
            driver.FindElement(administrarAutomovilesLink).Click();
        }

    }
}
