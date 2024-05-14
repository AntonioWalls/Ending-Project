USE PROYECTO_WEB

CREATE TABLE Inmobiliaria (
id_Inmobiliaria int not null,
razon_social varchar(50),
rfc varchar(13),
telefono varchar(10)
PRIMARY KEY (id_Inmobiliaria)
)

CREATE TABLE Remate(
id_Remate int not null,
id_Inmobiliaria int not null,
fiscalia varchar(50),
estado bit not null, --define si el remate está activo (1) o está cerrado (0)
fecha date,
descripcion varchar(100),
PRIMARY KEY (id_Remate),
FOREIGN KEY (id_Inmobiliaria) REFERENCES Inmobiliaria(id_inmobiliaria)
)


CREATE TABLE Propiedad (
id_Propiedad int not null,
calle varchar(30),
num varchar(10),
colonia varchar(50),
municipio varchar(30),
estado varchar(30),
cp int,
subtipo varchar(20),
latitud float,
altitud float,
superficie_terreno float,
superficie_cons float
PRIMARY KEY (id_Propiedad)
)
CREATE TABLE Litigioso (
id_Litigioso int not null,
nombres varchar (60),
apellidos varchar(60),
rfc varchar(13),
curp varchar(18),
telefono varchar(10),
calle varchar(30),
num varchar(10),
colonia varchar(50),
municipio varchar(30),
estado varchar(30),
cp int,
PRIMARY KEY (id_Litigioso)
)

CREATE TABLE Litigio (
id_Litigio int not null,
id_Litigioso int not null,
id_Remate int not null,
procedimiento varchar(100),
juzgado varchar (50),
expediente varchar(30),
edo_juzgado varchar(30),
adeudo_total float,
PRIMARY KEY (id_Litigio),
FOREIGN KEY (id_Litigioso) REFERENCES Litigioso(Id_Litigioso),
FOREIGN KEY (id_Remate) REFERENCES Remate(id_Remate)
)


CREATE TABLE Adjudicado (
id_Adjudicado int not null,
id_Remate int not null,
nombres varchar (60),
apellidos varchar(60),
rfc varchar(13),
curp varchar(18),
telefono varchar(10),
calle varchar(30),
num varchar(10),
colonia varchar(50),
municipio varchar(30),
estado varchar(30),
cp int,
semafono_escrituracion varchar(20),
consideraciones varchar(100),
estadoAdjudicacion bit, --mismo caso que el anterior, 1 si ya se adjudico, 0 en caso negativo
PRIMARY KEY (id_Adjudicado),
FOREIGN KEY (id_Remate) REFERENCES Remate(id_Remate)
)

CREATE TABLE Incluye (
id_Propiedad int not null,
id_Litigioso int not null,
id_Litigio int not null,
id_Adjudicado int not null
PRIMARY KEY (id_Propiedad, id_Litigioso, id_Litigio, id_Adjudicado),
FOREIGN KEY (id_Propiedad) REFERENCES Propiedad(id_Propiedad),
FOREIGN KEY (id_Litigioso) REFERENCES Litigioso(id_Litigioso),
FOREIGN KEY (id_Litigio) REFERENCES Litigio(id_Litigio),
FOREIGN KEY (id_Adjudicado) REFERENCES Adjudicado(id_Adjudicado)

)

-- Insertando datos en la tabla Inmobiliaria
INSERT INTO Inmobiliaria (id_Inmobiliaria, razon_social, rfc, telefono)
VALUES (1, 'Inmobiliaria Ejemplo', 'RFC123456789', '1234567890');

-- Insertando datos en la tabla Remate
INSERT INTO Remate (id_Remate, id_Inmobiliaria, fiscalia, estado, fecha, descripcion)
VALUES (1, 1, 'Fiscalia Ejemplo', 1, '2024-05-10', 'Remate de propiedad');

-- Insertando datos en la tabla Propiedad
INSERT INTO Propiedad (id_Propiedad, calle, num, colonia, municipio, estado, cp, subtipo, latitud, altitud, superficie_terreno, superficie_cons)
VALUES (1, 'Calle Ejemplo', '10', 'Colonia Ejemplo', 'Municipio Ejemplo', 'Estado Ejemplo', 12345, 'Casa', 19.4326, -99.1332, 200.0, 150.0);

-- Insertando datos en la tabla Litigioso
INSERT INTO Litigioso (id_Litigioso, nombres, apellidos, rfc, curp, telefono, calle, num, colonia, municipio, estado, cp)
VALUES (1, 'Nombre', 'Apellido', 'RFC123456789', 'CURP123456789012', '1234567890', 'Calle Ejemplo', '10', 'Colonia Ejemplo', 'Municipio Ejemplo', 'Estado Ejemplo', 12345);

-- Insertando datos en la tabla Litigio
INSERT INTO Litigio (id_Litigio, id_Litigioso, id_Remate, procedimiento, juzgado, expediente, edo_juzgado, adeudo_total)
VALUES (1, 1, 1, 'Procedimiento Ejemplo', 'Juzgado Ejemplo', 'EXP123', 'Estado Juzgado', 1000000.0);

-- Insertando datos en la tabla Adjudicado
INSERT INTO Adjudicado (id_Adjudicado, id_Remate, nombres, apellidos, rfc, curp, telefono, calle, num, colonia, municipio, estado, cp, semafono_escrituracion, consideraciones, estadoAdjudicacion)
VALUES (1, 1, 'Nombre', 'Apellido', 'RFC123456789', 'CURP123456789012', '1234567890', 'Calle Ejemplo', '10', 'Colonia Ejemplo', 'Municipio Ejemplo', 'Estado Ejemplo', 12345, 'Verde', 'Consideraciones Ejemplo', 1);

-- Insertando datos en la tabla Incluye
INSERT INTO Incluye (id_Propiedad, id_Litigioso, id_Litigio, id_Adjudicado)
VALUES (1, 1, 1, 1);




-- Insertando datos en la tabla Inmobiliaria
INSERT INTO Inmobiliaria (id_Inmobiliaria, razon_social, rfc, telefono)
VALUES (2, 'Inmobiliaria Ejemplo 2', 'RFC234567890', '2345678901');

-- Insertando datos en la tabla Remate
INSERT INTO Remate (id_Remate, id_Inmobiliaria, fiscalia, estado, fecha, descripcion)
VALUES (2, 2, 'Fiscalia Ejemplo 2', 0, '2024-05-11', 'Remate de propiedad 2');

-- Insertando datos en la tabla Propiedad
INSERT INTO Propiedad (id_Propiedad, calle, num, colonia, municipio, estado, cp, subtipo, latitud, altitud, superficie_terreno, superficie_cons)
VALUES (2, 'Calle Ejemplo 2', '20', 'Colonia Ejemplo 2', 'Municipio Ejemplo 2', 'Estado Ejemplo 2', 23456, 'Departamento', 19.4326, -99.1332, 300.0, 250.0);

-- Insertando datos en la tabla Litigioso
INSERT INTO Litigioso (id_Litigioso, nombres, apellidos, rfc, curp, telefono, calle, num, colonia, municipio, estado, cp)
VALUES (2, 'Nombre 2', 'Apellido 2', 'RFC234567890', 'CURP234567890012', '2345678901', 'Calle Ejemplo 2', '20', 'Colonia Ejemplo 2', 'Municipio Ejemplo 2', 'Estado Ejemplo 2', 23456);

-- Insertando datos en la tabla Litigio
INSERT INTO Litigio (id_Litigio, id_Litigioso, id_Remate, procedimiento, juzgado, expediente, edo_juzgado, adeudo_total)
VALUES (2, 2, 2, 'Procedimiento Ejemplo 2', 'Juzgado Ejemplo 2', 'EXP234', 'Estado Juzgado 2', 2000000.0);

-- Insertando datos en la tabla Adjudicado
INSERT INTO Adjudicado (id_Adjudicado, id_Remate, nombres, apellidos, rfc, curp, telefono, calle, num, colonia, municipio, estado, cp, semafono_escrituracion, consideraciones, estadoAdjudicacion)
VALUES (2, 2, 'Nombre 2', 'Apellido 2', 'RFC234567890', 'CURP234567890012', '2345678901', 'Calle Ejemplo 2', '20', 'Colonia Ejemplo 2', 'Municipio Ejemplo 2', 'Estado Ejemplo 2', 23456, 'Rojo', 'Consideraciones Ejemplo 2', 0);

-- Insertando datos en la tabla Incluye
INSERT INTO Incluye (id_Propiedad, id_Litigioso, id_Litigio, id_Adjudicado)
VALUES (2, 2, 2, 2);
