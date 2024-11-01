Create Database ECOMMERCE_EQUIPO15B
Collate Latin1_General_CI_AI
Go
Use ECOMMERCE_EQUIPO15B

CREATE table Tarjeta(
	IdTarjeta int primary key identity(1,1),
	NumeroTarjeta int not null
)

CREATE table Direccion(
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
IDDireccion int null foreign key references Direccion(IdDireccion),
IDTarjeta int null foreign key references Tarjeta(IDTarjeta),
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
UrlImagen varchar(5000) not null
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

Create Procedure sp_listarMarcas
As
Begin
	Select IDMarca, Nombre, Estado from Marcas
End
go

Create Procedure sp_listarCategorias
As
Begin
	Select IDCategoria, Nombre, IDCategoriaPadre, Estado from Categorias
End
go

Create Procedure sp_listarSubcategorias(
@idCatPadre int= NULL
)
as
Begin
 Select IDCategoria, Nombre, IDCategoriaPadre, Estado 
 from Categorias 
 where (IDCategoriaPadre = @idCatPadre OR (@idCatPadre IS NULL AND IDCategoriaPadre IS NULL));
End
go

Create Procedure sp_ListarUltimasSubcategorias
as
begin
	Select IDCategoria, Nombre, IDCategoriaPadre, Estado from Categorias 
	where IDCategoria not in (select IDCategoriaPadre from Categorias
	where IDCategoriaPadre is not null and Estado=1)
end
go


Create Procedure sp_AgregarArticulo(
@Nombre varchar(100),
@Descripcion varchar(3000),
@IDMarca int,
@IDCategoria int,
@Precio money,
@Stock int
)
as
begin
Insert into Articulos (Nombre, Descripcion, IDMarca, IDCategoria, Precio, Stock, Puntaje, Estado) output inserted.IDArticulo values
(@Nombre, @Descripcion, @IDMarca, @IDCategoria, @Precio, @Stock, 0, 1)
end
go

Create Procedure sp_ModificarArticulo (
@IDArticulo int,
@Nombre varchar(100),
@Descripcion varchar(3000),
@IDMarca int,
@IDCategoria int,
@Precio money,
@Stock int
)
as
begin
Update Articulos set Nombre= @Nombre, Descripcion=@Descripcion, IDMarca=@IDMarca, IDCategoria=@IDCategoria, Precio=@Precio, Stock=@Stock, Puntaje=0, Estado=1
where IDArticulo= @IDArticulo
end
go

Create Procedure sp_AgregarImagen(
 @IDArticulo int,
 @Url varchar(1500)
)
as
begin
Insert Into Imagenes (IDArticulo, UrlImagen) values
(@IDArticulo, @Url)
end
go

Create Procedure sp_EliminarImagenesXArticulo(
 @IDArticulo int
)
as
begin
	delete from Imagenes where IDArticulo= @IDArticulo
end
go

Create Procedure sp_AgregarMarca(
@Nombre varchar(50)
) as
begin
	Insert into Marcas (Nombre, Estado) values
	(@Nombre, 1)
end
go

Create Procedure sp_ModificarMarca(
@IDMarca int,
@Nombre varchar(50)
) 
as
begin
	Update Marcas set Nombre= @Nombre
	where IDMarca= @IDMarca
end
go

Create Procedure sp_AgregarCategoria(
@Nombre varchar(50),
@IDCategoriaPadre int= NULL
) as
begin
	Insert into Categorias (Nombre, IDCategoriaPadre, Estado) values
	(@Nombre, @IDCategoriaPadre, 1)
end
go

Create Procedure sp_ModificarCategoria (
@IDCategoria int,
@Nombre varchar(50),
@IDCategoriaPadre int= NULL
) as
begin
	update Categorias set Nombre= @Nombre, IDCategoriaPadre= @IDCategoriaPadre
	where IDCategoria= @IDCategoria
end
go

Insert into Marcas(Nombre, Estado) values
('Dolce Objetos', 1),
('Ricchezze', 1),
('AMV', 1),
('Sin Marca', 1)
go

Insert into Categorias (Nombre, IDCategoriaPadre, Estado) values
('Muebles de cocina', null, 1),
('Muebles de comedor', null,  1),
('Muebles de dormitorio', null, 1)
Go

Insert into Categorias (Nombre, IDCategoriaPadre, Estado) values
('alacenas', 1, 1),
('bajo mesadas', 1,  1),
('Desayunadores', 1, 1),
('Mesas', 2, 1),
('Camas', 3, 1),
('Mesitas de luz', 3, 1)
Go

Insert into Categorias(Nombre, IDCategoriaPadre, Estado) values
('2 plazas', 8, 1),
('1 plasa', 8, 1),
('Ratonas', 7, 1)
go

Insert Into Articulos(Nombre, Descripcion, IDMarca, IDCategoria, Precio, Stock, Puntaje, Estado) values
('Alacena 1,20 cm Ricchezze Arco Negro', 'MDP 15mm imprimado, Medidas: 460 x 1200 x 270 mm', 2, 4, 80000, 5, 8, 1),
('Bajo Mesada Arco 1,20 cm Negro', 'Material del Producto: Mdp 15mm imprimado. Medidas: Alto: 83 cm Ancho: 120 cm Profundidad: 50 cm Peso: 35 kg', 2, 5, 130000, 4, 9, 1),
('Box de Cama con 4 Cajones + Zapatero Base Somier Blanco', 'Modelo: T6443 EV', 3, 10, 340000, 3, 0, 1),
('Mesa de Luz Flotante Negro Desayunador Cajon Moderno', 'Medidas: 42x24x35cm', 4, 9, 70000, 4, 0, 1)
go

Insert into Imagenes(IDArticulo,UrlImagen) values
(1, 'https://images.fravega.com/f300/421b5390362a977e3c9a48e23806e57c.jpg.webp'),
(1, 'https://images.fravega.com/f300/0a34b31479e4c3065743cb89509f18fd.jpg.webp'),
(2, 'https://images.fravega.com/f300/4c6b4ce3dd3559ae1e19e7132f6e50a6.jpg.webp'),
(2, 'https://images.fravega.com/f300/4bfe1434e0f42d241f3433a115121181.jpg.webp'),
(3, 'https://images.fravega.com/f300/234050136af6ca0890300c223fbed515.jpg.webp'),
(4, 'https://images.fravega.com/f300/11cbcd1f3c3ad912ad24cee136aa4ac9.png.webp'),
(4, 'https://images.fravega.com/f300/18d38a5cb5413051fe6efc2f480582a3.png.webp')
go