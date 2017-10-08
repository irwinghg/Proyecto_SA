--creacion bases de datos

create database importadora_sa;
create database envios_sa;
create database sat_sa;
create database aduana_sa;
create database bancos_sa;


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