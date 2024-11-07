
-- claves foráneas 
ALTER TABLE Direccion
ADD CONSTRAINT FK_Direccion_Provincia 
    
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
    
    CONSTRAINT FK_Direccion_Localidad 
    
    ON DELETE NO ACTION
    ON UPDATE NO ACTION;
