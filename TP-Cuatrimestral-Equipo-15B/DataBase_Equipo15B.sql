Create Database ECOMMERCE_EQUIPO15B
Collate Latin1_General_CI_AI
Go
Use ECOMMERCE_EQUIPO15B

Create Table Usuarios(
IDUsuario int not null primary key identity(1,1),
IDTipoUsuario int not null,
Nombre varchar(50) not null,
Apellido varchar(50) not null,
DNI varchar(10) not null,
Email varchar(250) not null,
Contrasenia varchar(50) not null,
Telefono varchar(50) null,
IDDireccion int null,
IDTarjeta int null,
UrlFotoPerfil varchar(500) null
)

Create Table Articulos(
IDArticulo int not null primary key identity(1,1),
Codigo varchar(50) not null,
Nombre varchar(100) not null,
Descripcion varchar(3000) null,
IDMarca int null,
IDCategoria int null,
Precio money not null,
Stock int not null
)

Create Table Imagenes(
IDImagen int not null primary key identity(1,1),
IDArticulo int not null foreign key references Articulos(IDArticulo),
UrlImagen varchar(1500) not null
)

go

Insert Into Articulos(Codigo, Nombre, Descripcion, IDMarca, IDCategoria, Precio, Stock) values
('not001', 'Notebook IdeaPad Slim 3i 15', '8va Gen - Arctic Grey', 1, 1, 1000000, 5),
('cel001', 'CELULAR SAMSUNG SM-G990E S21 FE BLANCO BLANCO', 'Celular de 6.4" Ifinity-O display Dynamic Amoled 2X. Procesador Exynos 2100 / Octa Core 2.9 GHz, 2.8 GHz, 2.2GHz. Resolucion 2340 x 1080 (FHD+). Almacenamiento 128 Gb / RAM 6 Gb. Camara posterior 12 + 12 + 8 mp, F1.8 , F2.2 , F2.4 / trasera 32 mp, F2.2. Resolucion de video UHD 8K (7680 x 4320) 60fps. Slow motion 960fps HD,240fps FHD. 5G. USB 3.2 gen 1 Type C. GPS,Glonass,Beidou,Galileo,QZSS. Wi Fi 802.11 a/b/g/n/ac/ax 2.4G+5GHz, HE80, MIMO, 1024-QAM. Bluetooth v5.0. NFC, IP68. Sistema operativo Android. Navegador: Chrome.Sensores: Accelerometer, Barometer, Fingerprint Sensor, Gyro Sensor, Geomagnetic Sensor, Hall Sensor, Light Sensor, Proximity Sensor. Bateria de 4500 mAh. Samsung DeX support. No incluye cargador', 2, 2, 2949999.00,7),
('tec001', 'Teclado Mecanico', 'ASUS ROG Strix XA05 Scope Switch RX Red RGB', 3, 3, 142990 ,12)
go

Insert into Imagenes(IDArticulo,UrlImagen) values
(1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTudecQ4HP8Oe5SATs_mFT6AOXVk9ZQ7nRzsQ&s'),
(2, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSQ45jwDJljVV0w5LqxsZyM2yjapMEe3CeEw&s'),
(2, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSpjal5E1iU9xJa3zpqP13AksywbuPs9F3h7g&s'),
(2, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSevvxhr9duXMHE1QjUkDnDqkI7WKKa1RJ06A&s'),
(3, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQXQ3dBHLc3B2DTxl80iHGUS88ac9xexjaaCg&s'),
(3, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRcjTrk1vkDiW3Ro6Uq7ICToB7gReS9JpGUVw&s')