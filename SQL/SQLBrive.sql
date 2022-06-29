CREATE DATABASE RVillarrealExamenBrive

CREATE TABLE Sucursal (
IdSucursal INT PRIMARY KEY IDENTITY (1,1),
Nombre VARCHAR (50),
Direccion VARCHAR (50),
Telefono VARCHAR (50)
)

CREATE TABLE Producto (
IdProducto INT PRIMARY KEY IDENTITY (1,1),
Nombre VARCHAR (50),
Descripcion VARCHAR (200),
Precio DECIMAL(18,2),
Imagen VARBINARY (MAX),
Stock INT,
CodigoBarras VARCHAR (30)
)
ALTER TABLE Producto ADD CodigoBarras VARCHAR (30)
CREATE TABLE SucursalProducto(
IdSucursalProducto INT PRIMARY KEY IDENTITY (1,1),
IdSucursal INT FOREIGN KEY REFERENCES Sucursal (IdSucursal),
IdProducto INT FOREIGN KEY REFERENCES Producto (IdProducto)
)
ALTER TABLE Producto ALTER COLUMN Imagen VARBINARY (MAX)
DROP TABLE Producto
CREATE TABLE Venta(
IdVenta INT PRIMARY KEY IDENTITY (1,1),
IdUsuario INT FOREIGN KEY REFERENCES Usuario (IdUsuario),
Total DECIMAL (18,2),
IdMetodoPago INT FOREIGN KEY REFERENCES MetodoPago (IdMetodoPago),
FechaVenta VARCHAR (50),
IdDetalleVenta INT FOREIGN KEY REFERENCES DetalleVenta (IdDetalleVenta)
)





CREATE PROCEDURE ProductoAdd
@Nombre VARCHAR (50),
@Descripcion VARCHAR (200),
@Precio DECIMAL (18,2),
@Imagen VARBINARY (MAX),
@Stock INT,
@CodigoBarras VARCHAR (30)
AS 
	INSERT INTO Producto (Nombre,Descripcion, Precio, Imagen, Stock, CodigoBarras)
	VALUES (@Nombre, @Descripcion, @Precio, @Imagen, @Stock, @CodigoBarras)

CREATE PROCEDURE ProductoGetall
AS
	SELECT
		Nombre,
		Descripcion,
		Precio,
		Imagen,
		Stock,
		CodigoBarras
	FROM Producto

CREATE PROCEDURE ProductoGetById
@IdProducto INT
AS
	SELECT
		Nombre,
		Descripcion,
		Precio,
		Imagen,
		Stock,
		CodigoBarras
	FROM Producto
	WHERE IdProducto = @IdProducto

CREATE PROCEDURE ProductoDelete
@IdProducto INT
AS
DELETE FROM Producto
WHERE IdProducto = @IdProducto


CREATE PROCEDURE ProductoUpdate
@IdProducto INT,
@Nombre VARCHAR (50),
@Descripcion VARCHAR (200),
@Precio DECIMAL (18,2),
@Imagen VARBINARY (MAX),
@Stock INT,
@CodigoBarras VARCHAR (30)
AS
BEGIN UPDATE Producto 
SET Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio,
Imagen = @Imagen, Stock = @Stock, CodigoBarras = @CodigoBarras

WHERE IdProducto = @IdProducto
END

SELECT * FROM SucursalProducto
SELECT * FROM Producto
SELECT * FROM Sucursal
INSERT INTO SucursalProducto(IdSucursal, IdProducto)
VALUES (3,7)

CREATE PROCEDURE SucursalProductoGetAll
AS
	SELECT
		IdSucursalProducto,
		SucursalProducto.IdSucursal,
		sucursal.Nombre AS NombreSucursal,
		SucursalProducto.IdProducto,
		producto.Nombre AS NombreProducto,
		producto.Stock
	FROM SucursalProducto
	INNER JOIN Sucursal
	ON Sucursal.IdSucursal = SucursalProducto.IdSucursal
	INNER JOIN Producto
	ON Producto.IdProducto = SucursalProducto.IdProducto

CREATE PROCEDURE SucursalProductoGetById 
@IdSucursalProducto INT
AS
	SELECT
		IdSucursalProducto,
		SucursalProducto.IdSucursal,
		Sucursal.Nombre,
		SucursalProducto.IdProducto,
		Producto.Nombre
	FROM SucursalProducto
	INNER JOIN Sucursal
	ON Sucursal.IdSucursal = SucursalProducto.IdSucursal
	INNER JOIN Producto
	ON Producto.IdProducto = SucursalProducto.IdProducto

WHERE IdSucursalProducto = @IdSucursalProducto

CREATE PROCEDURE SucursalGetAll
AS
	SELECT
		IdSucursal,
		Nombre,
		Direccion,
		Telefono
	FROM Sucursal


CREATE PROCEDURE SucursalAdd 
@Nombre VARCHAR (50),
@Direccion VARCHAR (50),
@Telefono VARCHAR (50)
AS
	INSERT INTO Sucursal (Nombre, Direccion, Telefono)
	VALUES (@Nombre, @Direccion, @Telefono)

SELECT * FROM Sucursal

CREATE PROCEDURE SucursalProductoAdd 
@IdSucursal INT,
@IdProducto INT 
AS
	INSERT INTO SucursalProducto (IdSucursal, IdProducto)
	VALUES (@IdProducto, @IdProducto)


CREATE PROCEDURE SucursalGetByProducto 
@IdProdcuto INT
AS
	SELECT
		Sucursal.IdSucursal,
		Sucursal.Nombre,
		Sucursal.Direccion
	FROM Sucursal
WHERE IdSucursal NOT IN(
SELECT SucursalProducto.IdSucursal FROM SucursalProducto
LEFT JOIN Producto
ON Producto.IdProducto = SucursalProducto.IdProducto
WHERE Producto.IdProducto = @IdProdcuto
)

CREATE PROCEDURE ProductosAsignados 
@IdSucursal INT
AS
	SELECT
		Producto.IdProducto,
		Producto.Nombre AS ProductoNombre,
		Producto.Descripcion,
		Producto.Precio,
		Producto.Imagen
	FROM Producto
	WHERE IdProducto NOT IN (
	SELECT
		Producto.IdProducto FROM SucursalProducto
		LEFT JOIN Producto
		ON Producto.IdProducto = SucursalProducto.IdProducto
		LEFT JOIN Sucursal
		ON Sucursal.IdSucursal = SucursalProducto.IdSucursal
		WHERE Sucursal.IdSucursal = @IdSucursal
	)

CREATE PROCEDURE SucursalGetById 
@IdSucursal INT
AS
	SELECT
		IdSucursal,
		Nombre,
		Direccion,
		Telefono
	FROM Sucursal
WHERE IdSucursal = @IdSucursal

