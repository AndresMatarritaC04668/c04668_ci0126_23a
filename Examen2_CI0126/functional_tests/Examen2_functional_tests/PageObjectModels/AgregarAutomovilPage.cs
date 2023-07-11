using OpenQA.Selenium;

public class AgregarAutomovilPage
{
    private readonly IWebDriver driver;
    private readonly By linkAgregarAutomovil = By.LinkText("Agregar Automóvil");
    private readonly By campoMarca = By.Id("Marca");
    private readonly By campoModelo = By.Id("Modelo");
    private readonly By campoColor = By.Id("Color");
    private readonly By campoNumeroPuertas = By.Id("NumeroPuertas");
    private readonly By checkboxDobleTraccion = By.XPath("(//input[@id='DobleTraccion'])[2]");
    private readonly By botonGuardar = By.CssSelector(".btn");
    private readonly By mensajeAccion = By.Id("mensajeAccion");


    public AgregarAutomovilPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void IrAgregarAutomovilPage()
    {
        driver.FindElement(linkAgregarAutomovil).Click();
    }
    public string AgregarAutomovil(string marca, string modelo, string color, string numeroPuertas)
    {
        driver.FindElement(campoMarca).Click();
        driver.FindElement(campoMarca).SendKeys(marca);
        driver.FindElement(campoModelo).Click();
        driver.FindElement(campoModelo).SendKeys(modelo);
        driver.FindElement(campoColor).Click();
        driver.FindElement(campoColor).SendKeys(color);
        driver.FindElement(campoNumeroPuertas).Click();
        driver.FindElement(campoNumeroPuertas).SendKeys(numeroPuertas);
        driver.FindElement(checkboxDobleTraccion).Click();
        driver.FindElement(botonGuardar).Click();
        var mensajeElement = driver.FindElement(mensajeAccion);
        return mensajeElement.Text;
    }
}
