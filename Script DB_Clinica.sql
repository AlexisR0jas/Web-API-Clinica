Create database DB_Clinica
use DB_Clinica
go
Create Table Especialidades(
ID_Especialidad int primary key identity(1,1) not null,
NombreEspecialidad varchar(100) null
)

Create Table Medicos(
ID_Medico int primary key identity(1,1) not null,
Nombre varchar(100) null,
Apellido varchar(100) null,
ID_Especialidad int foreign key references Especialidades(ID_Especialidad) not null,
Celular varchar(100) null,
Correo varchar(100) null,
CostoConsulta money not null,
FechaIngreso date not null
)

Create Table ObrasSociales(
	ID_ObraSocial int primary key identity(1,1) not null,
	Nombre varchar(100) null,
	Cobertura decimal(10,2) not null
)

Create Table Pacientes(
	ID_Paciente int primary key identity(1,1) not null,
	Apellido varchar(100) null,
	Nombre varchar(100) null,
	FechaNacimiento datetime not null,
	Sexo nvarchar(max) check(Sexo in('M','F')) null,
	ID_ObraSocial int foreign key references ObrasSociales(ID_ObraSocial) not null
)

Create Table Turnos(
	ID_Turno int primary key identity(1,1) not null,
	FechaHora datetime not null,
	ID_Medico int foreign key references Medicos(ID_Medico)not null,
	ID_Paciente int foreign key references Pacientes(ID_Paciente)not null,
	Duracion int not null
)

Create Table Facturas(
	ID_Factura int primary key identity(1,1) not null,
	ID_Paciente int foreign key references Pacientes(ID_Paciente)not null,
	ID_Medico int foreign key references Medicos(ID_Medico) not null,
	Costo decimal(10,2) not null,
	FecheEmision datetime not null
)use Clinica

INSERT INTO Especialidades (Nombre)
VALUES
('Cardiología'),
('Cirugía'),
('Dermatología'),
('Ginecología'),
('Pediatría'),
('Oftalmología'),
('Otorrinolaringología'),
('Traumatología'),
('Urología');

INSERT INTO Medicos (Nombre, Apellido, EspecialidadID, Celular, Correo, CostoConsulta, FechaIngreso)
VALUES
('Juan', 'Perez', 1, '1555555555', 'juan.perez@clinica.com', 1000, '2023-01-01'),
('Maria', 'Lopez', 2, '1566666666', 'maria.lopez@clinica.com', 2000, '2023-01-02'),
('Pedro', 'Garcia', 3, '1577777777', 'pedro.garcia@clinica.com', 3000, '2023-01-03'),
('Ana', 'Martinez', 4, '1588888888', 'ana.martinez@clinica.com', 4000, '2023-01-04'),
('Luis', 'Sanchez', 5, '1599999999', 'luis.sanchez@clinica.com', 5000, '2023-01-05'),
('Carlos', 'Gomez', 6, '1500000000', 'carlos.gomez@clinica.com', 6000, '2023-01-06'),
('Laura', 'Rodriguez', 7, '1511111111', 'laura.rodriguez@clinica.com', 7000, '2023-01-07'),
('David', 'Torres', 8, '1522222222', 'david.torres@clinica.com', 8000, '2023-01-08');

INSERT INTO ObrasSociales (Nombre, Cobertura)
VALUES
('Obra Social A', 80),
('Obra Social B', 70),
('Obra Social C', 60),
('Obra Social D', 50),
('Obra Social E', 40),
('Obra Social F', 30),
('Obra Social G', 20),
('Obra Social H', 10);

INSERT INTO Pacientes (Apellido, Nombre, FechaNacimiento, Sexo, ObraSocialID)
VALUES
('García', 'Juan', '1980-01-01', 'M', 1),
('López', 'María', '1981-02-02', 'F', 2),
('Martínez', 'Pedro', '1982-03-03', 'M', 3),
('Sánchez', 'Ana', '1983-04-04', 'F', 4),
('Gomez', 'Luis', '1984-05-05', 'M', 5),
('Rodríguez', 'Carlos', '1985-06-06', 'F', 6),
('Torres', 'Laura', '1986-07-07', 'M', 7),
('David', 'David', '1987-08-08', 'M', 8);

INSERT INTO Turnos (FechaHora, MedicoID, PacienteID, Duracion)
VALUES
('2023-01-20 10:00:00', 1, 1, 30),
('2023-01-21 11:00:00', 2, 2, 60),
('2023-01-22 12:00:00', 3, 3, 90),
('2023-01-23 13:00:00', 4, 4, 120),
('2023-01-24 14:00:00', 5, 5, 150),
('2023-01-25 15:00:00', 6, 6, 180),
('2023-01-26 16:00:00', 7, 7, 210),
('2023-01-27 17:00:00', 8, 8, 240);

INSERT INTO Facturas (PacienteID, MedicoID, Costo, FechaEmision)
VALUES
(1, 1, 3000, '2023-01-20'),
(2, 2, 4000, '2023-01-21'),
(3, 3, 5000, '2023-01-22'),
(4, 4, 6000, '2023-01-23'),
(5, 5, 7000, '2023-01-24'),
(6, 6, 8000, '2023-01-25'),
(7, 7, 9000, '2023-01-26'),
(8, 8, 10000, '2023-01-27');








