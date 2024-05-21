CREATE DATABASE PROYECTO_WEB
USE PROYECTO_WEB

CREATE TABLE Inmobiliaria (
id_Inmobiliaria int identity(1,1) not null,
razon_social varchar(50),
rfc varchar(13),
telefono varchar(10)
PRIMARY KEY (id_Inmobiliaria)
)

CREATE TABLE Remate(
id_Remate int identity(1,1) not null,
id_Inmobiliaria int not null,
fiscalia varchar(50),
estado bit not null, --define si el remate est� activo (1) o est� cerrado (0)
fecha date,
descripcion varchar(100),
PRIMARY KEY (id_Remate),
FOREIGN KEY (id_Inmobiliaria) REFERENCES Inmobiliaria(id_inmobiliaria)
)


CREATE TABLE Propiedad (
id_Propiedad int identity(1,1) not null,
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
id_Litigioso int identity(1,1) not null,
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
id_Litigio int identity(1,1) not null,
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
id_Adjudicado int identity(1,1) not null,
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
INSERT INTO Inmobiliaria (razon_social, rfc, telefono)
VALUES ('Inmobiliaria 1', 'RFC1', '1234567890'),
       ('Inmobiliaria 2', 'RFC2', '0987654321'),
       ('Inmobiliaria 3', 'RFC3', '1122334455');

-- Insertando datos en la tabla Remate
INSERT INTO Remate (id_Inmobiliaria, fiscalia, estado, fecha, descripcion)
VALUES (1, 'Fiscalia 1', 1, '2024-05-20', 'Descripcion 1'),
       (2, 'Fiscalia 2', 0, '2024-05-21', 'Descripcion 2'),
       (3, 'Fiscalia 3', 1, '2024-05-22', 'Descripcion 3');

-- Insertando datos en la tabla Propiedad
INSERT INTO Propiedad (calle, num, colonia, municipio, estado, cp, subtipo, latitud, altitud, superficie_terreno, superficie_cons)
VALUES ('Calle 1', '10', 'Colonia 1', 'Municipio 1', 'Estado 1', 12345, 'Subtipo 1', 19.4326, 99.1332, 100.0, 200.0),
       ('Calle 2', '20', 'Colonia 2', 'Municipio 2', 'Estado 2', 67890, 'Subtipo 2', 20.5000, 98.2000, 150.0, 250.0),
       ('Calle 3', '30', 'Colonia 3', 'Municipio 3', 'Estado 3', 11121, 'Subtipo 3', 21.1619, 86.8515, 200.0, 300.0);

-- Insertando datos en la tabla Litigioso
INSERT INTO Litigioso (nombres, apellidos, rfc, curp, telefono, calle, num, colonia, municipio, estado, cp)
VALUES ('Nombre1', 'Apellido1', 'RFC1', 'CURP1', '1234567890', 'Calle 1', '10', 'Colonia 1', 'Municipio 1', 'Estado 1', 12345),
       ('Nombre2', 'Apellido2', 'RFC2', 'CURP2', '0987654321', 'Calle 2', '20', 'Colonia 2', 'Municipio 2', 'Estado 2', 67890),
       ('Nombre3', 'Apellido3', 'RFC3', 'CURP3', '1122334455', 'Calle 3', '30', 'Colonia 3', 'Municipio 3', 'Estado 3', 11121);

-- Insertando datos en la tabla Litigio
INSERT INTO Litigio (id_Litigioso, id_Remate, procedimiento, juzgado, expediente, edo_juzgado, adeudo_total)
VALUES (1, 1, 'Procedimiento 1', 'Juzgado 1', 'Expediente 1', 'Estado Juzgado 1', 1000.0),
       (2, 2, 'Procedimiento 2', 'Juzgado 2', 'Expediente 2', 'Estado Juzgado 2', 2000.0),
       (3, 3, 'Procedimiento 3', 'Juzgado 3', 'Expediente 3', 'Estado Juzgado 3', 3000.0);

-- Insertando datos en la tabla Adjudicado
INSERT INTO Adjudicado (id_Remate, nombres, apellidos, rfc, curp, telefono, calle, num, colonia, municipio, estado, cp, semafono_escrituracion, consideraciones, estadoAdjudicacion)
VALUES (1, 'Nombre1', 'Apellido1', 'RFC1', 'CURP1', '1234567890', 'Calle 1', '10', 'Colonia 1', 'Municipio 1', 'Estado 1', 12345, 'Semaforo 1', 'Consideraciones 1', 1),
       (2, 'Nombre2', 'Apellido2', 'RFC2', 'CURP2', '0987654321', 'Calle 2', '20', 'Colonia 2', 'Municipio 2', 'Estado 2', 67890, 'Semaforo 2', 'Consideraciones 2', 0),
       (3, 'Nombre3', 'Apellido3', 'RFC3', 'CURP3', '1122334455', 'Calle 3', '30', 'Colonia 3', 'Municipio 3', 'Estado 3', 11121, 'Semaforo 3', 'Consideraciones 3', 1);

-- Insertando datos en la tabla Incluye
INSERT INTO Incluye (id_Propiedad, id_Litigioso, id_Litigio, id_Adjudicado)
VALUES (1, 1, 1, 1),
       (2, 2, 2, 2),
       (3, 3, 3, 3);
