using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2_functional_tests.PageObjectModels
{
    using OpenQA.Selenium;

    public class EditarAutomovilPage
    {
        private IWebDriver driver;

        private readonly By editarLink = By.LinkText("Editar");
        private readonly By alertText = By.CssSelector(".alert");
        private readonly By marcaField = By.Id("Marca");
        private readonly By modeloField = By.Id("Modelo");
        private readonly By colorField = By.Id("Color");
        private readonly By numeroPuertasField = By.Id("NumeroPuertas");
        private readonly By dobleTraccionCheckbox = By.Id("DobleTraccion");
        private readonly By guardarButton = By.CssSelector(".btn");

        public EditarAutomovilPage(IWebDriver driver)
        {
            this.driver = driver;
        }

 
        public void ClickEditar()
        {
            driver.FindElement(editarLink).Click();
            // Manejar la alerta
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();  // o alert.Dismiss() para  cancelar la alerta
        }



        public void FillMarcaField(string marca)
        {
            driver.FindElement(marcaField).Clear();
            driver.FindElement(marcaField).SendKeys(marca);
        }

        public void FillModeloField(string modelo)
        {
            driver.FindElement(modeloField).Clear();
            driver.FindElement(modeloField).SendKeys(modelo);
        }

        public void FillColorField(string color)
        {
            driver.FindElement(colorField).Clear();
            driver.FindElement(colorField).SendKeys(color);
        }

        public void FillNumeroPuertasField(string numeroPuertas)
        {
            driver.FindElement(numeroPuertasField).Clear();
            driver.FindElement(numeroPuertasField).SendKeys(numeroPuertas);
        }

        public void CheckDobleTraccion()
        {
            driver.FindElement(dobleTraccionCheckbox).Click();
        }

        public void ClickGuardar()
        {
            driver.FindElement(guardarButton).Click();
        }
    }

}
