CREATE DATABASE DB_Tickets

USE DB_Tickets

CREATE TABLE Eventos(
    Evento_Id INT NOT NULL IDENTITY(1, 1),
    Evento_Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(1000) NOT NULL,
    Evento_Fecha DATETIME NOT NULL,
    Evento_Lugar VARCHAR(100) NOT NULL,
    Evento_Direccion VARCHAR(500) NOT NULL,
    TotalEntrada INT NOT NULL CHECK(TotalEntrada >= 0),
    Precio MONEY NOT NULL,
    Evento_Imagen VARCHAR(100),
    Estado BIT NOT NULL DEFAULT 1,

    PRIMARY KEY(Evento_Id)
)

CREATE TABLE Usuarios(
    Usuario_Id INT NOT NULL IDENTITY(1, 1),    
    Nombre VARCHAR(25) NOT NULL,
    Apellido VARCHAR(25) NOT NULL,
    Dni VARCHAR(8) NOT NULL,
    Email VARCHAR(50) NOT NULL,
    Telefono VARCHAR(20) NOT NULL,
    FechaNacimiento DATETIME NOT NULL,
    Contrasenia VARCHAR(255) NOT NULL,
    TipoUsuario INT NOT NULL,
    Estado BIT NOT NULL DEFAULT 1,

    PRIMARY KEY(Usuario_Id)
)

CREATE TABLE Compras(
    Compra_Id INT NOT NULL IDENTITY(1, 1),
    Id_Evento INT NOT NULL,
    Id_Usuario INT NOT NULL,
    CantidadEntrada INT NOT NULL,
    Compra_Fecha DATETIME DEFAULT GETDATE(),
    MontoTotal MONEY,
    Estado BIT NOT NULL DEFAULT 1,

    PRIMARY KEY(Compra_Id),
    FOREIGN KEY(Id_Evento) REFERENCES Eventos(Evento_Id),
    FOREIGN KEY(Id_Usuario) REFERENCES Usuarios(Usuario_Id)
)

CREATE TABLE Entradas(
    Entrada_Id INT NOT NULL IDENTITY(1, 1),
    Codigo VARCHAR(5) UNIQUE,
    Id_Compra INT NOT NULL,
    Id_Evento INT NOT NULL,
    Id_Usuario INT NOT NULL,
    Estado BIT NOT NULL DEFAULT 1,

    PRIMARY KEY(Entrada_Id),
    FOREIGN KEY(Id_Compra) REFERENCES Compras(Compra_Id),
    FOREIGN KEY(Id_Evento) REFERENCES Eventos(Evento_Id),
    FOREIGN KEY(Id_Usuario) REFERENCES Usuarios(Usuario_Id)
)

CREATE TABLE ArchivosUsuario (
    Archivo_Id INT NOT NULL IDENTITY(1,1),
    Id_Usuario INT NOT NULL,
    Id_Evento INT NOT NULL,
    NombreArchivo VARCHAR(500) NOT NULL,
    Generacion_Fecha DATETIME DEFAULT GETDATE(),

    PRIMARY KEY(Archivo_Id),
    FOREIGN KEY(Id_Usuario) REFERENCES Usuarios(Usuario_Id),
    FOREIGN KEY(Id_Evento) REFERENCES Eventos(Evento_Id) 
)

GO

CREATE PROCEDURE SP_INSERTAR_USER
(
    @nombre VARCHAR(25),
    @apellido VARCHAR(25),
    @dni VARCHAR(8),    
    @email VARCHAR(50),
    @telefono VARCHAR(20),
    @fecha DATETIME,    
    @pass VARCHAR(255)
)
AS
BEGIN
    INSERT INTO Usuarios(Nombre, Apellido, Dni, Email, Telefono, FechaNacimiento, Contrasenia, TipoUsuario)
    OUTPUT inserted.Usuario_Id VALUES (@nombre, @apellido, @dni, @email, @telefono, @fecha, @pass, 2)
END

GO

CREATE PROCEDURE SP_RegistrarCompraConEntradas
(
    @Id_Evento INT,
    @Id_Usuario INT,
    @CantidadEntrada INT,
    @MontoTotal MONEY
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Compras (Id_Evento, Id_Usuario, CantidadEntrada, MontoTotal)
        VALUES (@Id_Evento, @Id_Usuario, @CantidadEntrada, @MontoTotal);

        DECLARE @Compra_Id INT = SCOPE_IDENTITY();

        DECLARE @i INT = 0;
        WHILE @i < @CantidadEntrada
        BEGIN
            INSERT INTO Entradas (Id_Compra, Id_Evento, Id_Usuario)
            VALUES (@Compra_Id, @Id_Evento, @Id_Usuario);

            SET @i += 1;
        END

        UPDATE Eventos
        SET TotalEntrada = TotalEntrada - @CantidadEntrada
        WHERE Evento_Id = @Id_Evento;

        -- 5. Devolver el ID de la compra
        SELECT @Compra_Id AS CompraId;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH
END

GO

CREATE TRIGGER AsignarCodigoUnico
ON Entradas
AFTER INSERT
AS
BEGIN
    -- Asignar un código único directamente para cada entrada recién insertada
    UPDATE Entradas
    SET Codigo = 
        CHAR(65 + ABS(CHECKSUM(NEWID())) % 26) + -- Letra mayúscula
        CHAR(65 + ABS(CHECKSUM(NEWID())) % 26) + -- Letra mayúscula
        CHAR(65 + ABS(CHECKSUM(NEWID())) % 26) + -- Letra mayúscula
        CHAR(65 + ABS(CHECKSUM(NEWID())) % 26) + -- Letra mayúscula
        CHAR(65 + ABS(CHECKSUM(NEWID())) % 26) -- Letra mayúscula
    FROM Entradas e
    INNER JOIN inserted i ON e.Entrada_Id = i.Entrada_Id;
END

GO
