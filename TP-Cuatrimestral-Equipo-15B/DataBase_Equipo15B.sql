Create Database ECOMMERCE_EQUIPO15B
Collate Latin1_General_CI_AI
Go
Use ECOMMERCE_EQUIPO15B

Create Table Direccion(
IDDireccion int not null primary key,
Calle varchar(100) not null,
Altura int null,
Ciudad int not null,
CodigoPostal int not null,
Provincia varchar(50) not null
)

Create Table Usuarios(
IDUsuario int not null primary key,
Nombre varchar(50) not null,
Apellido varchar(50) not null,
DNI varchar(10) not null,
Email varchar(250) not null,
Contrasenia varchar(50) not null,
Telefono varchar(50) null,
IDDireccion int null foreign key references Direccion(IDDireccion),
IDTarjeta int null,
UrlFotoPerfil varchar(500) null
)

Create Table Articulos(
IDArticulo int not null primary key,
Nombre varchar(100) not null,
Descripcion varchar(3000) null,
Precio money not null,
IDCategoria int null,
IDMarca int null,
Stock int not null
)