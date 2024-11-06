-- Tabla Provincia
CREATE TABLE Provincia (
    Id TINYINT NOT NULL IDENTITY(1,1),  
    Nombre NVARCHAR(50) NOT NULL,
    Codigo31662 CHAR(4) NOT NULL,
    CONSTRAINT PK_Provincia PRIMARY KEY (Id),
    CONSTRAINT UQ_Provincia_Codigo31662 UNIQUE (Codigo31662)
);

-- Tabla Localidad
CREATE TABLE Localidad (
    Id INT NOT NULL IDENTITY(1,1),
    ProvinciaId TINYINT NOT NULL,
    Nombre NVARCHAR(50) NOT NULL,
    CodigoPostal SMALLINT NOT NULL,
    CONSTRAINT PK_Localidad PRIMARY KEY (Id),
    CONSTRAINT FK_Localidad_Provincia FOREIGN KEY (ProvinciaId)
        REFERENCES Provincia (Id)
        ON DELETE NO ACTION
        ON UPDATE NO ACTION
);

-- Modifica Tabla Direccion
-- Cambia el nombre de la columna Direccion a Calle
EXEC sp_rename 'Direccion.Direccion', 'Calle', 'COLUMN';

-- columnas Numero, IdProvincia e IdLocalidad
ALTER TABLE Direccion
ADD 
    Numero INT NOT NULL,                     
    IdProvincia TINYINT NOT NULL,            
    IdLocalidad INT NOT NULL;                

-- claves foráneas 
ALTER TABLE Direccion
ADD CONSTRAINT FK_Direccion_Provincia 
    FOREIGN KEY (IdProvincia) REFERENCES Provincia(Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
    
    CONSTRAINT FK_Direccion_Localidad 
    FOREIGN KEY (IdLocalidad) REFERENCES Localidad(Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION;
