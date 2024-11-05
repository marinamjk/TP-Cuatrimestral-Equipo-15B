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
FOREIGN KEY (IDCategoriaPadre) REFERENCES Categorias(IDCategoria)
)

Create Table Marcas(
IDMarca int not null primary key identity(1,1),
Nombre varchar(50) not null,
)

Create Table Articulos(
IDArticulo int not null primary key identity(1,1),
Nombre varchar(100) not null,
Descripcion varchar(3000) null,
IDMarca int null foreign key references Marcas(IDMarca),
IDCategoria int not null foreign key references Categorias(IDCategoria),
Precio money not null,
Stock int not null,
Puntaje decimal(3,1) null,
Estado bit not null
)

Create Table Imagenes(
IDImagen int not null primary key identity(1,1),
IDArticulo int not null foreign key references Articulos(IDArticulo),
UrlImagen varchar(5000) not null
)
go

Create Table Puntajes(
IDArticulo int,
IDPedido int,
Puntuacion int not null check (Puntuacion>=1 and Puntuacion <=10)
)
go

Create Table Favoritos(
IDUsuario int,
IDArticulo int,
Foreign key(IDUsuario) references Usuarios(IDUsuario),
Foreign key(IDArticulo) references Articulos(IDArticulo),
Primary key (IDUsuario, IDArticulo)
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

Create Procedure sp_EliminarArticuloFisicamente(
@IDArticulo int
)
as
begin
	begin try
		begin transaction
			Delete from Imagenes where IDArticulo = @IDArticulo;
			Delete from Articulos where IDArticulo= @IDArticulo;
		commit transaction
	end try
	begin catch	
		rollback transaction
	end catch
end
go

Create Procedure sp_EliminarArticuloLogicamente(
@IDArticulo int,
@Estado bit
)
as
begin
	Update Articulos set Estado=@Estado where IDArticulo=@IDArticulo
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

Create Procedure sp_listarMarcas
As
Begin
	Select IDMarca, Nombre from Marcas
End
go

Create Procedure sp_AgregarMarca(
@Nombre varchar(50)
) as
begin
	Insert into Marcas (Nombre) values
	(@Nombre)
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

Create Procedure sp_EliminarMarca(
@IDMarca int
)
as
begin
	Delete from Marcas where IDMarca= @IDMarca
end
go

Create Procedure sp_listarCategorias
As
Begin
	Select IDCategoria, Nombre, IDCategoriaPadre from Categorias
End
go

Create Procedure sp_listarSubcategorias(
@idCatPadre int= NULL
)
as
Begin
 Select IDCategoria, Nombre, IDCategoriaPadre 
 from Categorias 
 where (IDCategoriaPadre = @idCatPadre OR (@idCatPadre IS NULL AND IDCategoriaPadre IS NULL));
End
go

Create Procedure sp_ListarUltimasSubcategorias
as
begin
	Select IDCategoria, Nombre, IDCategoriaPadre from Categorias 
	where IDCategoria not in (select IDCategoriaPadre from Categorias
	where IDCategoriaPadre is not null)
end
go

Create Procedure sp_AgregarCategoria(
@Nombre varchar(50),
@IDCategoriaPadre int= NULL
) as
begin
	Insert into Categorias (Nombre, IDCategoriaPadre) values
	(@Nombre, @IDCategoriaPadre)
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

Create Procedure sp_EliminarCategoria(
@IDCategoria int
)
as
begin
	Delete from Categorias where IDCategoria= @IDCategoria
end
go

Create Procedure sp_ListarFavoritos(
@IDUsuario int
)as
begin
	Select IDArticulo from Favoritos where IDUsuario=@IDUsuario
end
go

Create Procedure sp_AgregarAFavoritos(
@IDUsuario int,
@IDArticulo int
)as
begin
	Insert into Favoritos(IDUsuario, IDArticulo)
	values(@IDUsuario, @IDArticulo)
end
go

Create Procedure sp_EliminarDeFavoritos(
@IDUsuario int,
@IDArticulo int
) as
begin
	Delete from Favoritos where IDUsuario=@IDUsuario and IDArticulo=@IDArticulo
end
go

Create Procedure sp_AgregarPuntaje(
@IDArticulo int,
@IDPedido int,
@Puntuacion int
) as
begin
	Insert into Puntajes(IDArticulo, IDPedido, Puntuacion)
	values (@IDArticulo, @IDPedido, @Puntuacion)
end
go

Create or alter Trigger TR_CalcularPuntaje on Puntajes
after insert
as
begin
begin try
	Declare @Puntaje decimal(3,1)
	Select @Puntaje= isNull(AVG(Puntuacion*1.0),0) from Puntajes where IDArticulo = (Select IDArticulo from inserted)
	Update Articulos set Puntaje= @Puntaje where IDArticulo= (Select IDArticulo from inserted)
end try
begin catch
	raiserror('No se pudo calcular el promedio de la puntuación', 16, 2)
end catch
end
go

Insert into Marcas(Nombre) values
('Dolce Objetos'),
('Ricchezze'),
('AMV'),
('Sin Marca')
go

Insert into Categorias (Nombre, IDCategoriaPadre) values
('Muebles de cocina', null),
('Muebles de comedor', null),
('Muebles de dormitorio', null)
Go

Insert into Categorias (Nombre, IDCategoriaPadre) values
('alacenas', 1),
('bajo mesadas', 1),
('Desayunadores', 1),
('Mesas', 2),
('Camas', 3),
('Mesitas de luz', 3)
Go

Insert into Categorias(Nombre, IDCategoriaPadre) values
('2 plazas', 8),
('1 plasa', 8),
('Ratonas', 7)
go

Insert Into Articulos(Nombre, Descripcion, IDMarca, IDCategoria, Precio, Stock, Puntaje, Estado) values
('Alacena 1,20 cm Ricchezze Arco Negro', 'MDP 15mm imprimado, Medidas: 460 x 1200 x 270 mm', 2, 4, 80000, 5, 0, 1),
('Bajo Mesada Arco 1,20 cm Negro', 'Material del Producto: Mdp 15mm imprimado. Medidas: Alto: 83 cm Ancho: 120 cm Profundidad: 50 cm Peso: 35 kg', 2, 5, 130000, 4, 0, 1),
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

Insert into Puntajes(IDArticulo, IDPedido, Puntuacion) values (3, 1, 10.0)
Insert into Puntajes(IDArticulo, IDPedido, Puntuacion) values (3, 2, 9.0)
Insert into Puntajes(IDArticulo, IDPedido, Puntuacion) values (3, 3, 9.0)
Insert into Puntajes(IDArticulo, IDPedido, Puntuacion) values (4, 1, 9.0)
Insert into Puntajes(IDArticulo, IDPedido, Puntuacion) values (4, 2, 8.0)
Insert into Puntajes(IDArticulo, IDPedido, Puntuacion) values (4, 3, 5.0)