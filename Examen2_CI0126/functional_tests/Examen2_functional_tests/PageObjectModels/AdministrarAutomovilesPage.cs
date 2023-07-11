using NUnit.Framework;
using OpenQA.Selenium;

namespace Examen2_functional_tests.PageObjectModels
{
    class AdministrarAutomovilesPage
    {
        private IWebDriver driver;
        private readonly By administrarAutomovilesLink = By.LinkText("Administrar Automóviles");
        private readonly By marcaPrimerAutomovil = By.CssSelector("tr:nth-child(1) > td:nth-child(1)");
        private readonly By modeloPrimerAutomovil = By.CssSelector("tr:nth-child(1) > td:nth-child(2)");
        private readonly By colorPrimerAutomovil = By.CssSelector("tr:nth-child(1) > td:nth-child(3)");
        private readonly By puertasPrimerAutomovil = By.CssSelector("tr:nth-child(1) > td:nth-child(4)");
        private readonly By marcaUltimoAutomovil = By.CssSelector("tr:last-child > td:nth-child(1)");
        private readonly By modeloUltimoAutomovil = By.CssSelector("tr:last-child > td:nth-child(2)");
        private readonly By colorUltimoAutomovil = By.CssSelector("tr:last-child > td:nth-child(3)");
        private readonly By puertasUltimoAutomovil = By.CssSelector("tr:last-child > td:nth-child(4)");
        private readonly By botonEliminarLink = By.LinkText("Eliminar");



        public AdministrarAutomovilesPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string VerificarAutomovilAgregado()
        {
            driver.FindElement(administrarAutomovilesLink).Click();
            IWebElement modeloElement = driver.FindElement(modeloPrimerAutomovil);
            IWebElement marcaElement = driver.FindElement(marcaPrimerAutomovil);
            IWebElement colorElement = driver.FindElement(colorPrimerAutomovil);
            IWebElement puertasElement = driver.FindElement(puertasPrimerAutomovil);
            string automovilAgregado = marcaElement.Text + " " + modeloElement.Text +
                " " + colorElement.Text + " " + puertasElement.Text;
            return automovilAgregado;
        }
        public string VerificarUltimoAutomovilEnVista()
        {
            driver.FindElement(administrarAutomovilesLink).Click();
            IWebElement modeloElement = driver.FindElement(modeloUltimoAutomovil);
            IWebElement marcaElement = driver.FindElement(marcaUltimoAutomovil);
            IWebElement colorElement = driver.FindElement(colorUltimoAutomovil);
            IWebElement puertasElement = driver.FindElement(puertasUltimoAutomovil);
            string ultimoAutomovil = marcaElement.Text + " " + modeloElement.Text
                + " " + colorElement.Text + " " + puertasElement.Text;
            return ultimoAutomovil;
        }


        public void IrAdministrarAutomoviles()
        {
            driver.FindElement(administrarAutomovilesLink).Click();
        }

        public List<string> AutomovilesEnVista()
        {
            int index = 1;
            bool existeSiguienteAutomovil = true;
            List<string> automoviles = new List<string>();

            while (existeSiguienteAutomovil)
            {
                By marcaAutomovilLocator = By.CssSelector($"tr:nth-child({index}) > td:nth-child(1)");
                By modeloAutomovilLocator = By.CssSelector($"tr:nth-child({index}) > td:nth-child(2)");
                By colorAutomovilLocator = By.CssSelector($"tr:nth-child({index}) > td:nth-child(3)");
                By puertasAutomovilLocator = By.CssSelector($"tr:nth-child({index}) > td:nth-child(4)");

                try
                {
                    IWebElement marcaAutomovilElement = driver.FindElement(marcaAutomovilLocator);
                    IWebElement modeloAutomovilElement = driver.FindElement(modeloAutomovilLocator);
                    IWebElement colorAutomovilElement = driver.FindElement(colorAutomovilLocator);
                    IWebElement puertasAutomovilElement = driver.FindElement(puertasAutomovilLocator);
                    
                    string automovil = marcaAutomovilElement.Text + " " + modeloAutomovilElement.Text
                                       + " " + colorAutomovilElement.Text + " " + puertasAutomovilElement.Text;
                    automoviles.Add(automovil);
                    index++;
                }
                catch (NoSuchElementException)
                {
                    // No se encontró el siguiente automóvil, terminar el bucle
                    existeSiguienteAutomovil = false;
                }
            }
            return automoviles;
        }

        public void EliminarUltimoAutomovilEnVista()
        {
            int totalAutomoviles = driver.FindElements(botonEliminarLink).Count;

            if (totalAutomoviles > 0)
            {
                By eliminarLinkLocator = By.CssSelector($"tr:nth-child({totalAutomoviles}) > td > a[href*='Eliminar']");
                IWebElement eliminarLinkElement = driver.FindElement(eliminarLinkLocator);
                eliminarLinkElement.Click();
                // Manejar la alerta
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();  // o alert.Dismiss() para  cancelar la alerta
            }
        }
    }
}
