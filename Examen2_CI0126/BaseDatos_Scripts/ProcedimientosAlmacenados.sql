use C04668 


/*
  Procedimiento para insertar una tupla en
  la tabla consecionario
*/
go
CREATE PROCEDURE InsertarConcesionario
    @marca VARCHAR(50),
    @modelo VARCHAR(50),
    @color VARCHAR(30),
    @numeroPuertas INT,
    @dobleTraccion BIT
AS
BEGIN
    INSERT INTO concesionario (marca, modelo, color, numeroPuertas, dobleTraccion)
    VALUES (@marca, @modelo, @color, @numeroPuertas, @dobleTraccion)
END;
go



