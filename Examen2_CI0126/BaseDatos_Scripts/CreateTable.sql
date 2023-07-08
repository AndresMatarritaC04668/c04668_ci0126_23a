use C04668 
/*
 Se crea la tabla de Concesionario para guardar
 los datos de los autos
*/
CREATE TABLE concesionario (
    marca VARCHAR(50),
    modelo VARCHAR(50),
    color VARCHAR(30),
    numeroPuertas INT,
    dobleTraccion BIT,
    PRIMARY KEY (modelo, marca)
);


