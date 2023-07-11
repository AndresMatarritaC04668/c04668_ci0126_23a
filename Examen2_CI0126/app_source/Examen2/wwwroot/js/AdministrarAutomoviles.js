function BuscarAutomovilesPorMarca() {
    var marcaInput = document.getElementById("marca-input");
    var errorMessage = document.getElementById("errorMessage");
    var marca = marcaInput.value;



    if (marca.trim() === "") {
        //Input esta vacio
        errorMessage.textContent = "Debes digitar el marca de reserva";
        errorMessage.style.display = "block";
    } else {
        // El formato de fecha es válido, redirigir a la página deseada
        errorMessage.style.display = "none";
        window.location.href = "AdministrarAutomovilesPorMarca?marca=" + marca;
    }
}
