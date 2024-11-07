Create Database ECOMMERCE_EQUIPO15B
Collate Latin1_General_CI_AI
Go
Use ECOMMERCE_EQUIPO15B

CREATE table Tarjeta(
	IdTarjeta int primary key identity(1,1),
	NumeroTarjeta int not null
)
go

-- Tabla Provincia
CREATE TABLE Provincia (
    Id TINYINT NOT NULL primary key IDENTITY(1,1),  
    Nombre NVARCHAR(50) NOT NULL,
    Codigo31662 CHAR(4) NOT NULL unique
);
go

CREATE TABLE Localidad (
    Id INT NOT NULL IDENTITY(1,1) primary key,
    ProvinciaId TINYINT NOT NULL,
    Nombre NVARCHAR(50) NOT NULL,
    CodigoPostal SMALLINT NOT NULL,
	FOREIGN KEY (ProvinciaId) REFERENCES Provincia(Id)
);
go

CREATE table Direccion(
	IdDireccion int primary key identity(1,1),
	Calle varchar(100) not null,
	Numero INT NOT NULL,                     
    IdProvincia TINYINT NOT NULL,            
    IdLocalidad INT NOT NULL,
	FOREIGN KEY (IdProvincia) REFERENCES Provincia(Id),
	FOREIGN KEY (IdLocalidad) REFERENCES Localidad(Id),
)
go

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
go

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
go

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
go

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
IF NOT EXISTS (
        SELECT 1 
        FROM Favoritos 
        WHERE IDUsuario = @IDUsuario AND IDArticulo = @IDArticulo
    )
	begin
	Insert into Favoritos(IDUsuario, IDArticulo)
	values(@IDUsuario, @IDArticulo)
	end
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
