--creacion bases de datos

create database importadora_sa;
create database envios_sa;
create database sat_sa;
create database aduana_sa;
create database bancos_sa;

use database envios_sa;
CREATE TABLE Marca (
    ID_marca int IDENTITY(1,1) PRIMARY KEY,
    nombre nvarchar(50) NOT NULL
);


CREATE TABLE Linea (
    ID_linea int IDENTITY(1,1) PRIMARY KEY,
    marca int, 
	nombre nvarchar(50) NOT NULL, 
	factor real
);

--envios
CREATE TABLE Transferencia (
    ID_registro int IDENTITY(1,1) PRIMARY KEY,
	ID_transferencia varchar(50) not null,
    monto real not null,
	fecha_hora DATETIME

);



use database aduana_sa;

CREATE TABLE Transferencia (
    ID_registro int IDENTITY(1,1) PRIMARY KEY,
	ID_transferencia varchar(50) not null,
    monto real not null,
	fecha_hora DATETIME

);