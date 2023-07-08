use C04668 
/*
 Se crea la tabla de Concesionario para guardar
 los datos de los autos
*/
CREATE TABLE concesionario (
    marca VARCHAR(50) not null,
    modelo VARCHAR(50) not null,
    color VARCHAR(30) not null,
    numeroPuertas INT not null,
    dobleTraccion BIT not null,
    PRIMARY KEY (modelo, marca)
);



