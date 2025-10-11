
-- TURNERO lógica conceptual

-- Paciente ( 1 Paciente pide una Solicitud o varias )
    -- Solicitud ( La Solicitud es generada por el sistema y se evalua si se asigna el Turno )
        -- Turno ( El turno se registra solo y solo si hay disponibilidad de Medico )
            -- Medico ( FK de Turno )
                -- Especialidad ( FK de Medico )
            -- Consultorio ( FK de Turno )


CREATE DATABASE api_db_turnero;


CREATE TABLE Paciente (
    id_paciente INT PRIMARY KEY IDENTITY(1,1),
    nombre TEXT,
    email TEXT,
    telefono INT,
    fecha_nacimiento DATETIME,
);


CREATE TABLE Solicitud (
    id_solicitud INT PRIMARY KEY IDENTITY(1,1),
    descripcion TEXT,
    fecha_solicitud DATETIME,
    id_paciente INT FOREIGN KEY REFERENCES Paciente(id_paciente)
);


CREATE TABLE Especialidad (
    id_especialidad INT PRIMARY KEY IDENTITY(1,1),
    descripcion TEXT,
);

-- Inserts:
insert into Especialidad(descripcion) VALUES ('Odontología');
insert into Especialidad(descripcion) VALUES ('Pediatría');
insert into Especialidad(descripcion) VALUES ('Cirujano');
insert into Especialidad(descripcion) VALUES ('Enfermería');


CREATE TABLE Medico (
    id_medico INT PRIMARY KEY IDENTITY(1,1),
    nombre TEXT,
    email TEXT,
    id_especialidad INT FOREIGN KEY REFERENCES Especialidad(id_especialidad),
);

-- Inserts:
insert into Medico(nombre, email, id_especialidad) VALUES ('Jose Migrañas', 'jose@gmail.com', 1);
insert into Medico(nombre, email, id_especialidad) VALUES ('Angela Leiva', 'angela@gmail.com', 2);
insert into Medico(nombre, email, id_especialidad) VALUES ('Juan Genitales', 'juan@gmail.com', 3);
insert into Medico(nombre, email, id_especialidad) VALUES ('Carla Guardia', 'carla@gmail.com', 4);


CREATE TABLE Consultorio (
    id_consultorio INT PRIMARY KEY IDENTITY(1,1),
    direccion TEXT,
);

-- Inserts:
insert into Consultorio(direccion) VALUES ('Calle falsa 123');
insert into Consultorio(direccion) VALUES ('Av. siempre viva 0');
insert into Consultorio(direccion) VALUES ('Buenos Aires 012');


CREATE TABLE Turno (
    id_turno INT PRIMARY KEY IDENTITY(1,1),
    fecha_turno DATETIME,
    estado TEXT,
    id_solicitud INT FOREIGN KEY REFERENCES Solicitud(id_solicitud),
    id_consultorio INT FOREIGN KEY REFERENCES Consultorio(id_consultorio)
);