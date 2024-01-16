Create database DB_Clinica
use DB_Clinica
go
Create Table Especialidades(
ID_Especialidad bigint primary key identity(1,1) not null,
NombreEspecialidad varchar(100) not null
)

Create Table Medicos(
ID_Medico bigint primary key identity(1,1) not null,
Nombre varchar(100) not null,
Apellido varchar(100) not null,
ID_Especialidad bigint foreign key references Especialidades(ID_Especialidad),
Celular varchar(100) not null,
Correo varchar(100) not null,
CostoConsulta money not null,
FechaIngreso date not null
)

Create Table ObrasSociales(
	ID_ObraSocial bigint primary key identity(1,1) not null,
	Nombre varchar(100) not null,
	Cobertura decimal(10,2) not null
)

Create Table Pacientes(
	ID_Paciente bigint primary key identity(1,1) not null,
	Apellido varchar(100) not null,
	Nombre varchar(100) not null,
	FechaNacimiento date not null,
	Sexo char(1) check(Sexo in('M','F'))not null,
	ID_ObraSocial bigint foreign key references ObrasSociales(ID_ObraSocial)
)

Create Table Turnos(
	ID_Turno bigint primary key identity(1,1) not null,
	FechaHora datetime not null,
	ID_Medico bigint foreign key references Medicos(ID_Medico),
	ID_Paciente bigint foreign key references Pacientes(ID_Paciente),
	Duracion int not null
)

Create Table Facturas(
	ID_Factura bigint primary key identity(1,1) not null,
	ID_Paciente bigint foreign key references Pacientes(ID_Paciente),
	ID_Medico bigint foreign key references Medicos(ID_Medico),
	Costo money not null,
	FecheEmision datetime not null
)



