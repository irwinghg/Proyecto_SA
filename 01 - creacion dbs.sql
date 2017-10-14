--creacion bases de datos

create database importadora_sa;
create database envios_sa;
create database sat_sa;
create database aduana_sa;
create database bancos_sa;

use database envios_sa;
CREATE TABLE Marca (
    ID_marca int IDENTITY(1,1) PRIMARY KEY,
    nombre nvarchar(50) NOT NULL,
    pais nvarchar(50) not null
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

CREATE TABLE pais (
    ID_pais int IDENTITY(1,1) PRIMARY KEY,
    nombre nvarchar(50) NOT NULL,
    factor decimal (10,2) not null
);


insert into pais(nombre, factor) values('China', 1.2);
insert into pais(nombre, factor) values('Estados Unidos',3.2);
insert into pais(nombre, factor) values('Colombia', 1.5);
insert into pais(nombre, factor) values('Venezuela',0.5);
insert into pais(nombre, factor) values('Brazil', 2.1);
insert into pais(nombre, factor) values('Italia', 3.4);
insert into pais(nombre, factor) values('Guatemala',1.3)


use database aduana_sa;

CREATE TABLE Transferencia (
    ID_registro int IDENTITY(1,1) PRIMARY KEY,
	ID_transferencia varchar(50) not null,
    monto real not null,
	fecha_hora DATETIME

);


