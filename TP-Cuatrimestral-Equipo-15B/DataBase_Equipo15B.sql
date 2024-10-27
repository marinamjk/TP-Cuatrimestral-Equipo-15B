Create Database ECOMMERCE_EQUIPO15B
Collate Latin1_General_CI_AI
Go
Use ECOMMERCE_EQUIPO15B

CREATE table Tarjeta(
	IdTarjeta int primary key identity(1,1),
	NumeroTarjeta int not null
)

CREATE table direccion(
	IdDireccion int primary key identity(1,1),
	Direccion varchar(100) not null
)

Create Table Usuarios(
IDUsuario int not null primary key identity(1,1),
IDTipoUsuario int not null,
Nombre varchar(50) not null,
Apellido varchar(50) not null,
DNI varchar(10) not null,
Email varchar(250) not null unique,
Contrasenia varchar(50) not null,
Telefono varchar(50) null,
IDDireccion int null,
IDTarjeta int null,
UrlFotoPerfil varchar(500) null
)

Create Table Categorias(
IDCategoria int not null primary key identity(1,1),
Nombre varchar(50) not null,
IDCategoriaPadre int null,
Estado bit not null,
FOREIGN KEY (IDCategoriaPadre) REFERENCES Categorias(IDCategoria)
)

Create Table Marcas(
IDMarca int not null primary key identity(1,1),
Nombre varchar(50) not null,
Estado bit not null
)

Create Table Articulos(
IDArticulo int not null primary key identity(1,1),
Nombre varchar(100) not null,
Descripcion varchar(3000) null,
IDMarca int null foreign key references Marcas(IDMarca),
IDCategoria int not null foreign key references Categorias(IDCategoria),
Precio money not null,
Stock int not null,
Puntaje decimal null,
Estado bit not null
)

Create Table Imagenes(
IDImagen int not null primary key identity(1,1),
IDArticulo int not null foreign key references Articulos(IDArticulo),
UrlImagen varchar(1500) not null
)

go

Create Procedure sp_listarArticulos
As
Begin
	Select A.IDArticulo, A.Nombre, A.Descripcion, A.IDMarca, M.Nombre as 'NombreMarca', A.IDCategoria, C.Nombre as 'NombreCategoria', A.Precio, A.Stock, a.Puntaje, A.Estado 
	from Articulos A
	INNER JOIN Marcas M ON M.IDMarca=A.IDMarca
	INNER JOIN Categorias C on C.IDCategoria= A.IDCategoria
End
go

Exec sp_listarArticulos
go
Create Procedure sp_listarMarcas
As
Begin
	Select IDMarca, Nombre, Estado from Marcas
End
go
go
Exec sp_listarMarcas
go
Create Procedure sp_listarCategorias
As
Begin
	Select IDCategoria, Nombre, IDCategoriaPadre, Estado from Categorias
End
go
go
Exec sp_listarCategorias
go

Insert into Marcas(Nombre, Estado) values
('Samsung', 1),
('Lenovo', 1),
('Motorola', 1),
('Logitech', 1)
go

Insert into Categorias (Nombre, Estado) values
('Notebook', 1),
('Celulares', 1),
('Accesorios', 1)
Go

Insert into Categorias(Nombre, IDCategoriaPadre, Estado) values
('Core i5', 1, 1),
('Core i6', 1, 1),
('Con camara 13 mpx', 2, 1),
('con Camara 15px', 2, 1),
('Inalámbricos', 3, 1),
('No inalámbricos', 3, 1)

go
Insert Into Articulos(Nombre, Descripcion, IDMarca, IDCategoria, Precio, Stock, Puntaje, Estado) values
('Notebook IdeaPad Slim 3i 15', '8va Gen - Arctic Grey', 1, 1, 1000000, 5, 0, 1),
('CELULAR SAMSUNG SM-G990E S21 FE BLANCO BLANCO', 'Celular de 6.4" Ifinity-O display Dynamic Amoled 2X. Procesador Exynos 2100 / Octa Core 2.9 GHz, 2.8 GHz, 2.2GHz. Resolucion 2340 x 1080 (FHD+). Almacenamiento 128 Gb / RAM 6 Gb. Camara posterior 12 + 12 + 8 mp, F1.8 , F2.2 , F2.4 / trasera 32 mp, F2.2. Resolucion de video UHD 8K (7680 x 4320) 60fps. Slow motion 960fps HD,240fps FHD. 5G. USB 3.2 gen 1 Type C. GPS,Glonass,Beidou,Galileo,QZSS. Wi Fi 802.11 a/b/g/n/ac/ax 2.4G+5GHz, HE80, MIMO, 1024-QAM. Bluetooth v5.0. NFC, IP68. Sistema operativo Android. Navegador: Chrome.Sensores: Accelerometer, Barometer, Fingerprint Sensor, Gyro Sensor, Geomagnetic Sensor, Hall Sensor, Light Sensor, Proximity Sensor. Bateria de 4500 mAh. Samsung DeX support. No incluye cargador', 2, 2, 2949999.00,7, 0, 1),
('Teclado Mecanico', 'ASUS ROG Strix XA05 Scope Switch RX Red RGB', 3, 3, 142990 ,12, 0, 1)
go

Insert into Imagenes(IDArticulo,UrlImagen) values
(1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTudecQ4HP8Oe5SATs_mFT6AOXVk9ZQ7nRzsQ&s'),
(2, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSQ45jwDJljVV0w5LqxsZyM2yjapMEe3CeEw&s'),
(2, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSpjal5E1iU9xJa3zpqP13AksywbuPs9F3h7g&s'),
(2, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSevvxhr9duXMHE1QjUkDnDqkI7WKKa1RJ06A&s'),
(3, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQXQ3dBHLc3B2DTxl80iHGUS88ac9xexjaaCg&s'),
(3, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRcjTrk1vkDiW3Ro6Uq7ICToB7gReS9JpGUVw&s')