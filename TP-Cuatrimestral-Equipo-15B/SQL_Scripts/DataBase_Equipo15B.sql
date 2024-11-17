Create Database ECOMMERCE_EQUIPO15B
Collate Latin1_General_CI_AI
Go
Use ECOMMERCE_EQUIPO15B

CREATE TABLE MetodoPago(
	IdMetodoPago INT PRIMARY KEY IDENTITY,
	Nombre NVARCHAR(50) NOT NULL,
	Descripcion NVARCHAR(100),
	Activo BIT NOT NULL DEFAULT 1
);
go

--CREATE TABLE Pedido(
--	IdPedido INT PRIMARY KEY IDENTITY,
--    FechaPedido DATETIME NOT NULL DEFAULT GETDATE(),
--	TipoEntrega VARCHAR(10),
--    NombreCliente NVARCHAR(50) NOT NULL,
--    ApellidoCliente NVARCHAR(50) NOT NULL,
--    Email NVARCHAR(100) NOT NULL,
--    Telefono NVARCHAR(20) NOT NULL,
--	DNI NVARCHAR(20) NOT NULL,
--    Calle NVARCHAR(100) NULL,
--    Numero NVARCHAR(10) NULL,
--    CodigoPostal NVARCHAR(10) NULL,
--    Provincia NVARCHAR(50) NULL,
--    IdMetodoPago INT NOT NULL,
--    Total DECIMAL(10, 2) NOT NULL,
    
--    FOREIGN KEY (IdMetodoPago) REFERENCES MetodoPago(IdMetodoPago)
--);
--go


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

Create Table DatosPersonales(
IDDatosPersonales int primary key identity(1,1),
Nombre varchar(50) not null,
Apellido varchar(50) not null,
DNI varchar(10) not null,
Telefono varchar(50) null,
UrlFotoPerfil varchar(500) null
)
go

Create Table Usuarios(
IDUsuario int not null primary key identity(1,1),
Email varchar(250) not null unique,
Contrasenia varchar(50) not null,
IDTipoUsuario int not null,
IDDatosPersonales int null foreign key references DatosPersonales(IDDatosPersonales),
IDDireccion int null foreign key references Direccion(IdDireccion),
Estado bit not null
)
go

Create Table Categorias(
IDCategoria int not null primary key identity(1,1),
Nombre varchar(50) not null,
IDCategoriaPadre int null,
Estado bit not null,
FOREIGN KEY (IDCategoriaPadre) REFERENCES Categorias(IDCategoria)
)
go

Create Table Colecciones(
IDColeccion int not null primary key identity(1,1),
Nombre varchar(50) not null,
Estado bit not null
)
go

Create Table Articulos(
IDArticulo int not null primary key identity(1,1),
Nombre varchar(100) not null,
Descripcion varchar(3000) null,
IDColeccion int null foreign key references Colecciones(IDColeccion),
IDCategoria int not null foreign key references Categorias(IDCategoria),
Precio money not null,
Stock int not null,
Puntaje decimal(3,1) null,
Estado bit not null
)
go

CREATE TABLE Pedido(
	IdPedido INT PRIMARY KEY IDENTITY,
	IDUsuario int foreign key references Usuarios(IDUsuario),
    FechaPedido DATETIME NOT NULL DEFAULT GETDATE(),
	TipoEntrega VARCHAR(10),
    IdMetodoPago INT NOT NULL foreign key references MetodoPago(IdMetodoPago),
	EstadoPedido int not null,
    Total DECIMAL(10, 2) NOT NULL
);
go

CREATE TABLE PedidoDetalle (
    IdDetalle INT PRIMARY KEY IDENTITY,
    IdPedido INT NOT NULL,
    IdArticulo INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(18, 2) NOT NULL,
    Subtotal AS (Cantidad * PrecioUnitario) PERSISTED,
    FOREIGN KEY (IdPedido) REFERENCES Pedido(IdPedido),
    FOREIGN KEY (IDArticulo) REFERENCES Articulos (IDArticulo)
);


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

Create procedure sp_InciarSesion(
@Email varchar(250),
@Contrasenia varchar(50)
)as
begin
	Select IDUsuario, Email, Contrasenia, IDTipoUsuario, IDDatosPersonales, IDDireccion, Estado from Usuarios where Email=@Email and Contrasenia=@Contrasenia and Estado= 1
end
go

Create procedure sp_AgregarUsuario(
@Email varchar(250),
@Contrasenia varchar(50),
@Estado bit
)as
begin
	Insert into Usuarios (Email, Contrasenia, IDTipoUsuario, Estado) output inserted.IDUsuario values 
	(@Email, @Contrasenia, 2, @Estado)
end
go



Create Procedure sp_ListarUsuarios
as
begin
 Select IDUsuario, Email, Contrasenia, IDDatosPersonales, IDDireccion, Estado from Usuarios where IDTipoUsuario=2 and Estado=1
end
go

Create Procedure sp_AgregarDatosPersonales(
@IDUsuario int,
@Nombre varchar(50),
@Apellido varchar(50),
@DNI varchar(10),
@Telefono varchar(50),
@UrlFotoPerfil varchar(500)
) as
begin
 begin try
 begin transaction
 declare @IDDatos int;
 Insert into DatosPersonales(Nombre, Apellido, Dni, Telefono, UrlFotoPerfil) values
 (@Nombre, @Apellido, @Dni, @Telefono, @UrlFotoPerfil)
 set @IDDatos= SCOPE_IDENTITY();
 Update Usuarios set IDDatosPersonales= @IDDatos where IDUsuario=@IDUsuario
 commit transaction
 end try
 begin catch
 rollback transaction
 end catch
end
go

Create Procedure sp_ModificarDatosPersonales(
@IDUsuario int,
@Nombre varchar(50),
@Apellido varchar(50),
@DNI varchar(10),
@Telefono varchar(50),
@UrlFotoPerfil varchar(500)
) as
begin
 Update DP Set DP.Nombre=@Nombre, DP.Apellido=@Apellido, DP.DNI=@Dni, DP.Telefono=@Telefono, DP.UrlFotoPerfil=@UrlFotoPerfil
 from DatosPersonales DP
 inner join Usuarios U on U.IDDatosPersonales= DP.IDDatosPersonales
 where U.IDUsuario= @IDUsuario
end
go


Create Procedure sp_BuscarDatosPersonales(
@IDUsuario int
)
as
begin
 Select Nombre, Apellido, Dni, Telefono, UrlFotoPerfil
 from DatosPersonales DP
 Inner join Usuarios U on U.IDDatosPersonales= DP.IDDatosPersonales
 where U.IDUsuario= @IDUsuario
end
go

Create Procedure sp_AgregarDireccion(
@IDUsuario int,
@Calle varchar(100),
@Numero INT,                     
@IdProvincia TINYINT,            
@IdLocalidad INT
) as
begin
	begin try
	begin transaction
	Declare @IDDireccion int;
	Insert into Direccion (Calle, Numero, IdProvincia, IdLocalidad) values
	(@Calle, @Numero, @IdProvincia, @IdLocalidad)
	Set @IDDireccion= SCOPE_IDENTITY();
	Update Usuarios set IDDireccion= @IDDireccion where IDUsuario=@IDUsuario
	commit transaction
	end try
	begin catch
	rollback transaction
	end catch
end
go

Create Procedure sp_ModificarDireccion(
@IDUsuario int,
@Calle varchar(100),
@Numero INT,                     
@IdProvincia TINYINT,            
@IdLocalidad INT
) as
begin
	Update D set Calle=@Calle, Numero=@Numero, IdProvincia=@IdProvincia, IdLocalidad=@IdLocalidad
	from Direccion D 
	inner join Usuarios U on U.IDDireccion= D.IdDireccion
	where U.IDUsuario= @IDUsuario
end
go


Create Procedure sp_BuscarDireccion(
@IDUsuario int
) as
begin
	Select D.Calle, D.Numero, D.IdProvincia, P.Nombre as 'NombreProvincia', P.Codigo31662, D.IdLocalidad, L.Nombre as 'NombreLocalidad', L.CodigoPostal, L.ProvinciaId from Direccion D
	inner join Usuarios U on U.IDDireccion= D.IdDireccion
	Inner join Provincia P on P.Id= D.IdProvincia
	INNER JOIN Localidad L on L.Id= D.IdLocalidad
	where U.IDUsuario= @IDUsuario
end
go

create Procedure sp_listarArticulos
As
Begin
	Select A.IDArticulo, A.Nombre, A.Descripcion, A.IDColeccion, CO.Nombre as 'NombreColeccion', A.IDCategoria, C.Nombre as 'NombreCategoria', A.Precio, A.Stock, a.Puntaje, A.Estado 
	from Articulos A
	INNER JOIN Colecciones CO ON CO.IDColeccion=A.IDColeccion
	INNER JOIN Categorias C on C.IDCategoria= A.IDCategoria
End
go

Create Procedure sp_AgregarArticulo(
@Nombre varchar(100),
@Descripcion varchar(3000),
@IDColeccion int,
@IDCategoria int,
@Precio money,
@Stock int
)
as
begin
Insert into Articulos (Nombre, Descripcion, IDColeccion, IDCategoria, Precio, Stock, Puntaje, Estado) output inserted.IDArticulo values
(@Nombre, @Descripcion, @IDColeccion, @IDCategoria, @Precio, @Stock, 0, 1)
end
go

Create Procedure sp_ModificarArticulo (
@IDArticulo int,
@Nombre varchar(100),
@Descripcion varchar(3000),
@IDColeccion int,
@IDCategoria int,
@Precio money,
@Stock int
)
as
begin
Update Articulos set Nombre= @Nombre, Descripcion=@Descripcion, IDColeccion=@IDColeccion, IDCategoria=@IDCategoria, Precio=@Precio, Stock=@Stock, Puntaje=0, Estado=1
where IDArticulo= @IDArticulo
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

Create Procedure sp_listarColecciones
As
Begin
	Select IDColeccion, Nombre, Estado from Colecciones
End
go

Create Procedure sp_AgregarColeccion(
@Nombre varchar(50)
) as
begin
	Insert into Colecciones (Nombre, Estado) values
	(@Nombre, 1)
end
go

Create Procedure sp_ModificarColeccion(
@IDColeccion int,
@Nombre varchar(50)
) 
as
begin
	Update Colecciones set Nombre= @Nombre
	where IDColeccion= @IDColeccion
end
go

Create Procedure sp_EliminarColeccionLogicamente(
@IDColeccion int,
@Estado bit
)
as
begin
	Update Colecciones set Estado=@Estado where IDColeccion=@IDColeccion
end
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
	where IDCategoriaPadre is not null)
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

Create Procedure sp_EliminarCategoriaLogicamente(
@IDCategoria int,
@Estado bit
)
as
begin
	Update Categorias set Estado= @Estado where IDCategoria= @IDCategoria
end
go

Create Procedure sp_ListarFavoritos(
@IDUsuario int
)as
begin
	Select A.IDArticulo, A.Nombre, A.Descripcion, A.IDColeccion, CO.Nombre as 'NombreColeccion', A.IDCategoria, C.Nombre as 'NombreCategoria', A.Precio, A.Stock, a.Puntaje, A.Estado
	from Favoritos F 
	INNER JOIN Articulos A On F.IDArticulo= A.IDArticulo
	INNER JOIN Colecciones CO On CO.IDColeccion= A.IDColeccion
	INNER JOIN Categorias C On C.IDCategoria= A.IDCategoria
	where IDUsuario=@IDUsuario and A.Estado= 1
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
	raiserror('No se pudo calcular el promedio de la puntuaci�n', 16, 2)
end catch
end
go
