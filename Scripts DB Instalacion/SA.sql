SCRIPT SOFTWARE AVANZADO

BASE DE DATOS (BANCO)

-- CREACION DE TABLAS
CREATE TABLE Usuario(
    ID_Usuario INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(250) NOT NULL,
    Nombre VARCHAR(250) NOT NULL,
    Apellido VARCHAR(250) NOT NULL,
    Fecha_Nacimiento DATE
)

CREATE TABLE Cuenta(
    ID_Cuenta INT IDENTITY(1,1) PRIMARY KEY,
    ID_Usuario INT NOT NULL,
    No_Cuenta INT NOT NULL,
    Saldo DECIMAL(10,2) NOT NULL
)

CREATE TABLE Cuenta_Tarjeta(
    ID_CuentaTarjeta INT IDENTITY(1,1) PRIMARY KEY,
    ID_Cuenta INT NOT NULL,
    No_Tarjeta INT NOT NULL,
    Nombre VARCHAR(250) NOT NULL,
    Fecha_Vencimiento DATE NOT NULL
)

CREATE TABLE Transferencia(
    ID_Transferencia INT IDENTITY(1,1) PRIMARY KEY,
    No_Transferencia VARCHAR(255) NOT NULL,
    ID_CuentaOrigen VARCHAR(250) NOT NULL,
    ID_CuentaDestino VARCHAR(250) NOT NULL,
    Monto DECIMAL(10,2) NOT NULL
)

--DATOS
INSERT INTO Usuario(Username, Nombre, Apellido) VALUES ('Ric25', 'Ricardo Alfredo', 'Sontay Aguilar');
INSERT INTO Usuario(Username, Nombre, Apellido) VALUES ('Yonkis94', 'Jonatan Francisco', 'Gonzalez Donis');
INSERT INTO Usuario(Username, Nombre, Apellido) VALUES ('Frz94', 'Fernando Jose', 'Rodriguez Zacarias');
INSERT INTO Usuario(Username, Nombre, Apellido) VALUES ('Irwin52', 'Irwin Guillermo', 'Hernandez Guerra');

INSERT INTO Cuenta(ID_Usuario, No_Cuenta, Saldo) VALUES ('1', '201314549', '40000');
INSERT INTO Cuenta(ID_Usuario, No_Cuenta, Saldo) VALUES ('2', '201314219', '80000');
INSERT INTO Cuenta(ID_Usuario, No_Cuenta, Saldo) VALUES ('3', '201314720', '40000');
INSERT INTO Cuenta(ID_Usuario, No_Cuenta, Saldo) VALUES ('4', '201047998', '80000');

INSERT INTO Cuenta_Tarjeta(ID_Cuenta, No_Tarjeta, Nombre, Fecha_Vencimiento) VALUES ('1', '201300001', 'RICARDO SONTAY', '2021-12-12');
INSERT INTO Cuenta_Tarjeta(ID_Cuenta, No_Tarjeta, Nombre, Fecha_Vencimiento) VALUES ('2', '201300002', 'JONATAN GONZALEZ', '2021-06-06');
INSERT INTO Cuenta_Tarjeta(ID_Cuenta, No_Tarjeta, Nombre, Fecha_Vencimiento) VALUES ('3', '201300003', 'FERNANDO RODRIGUEZ', '2022-10-02');
INSERT INTO Cuenta_Tarjeta(ID_Cuenta, No_Tarjeta, Nombre, Fecha_Vencimiento) VALUES ('4', '201000001', 'IRWIN HERNANDEZ', '2020-02-19');


BASE DE DATOS (SAT)

-- CREACION DE TABLAS
CREATE TABLE Marca(
    ID_Marca INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(250) NOT NULL
)

CREATE TABLE Linea(
    ID_Linea INT IDENTITY(1,1) PRIMARY KEY,
    Marca INT NOT NULL,
    Nombre VARCHAR(250) NOT NULL,
    Factor DECIMAL(5,2) NOT NULL
)

CREATE TABLE Compra
(
	ID_Compra INT IDENTITY(1,1) PRIMARY KEY,
    ID_Transferencia VARCHAR(255) NOT NULL,
    Monto DECIMAL(10,2) NOT NULL,
)

CREATE TABLE Manifiesto
(
	ID_Manifiesto INT IDENTITY(1,1) PRIMARY KEY,
    Identificador VARCHAR(255) NOT NULL,
    Marca VARCHAR(255) NOT NULL,
    Linea VARCHAR(255) NOT NULL,
    Modelo VARCHAR(255) NOT NULL,
    Fecha_Entrega DATE NOT NULL,
    Pais_Origen VARCHAR(255) NOT NULL
)

CREATE TABLE Declaracion
(
	ID_Declaracion INT IDENTITY(1,1) PRIMARY KEY,
    Identificador VARCHAR(255) NOT NULL,
    Marca VARCHAR(255) NOT NULL,
    Linea VARCHAR(255) NOT NULL,
    Modelo VARCHAR(255) NOT NULL,
    Fecha_Declaracion DATE NOT NULL,
    Precio DECIMAL(10,2) NOT NULL
)

--FORMULAS
Formulas para Calcular Impuestos:
SAT: 
    Precio(“Marca, Linea”)+(1000/(AñoActual-Modelo+1))+200
ADUANA: 
    Precio(“Marca, Linea”)+(2000/(AñoActual-Modelo+1))+1000

--DATOS
INSERT INTO Marca(Nombre) VALUES ('ABARTH');
INSERT INTO Marca(Nombre) VALUES ('ALFA ROMEO');
INSERT INTO Marca(Nombre) VALUES ('ALFA ROMEO (FIAT)');
INSERT INTO Marca(Nombre) VALUES ('ASTON MARTIN');
INSERT INTO Marca(Nombre) VALUES ('AUDI');
INSERT INTO Marca(Nombre) VALUES ('BENTLEY');
INSERT INTO Marca(Nombre) VALUES ('BMW');
INSERT INTO Marca(Nombre) VALUES ('BYD');
INSERT INTO Marca(Nombre) VALUES ('CHEVROLET');
INSERT INTO Marca(Nombre) VALUES ('CITROEN');
INSERT INTO Marca(Nombre) VALUES ('DACIA');
INSERT INTO Marca(Nombre) VALUES ('DFSK');
INSERT INTO Marca(Nombre) VALUES ('DS');
INSERT INTO Marca(Nombre) VALUES ('FERRARI');
INSERT INTO Marca(Nombre) VALUES ('FERRARI (FCA)');
INSERT INTO Marca(Nombre) VALUES ('FIAT');
INSERT INTO Marca(Nombre) VALUES ('FIAT (FIAT)');
INSERT INTO Marca(Nombre) VALUES ('FORD');
INSERT INTO Marca(Nombre) VALUES ('HONDA');
INSERT INTO Marca(Nombre) VALUES ('HYUNDAI');
INSERT INTO Marca(Nombre) VALUES ('INFINITI');
INSERT INTO Marca(Nombre) VALUES ('ISUZU');
INSERT INTO Marca(Nombre) VALUES ('JAGUAR');
INSERT INTO Marca(Nombre) VALUES ('JEEP');
INSERT INTO Marca(Nombre) VALUES ('JEEP (FIAT)');
INSERT INTO Marca(Nombre) VALUES ('KIA');
INSERT INTO Marca(Nombre) VALUES ('LADA');
INSERT INTO Marca(Nombre) VALUES ('LAMBORGHINI');
INSERT INTO Marca(Nombre) VALUES ('LANCIA');
INSERT INTO Marca(Nombre) VALUES ('LANCIA (FIAT)');
INSERT INTO Marca(Nombre) VALUES ('LAND ROVER');
INSERT INTO Marca(Nombre) VALUES ('LEXUS');
INSERT INTO Marca(Nombre) VALUES ('MAHINDRA');
INSERT INTO Marca(Nombre) VALUES ('MASERATI');
INSERT INTO Marca(Nombre) VALUES ('MAZDA');
INSERT INTO Marca(Nombre) VALUES ('MERCEDES');
INSERT INTO Marca(Nombre) VALUES ('MINI');
INSERT INTO Marca(Nombre) VALUES ('MITSUBISHI');
INSERT INTO Marca(Nombre) VALUES ('MORGAN');
INSERT INTO Marca(Nombre) VALUES ('NISSAN');
INSERT INTO Marca(Nombre) VALUES ('OPEL');
INSERT INTO Marca(Nombre) VALUES ('PEUGEOT');
INSERT INTO Marca(Nombre) VALUES ('PORSCHE');
INSERT INTO Marca(Nombre) VALUES ('RENAULT');
INSERT INTO Marca(Nombre) VALUES ('ROLLS-ROYCE');
INSERT INTO Marca(Nombre) VALUES ('SEAT');
INSERT INTO Marca(Nombre) VALUES ('SKODA');
INSERT INTO Marca(Nombre) VALUES ('SMART');
INSERT INTO Marca(Nombre) VALUES ('SSANGYONG');
INSERT INTO Marca(Nombre) VALUES ('SUBARU');
INSERT INTO Marca(Nombre) VALUES ('SUZUKI');
INSERT INTO Marca(Nombre) VALUES ('TATA');
INSERT INTO Marca(Nombre) VALUES ('TESLA');
INSERT INTO Marca(Nombre) VALUES ('TOYOTA');
INSERT INTO Marca(Nombre) VALUES ('VOLKSWAGEN');
INSERT INTO Marca(Nombre) VALUES ('VOLVO');

INSERT INTO Linea(Marca,Nombre,Factor) VALUES (1,'500C',143.56);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (1,'500',113.58);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (1,'124 Spider',298.01);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (2,'Giulietta',151.22);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (2,'MiTo',132.44);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (2,'4C',233.42);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (2,'Giulia',233.48);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (2,'Stelvio',158.50);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (3,'4C',156.07);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (4,'DB9',136.43);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (4,'Vantage V8',286.24);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (4,'Vanquish',123.63);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (4,'Vantage V12',149.58);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (4,'Rapide',158.15);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'A4',299.95);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'A8',133.73);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'A3',225.89);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'TT',182.26);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'A5',232.29);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'A4 Allroad Quattro',250.59);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'A6',138.37);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'A7',183.82);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'Q3',145.47);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'Q5',227.90);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'S5',196.26);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'A1',295.94);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'A6 Allroad Quattro',217.82);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'S7',200.45);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'S6',123.00);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'S8',225.60);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'RS4',164.96);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'RS5',126.22);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'R8',189.42);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'SQ5',112.71);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'Q7',116.04);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'RS6',271.13);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'RS7',276.21);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'RS Q3',125.67);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'S3',229.16);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'S1',166.28);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'TTS',124.75);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'S4',217.57);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'RS3',149.74);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'SQ7',238.80);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'Q2',120.16);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'TTS',128.96);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'SQ7',216.56);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'S4',119.94);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'S6',117.42);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (5,'S7',116.39);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (6,'Continental GT',102.63);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (6,'Mulsanne',267.80);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (6,'Flying Spur',269.16);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (6,'Continental GTC',210.14);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (6,'Bentayga',141.12);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (7,'Serie 3',207.26);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (7,'Serie 5',142.67);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (7,'Serie 4',260.46);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (7,'Serie 7',131.77);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (7,'Z4',185.75);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (7,'X5',224.36);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (7,'Serie 1',218.40);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (7,'X3',148.78);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (7,'Serie 6',171.28);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (7,'X1',201.01);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (7,'X6',215.56);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (7,'I3',178.70);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (7,'Serie 2',277.76);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (7,'X4',180.67);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (7,'I8',256.35);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (7,'Serie 2 Gran Tourer',105.11);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (7,'Serie 2 Active Tourer',292.67);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (8,'E6',269.38);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (9,'Cruze',117.29);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (9,'Aveo',226.82);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (9,'Trax',203.69);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (9,'Orlando',256.00);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (9,'Spark',159.48);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (9,'Camaro',146.95);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (10,'C4',273.02);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (10,'C3',173.46);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (10,'C5',203.80);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (10,'C3 Picasso',102.93);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (10,'C4 Picasso',292.29);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (10,'Grand C4 Picasso',202.92);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (10,'C4 Aircross',192.59);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (10,'Nemo',220.60);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (10,'Berlingo',165.81);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (10,'C-Elysée',166.31);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (10,'C4 Cactus',267.46);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (10,'C1',170.32);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (10,'C-Zero',116.17);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (10,'C-Elysée',113.04);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (10,'Spacetourer',129.53);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (10,'E-Mehari',279.31);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (10,'C3 Aircross',183.91);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (11,'Logan',248.46);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (11,'Lodgy',116.83);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (11,'Sandero',111.20);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (11,'Duster',101.52);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (11,'Dokker',274.15);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (12,'Serie V',132.76);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (12,'Serie K',262.60);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (13,'DS 4',262.42);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (13,'DS 5',114.65);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (13,'DS 3',190.39);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (13,'DS 4 Crossback',246.13);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (13,'DS 7 Crossback',176.40);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (14,'488',190.27);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (14,'GTC4',299.08);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (14,'California',230.17);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (14,'F12',105.98);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (15,'458',262.31);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (15,'FF',113.33);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (15,'F12',288.10);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (15,'California',111.68);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (15,'488',224.93);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (16,'Freemont',187.88);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (16,'Doblò',273.01);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (16,'Punto',299.24);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (16,'Panda',247.01);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (16,'500',238.96);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (16,'500L',278.80);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (16,'500L',258.33);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (16,'500X',177.55);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (16,'Qubo',298.49);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (16,'Fiorino',274.36);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (16,'Bravo',109.49);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (16,'Doblò',119.98);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (16,'Doblò',266.00);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (16,'500C',104.96);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (16,'Tipo',235.12);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (16,'124 Spider',153.38);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (17,'Bravo',112.80);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (17,'Fiorino',243.25);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (18,'C-Max',260.35);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (18,'Fiesta',132.90);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (18,'Focus',273.20);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (18,'Mondeo',242.21);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (18,'Ka',170.55);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (18,'S-MAX',136.93);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (18,'B-MAX',169.78);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (18,'Grand C-Max',193.14);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (18,'Tourneo Custom',205.46);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (18,'Kuga',245.09);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (18,'Galaxy',162.78);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (18,'Grand Tourneo Connect',224.22);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (18,'Tourneo Connect',152.94);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (18,'EcoSport',129.20);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (18,'Tourneo Courier',288.11);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (18,'Mustang',188.44);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (18,'Transit Connect',281.00);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (18,'Edge',218.22);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (18,'Ka+',153.99);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (19,'Accord',184.72);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (19,'Jazz',192.65);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (19,'Civic',158.71);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (19,'CR-V',103.53);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (19,'HR-V',231.52);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (20,'I20',165.97);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (20,'Ix35',133.81);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (20,'Ix20',218.22);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (20,'I10',270.17);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (20,'Santa Fe',250.22);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (20,'Veloster',126.69);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (20,'I40',137.12);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (20,'Elantra',112.85);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (20,'I30',129.24);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (20,'Grand Santa Fe',218.54);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (20,'Genesis',197.08);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (20,'H-1 Travel',170.57);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (20,'Tucson',134.40);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (20,'I20 Active',296.36);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (20,'IONIQ',261.03);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (21,'Q70',196.95);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (21,'Q50',192.05);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (21,'QX70',112.64);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (21,'QX50',194.93);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (21,'Q60',266.18);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (21,'Q30',124.02);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (21,'QX30',286.65);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (22,'D-Max',278.06);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (23,'XF',166.81);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (23,'Serie XK',185.14);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (23,'F-Type',166.40);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (23,'XJ',287.10);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (23,'XE',137.82);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (23,'F-Pace',217.49);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (23,'E-Pace',280.38);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (24,'Grand Cherokee',181.47);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (24,'Wrangler Unlimited',199.44);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (24,'Cherokee',129.20);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (24,'Wrangler',200.12);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (24,'Renegade',235.34);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (24,'Compass',238.29);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (24,'Renegade',163.96);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (25,'Wrangler Unlimited',207.16);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (25,'Wrangler',111.40);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (25,'Cherokee',295.10);

INSERT INTO Linea(Marca,Nombre,Factor) VALUES (26,'Picanto',217.67);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (26,'Rio',212.44);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (26,'Sportage',151.88);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (26,'Venga',172.68);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (26,'Optima',279.95);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (26,'Ceed',111.06);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (26,'Ceed Sportswagon',274.41);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (26,'Carens',133.11);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (26,'Pro_ceed',130.67);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (26,'Sorento',172.44);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (26,'Soul',103.46);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (26,'Niro',285.19);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (26,'Soul EV',105.44);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (26,'Pro_ceed GT',163.32);

INSERT INTO Linea(Marca,Nombre,Factor) VALUES (27,'4X4',142.37);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (27,'Priora',276.60);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (28,'Aventador',259.22);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (28,'Huracán',280.46);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (29,'Ypsilon',296.81);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (29,'Voyager',100.12);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (29,'Delta',203.25);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (30,'Thema',230.13);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (30,'Delta',297.33);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (31,'Defender',199.09);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (31,'Discovery 4',268.27);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (31,'Range Rover',132.94);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (31,'Range Rover Evoque',136.89);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (31,'Freelander',214.64);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (31,'Range Rover Sport',255.62);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (31,'Discovery Sport',155.80);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (31,'Discovery',138.56);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (31,'Range Rover Velar',255.46);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (32,'GS',277.85);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (32,'RX',276.38);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (32,'CT',299.42);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (32,'IS',291.07);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (32,'NX',262.01);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (32,'RC',171.31);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (32,'LS',118.35);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (32,'LC',169.89);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (33,'XUV500',190.93);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (34,'GranCabrio',285.55);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (34,'Quattroporte',208.96);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (34,'Ghibli',246.28);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (34,'GranTurismo',291.89);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (34,'Levante',288.46);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (35,'Mazda2',222.79);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (35,'CX-5',263.65);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (35,'Mazda6',147.09);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (35,'MX-5',151.14);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (35,'Mazda3',164.09);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (35,'Mazda5',185.89);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (35,'CX-9',296.44);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (35,'CX-3',189.84);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (36,'Clase SL',264.12);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (36,'Clase SLK',295.11);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (36,'Clase V',130.86);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (36,'Clase C',212.07);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (36,'Clase M',201.02);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (36,'Clase G',280.88);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (36,'Clase E',133.18);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (36,'Clase CL',174.68);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (36,'Clase S',200.98);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (36,'Clase GLK',234.88);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (36,'SLS AMG',213.51);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (36,'Clase B',117.44);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (36,'Clase A',236.96);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (36,'Clase GL',234.32);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (36,'Clase CLS',207.34);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (36,'Clase CLA',170.80);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (36,'Clase GLA',152.87);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (36,'AMG GT',148.59);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (36,'Vito',157.42);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (36,'Clase GLE Coupé',153.46);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (36,'Clase GLE',284.89);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (36,'Clase GLE Coupé',235.90);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (36,'Clase GLK',183.81);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (36,'Clase GLC',272.76);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (36,'Citan',225.38);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (36,'Clase GLS',209.98);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (36,'Clase SLC',161.80);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (36,'GLC Coupé',120.44);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (36,'Mercedes-AMG GT',180.88);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (37,'MINI',151.78);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (37,'COUNTRYMAN',273.83);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (37,'PACEMAN',116.44);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (37,'CLUBMAN',112.56);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (38,'Montero',117.01);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (38,'I-MiEV',178.60);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (38,'ASX',194.95);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (38,'Outlander',115.50);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (38,'Space Star',147.60);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (38,'L200',249.99);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (39,'Roadster',250.12);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (39,'Plus 8',292.74);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (39,'Plus 4',233.63);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (39,'4/4',277.71);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (40,'X-TRAIL',262.39);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (40,'QASHQAI',110.69);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (40,'NOTE',192.13);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (40,'LEAF',193.72);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (40,'Pathfinder',112.33);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (40,'EVALIA',284.30);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (40,'Navara',229.81);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (40,'Micra',190.16);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (40,'JUKE',255.08);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (40,'370Z',233.59);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (40,'NV200',139.41);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (40,'GT-R',229.04);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (40,'PULSAR',276.48);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (40,'Murano',277.79);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (40,'NV200 EVALIA',242.56);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (40,'E-NV200 EVALIA',208.41);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (41,'Corsa',281.06);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (41,'Astra',188.50);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (41,'Meriva',136.80);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (41,'Zafira Tourer',146.51);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (41,'Zafira',272.52);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (41,'Insignia',110.78);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (41,'Combo',230.56);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (41,'Ampera',272.45);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (41,'Mokka',178.66);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (41,'Adam',178.70);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (41,'Cabrio',156.83);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (41,'Antara',271.26);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (41,'Karl',145.86);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (41,'GTC',201.82);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (41,'GTC',245.07);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (41,'Mokka',120.73);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (41,'Zafira',182.18);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (41,'Crossland X',179.21);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (41,'Mokka X',100.34);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (42,'308',179.08);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (42,'807',163.47);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (42,'Bipper',110.00);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (42,'508',189.76);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (42,'Partner',234.86);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (42,'3008',233.61);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (42,'208',212.20);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (42,'2008',168.65);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (42,'RCZ',114.38);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (42,'5008',127.60);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (42,'4008',236.42);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (42,'108',292.09);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (42,'207',156.87);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (42,'Ion',125.75);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (42,'Traveller',266.17);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (43,'911',252.38);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (43,'Boxster',214.01);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (43,'Cayenne',207.03);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (43,'Panamera',234.05);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (43,'918',159.00);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (43,'Macan',207.98);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (43,'Cayman',111.75);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (43,'718',150.56);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (44,'Fluence',134.61);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (44,'Grand Scénic',290.77);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (44,'Latitude',246.19);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (44,'Clio',142.36);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (44,'Scénic',139.45);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (44,'Laguna',287.90);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (44,'Kangoo Combi',266.26);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (44,'Mégane',226.98);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (44,'Grand Kangoo Combi',155.98);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (44,'Captur',180.59);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (44,'ZOE',162.21);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (44,'Koleos',113.10);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (44,'Twingo',166.54);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (44,'Espace',283.33);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (44,'Kadjar',133.44);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (44,'Talisman',208.69);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (45,'Phantom',239.46);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (46,'Ibiza',107.22);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (46,'Nuevo León',290.04);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (46,'Alhambra',243.69);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (46,'Altea',101.80);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (46,'Mii',264.84);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (46,'Toledo',246.80);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (46,'Altea XL',269.48);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (46,'Ateca',222.40);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (46,'León',168.42);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (46,'Nuevo Ibiza',185.92);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (47,'Octavia',284.54);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (47,'Fabia',254.35);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (47,'Roomster',100.81);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (47,'Yeti',156.20);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (47,'Superb',153.56);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (47,'Citigo',293.47);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (47,'Rapid',297.42);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (47,'Spaceback',249.17);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (47,'Scout',236.88);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (47,'Kodiaq',197.68);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (48,'Fortwo',167.44);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (48,'Forfour',247.08);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (49,'Rexton',227.83);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (49,'Rodius',182.28);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (49,'Korando',103.75);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (49,'Actyon Sports Pick Up',172.62);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (49,'Tivoli',107.24);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (49,'XLV',256.45);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (50,'Forester',283.79);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (50,'XV',287.12);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (50,'Outback',267.81);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (50,'BRZ',199.24);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (50,'WRX STI',247.11);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (50,'LEVORG',281.77);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (50,'WRX STI',135.25);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (51,'Grand Vitara',286.24);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (51,'Swift',250.58);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (51,'SX4',285.39);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (51,'Jimny',218.84);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (51,'SX4 S-Cross',273.23);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (51,'Celerio',248.43);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (51,'Kizashi',272.81);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (51,'Vitara',261.02);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (51,'Baleno',218.75);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (51,'Ignis',221.87);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (52,'Xenon',299.32);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (52,'Aria',223.71);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (52,'Vista',185.03);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (53,'Model X',291.83);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (53,'Model S',109.72);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (54,'Avensis',248.47);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (54,'Land Cruiser',295.15);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (54,'Yaris',188.35);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (54,'Verso',274.43);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (54,'Auris',258.39);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (54,'Prius+',243.78);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (54,'GT86',221.51);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (54,'Prius',290.53);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (54,'Rav4',131.24);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (54,'Aygo',160.24);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (54,'Hilux',101.26);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (54,'Land Cruiser 200',252.21);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (54,'Proace Verso',167.07);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (54,'C-HR',104.45);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (55,'Polo',187.39);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (55,'Jetta',142.98);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (55,'Phaeton',297.23);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (55,'Golf',240.07);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (55,'Touran',215.78);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (55,'Touareg',131.06);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (55,'Beetle',138.00);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (55,'Sharan',273.80);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (55,'Tiguan',243.51);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (55,'Multivan',259.66);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (55,'California',178.57);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (55,'Caravelle',275.65);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (55,'Up!',282.85);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (55,'CC',215.68);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (55,'Golf Sportsvan',111.51);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (55,'Amarok',102.52);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (55,'Caddy',252.96);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (55,'Transporter',232.86);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (55,'Scirocco',163.08);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (55,'Passat',135.47);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (55,'Eos',268.23);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (55,'Arteon',239.92);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (56,'V70',261.62);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (56,'S80',111.28);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (56,'XC70',103.36);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (56,'V60',299.21);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (56,'S60',193.89);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (56,'XC90',279.43);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (56,'XC60',127.89);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (56,'V40',198.24);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (56,'V40 Cross Country',142.71);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (56,'V60 Cross Country',148.20);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (56,'S60 Cross Country',286.79);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (56,'S90',154.28);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (56,'V90',173.43);
INSERT INTO Linea(Marca,Nombre,Factor) VALUES (56,'V90 Cross Country',296.84);


