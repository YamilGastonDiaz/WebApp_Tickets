USE DB_Tickets

--Insert eventos Actuales
INSERT INTO Eventos (Evento_Nombre, Descripcion, Evento_Fecha, Evento_Lugar, Evento_Direccion, TotalEntrada, Precio, Evento_Imagen)
VALUES 
('The Ramones', 'Concierto de PunkRock.', '2025-07-31 21:00:00', 'Club Paraguay', 'Av. Marcelo T. de Alvear 651', 100, 75.00, 'ramones.jpg'),
('The Strokes', 'El mejor rock del año', '2025-08-05 21:00:00', 'Studio Theater', 'Centro, Rosario de Sta. Fe 272', 5000, 150.00, 'strokes.jpg'),
('Sex Pistols', 'Una noche con las mejores canciones', '2025-08-15 22:00:00', 'Petalos de Sol', 'Av. Marcelo T. de Alvear 396', 800, 150.00, 'sexpistols.jpg'),
('David Bowie', 'Veni a disfrutar de una noche inolvidable', '2025-08-29 20:30:00', 'Chilli Street Club', 'Fructuoso Rivera 273', 1000, 50.00, 'davidbowie.jpg'),
('New Order', 'El New wave llego para quedarse', '2025-09-12 21:00:00', 'Pez Volcán', 'Av. Marcelo T. de Alvear 835', 2000, 20.00, 'neworder.jpg'),
('The Cure', 'The Cure viene a presentar nuevo disco', '2025-09-27 20:00:00', 'Captain Blue', 'Blvd. Las Heras 98', 300, 30.00, 'thecure.jpg'),
('Joy Division', 'Los 40 años de la banda', '2025-10-11 22:00:00', 'Plaza de la Música', 'Int. Ramón Bautista Mestre', 1000, 25.00, 'joydivision.jpg'),
('The Clash', 'Por primera vez en Argentina', '2025-10-25 21:30:00', 'Quality Espacio', 'Cruz Roja Argentina 200', 500, 10.00, 'theclash.jpg'),
('Janis Joplin', 'Los mejores éxitos en vivo', '2025-11-08 21:00:00', 'XL Abasto', 'Blvd. Las Heras 124', 3000, 100.00, 'janisjoplin.jpg'),
('Jimi Hendrix', 'Una obra maestra', '2025-11-20 20:00:00', '990 Arte Club', 'Blvd. Los Andes 337', 600, 40.00, 'jimihendrix.jpg');

--Insert Usuarios (pass12345)
INSERT INTO Usuarios (Nombre, Apellido, Dni, Email, Telefono, FechaNacimiento, Contrasenia, TipoUsuario)
VALUES
('Admin', 'Admin', '13000013', 'admin@admin.com', '1010101010', '1985-05-06', 'AQAAAAEAACcQAAAAEC2hOEN9kLTZjr2GGnz2XhpbSsQckezzTywNdzHXrTMe6APaSYbio+6QUVRjeBH3wA==', 1),
('Lucas', 'Martinez', '32145678', 'lucas.martinez@gmail.com', '1144556677', '1990-07-20', 'AQAAAAEAACcQAAAAEC2hOEN9kLTZjr2GGnz2XhpbSsQckezzTywNdzHXrTMe6APaSYbio+6QUVRjeBH3wA==', 2),
('Ana', 'Gomez', '29345678', 'ana.gomez@hotmail.com', '1166788899', '1985-03-10', 'AQAAAAEAACcQAAAAEC2hOEN9kLTZjr2GGnz2XhpbSsQckezzTywNdzHXrTMe6APaSYbio+6QUVRjeBH3wA==', 2),
('Carlos', 'Pérez', '30567890', 'carlosperez@yahoo.com', '1133445566', '1995-12-01', 'AQAAAAEAACcQAAAAEC2hOEN9kLTZjr2GGnz2XhpbSsQckezzTywNdzHXrTMe6APaSYbio+6QUVRjeBH3wA==', 2),
('Julia', 'Fernandez', '30123456', 'julia.fer@gmail.com', '1177889900', '1992-05-15', 'AQAAAAEAACcQAAAAEC2hOEN9kLTZjr2GGnz2XhpbSsQckezzTywNdzHXrTMe6APaSYbio+6QUVRjeBH3wA==', 2),
('Mariano', 'Lopez', '31456789', 'marianolopez@outlook.com', '1122334455', '1988-09-30', 'AQAAAAEAACcQAAAAEC2hOEN9kLTZjr2GGnz2XhpbSsQckezzTywNdzHXrTMe6APaSYbio+6QUVRjeBH3wA==', 2);


