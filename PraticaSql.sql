--DDL Data Definition Language 
/* Crear BD*/

create database DBPrueba26;
go

use DBprueba26
go

create table Ciudad (
	id INT primary key identity(1,1),
	nombre nvarchar(50) NOT NULL,
	estado bit default 1
);
go
create table Persona(
	id int primary key identity(1,1),
	primerNombre nvarchar(50) NOT NULL,
	segundoNombre nvarchar(50),
	primerApellido nvarchar(50) NOT NULL,
	segundoApellido nvarchar(50),
	fechaNacimiento datetime NOT NULL,
	sexo bit default 1 NOT NULL,
	telefono nvarchar(16),
	email nvarchar(100),
	residencia nvarchar(100),
	estado bit default 'true'
);

/*DML- Data Modification Language*/

--crear o insertar registros

INSERT INTO Ciudad(nombre) values (N'Masaya')
INSERT INTO Ciudad(nombre) values (N'Boaco')
INSERT INTO Ciudad(nombre) values (N'Matagalpa')
INSERT INTO Ciudad(nombre) values (N'Managua')

-- Mostrar registro

select UPPER(nombre) as "Nombre" from Ciudad